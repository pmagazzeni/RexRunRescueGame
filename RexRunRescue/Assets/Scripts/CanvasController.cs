using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour 
{
	public Text 
	PlayerHUD,
	LevelupText,
	//Selected Pet Stats, PLay Panel
	SpecialPlayText,
	MaxHealthPlayText,
	SpeedPlayText,
	JumpPlayText,
	//Selected Pet Stats, Stats Panel
	SpecialStatsText,
	MaxHealthStatsText,
	SpeedStatsText,
	JumpStatsText; 

	//public Text WeeklyDistText; 

	//menu panels
	public GameObject
	PlayMenu, 
	PetStatsMenu,
	FriendMenu, 
	SettingsMenu,
	//Pet Menu
	PetStats,
	PetInv,
	PetTrophy;

	//menu stat bars
	//Play stats bars
	public Image 
	PlaySpecialFillBar,
	PlayHealthFillBar,
	PlaySpeedFillBar,
	PlayJumpFillBar,
	//Pet stats bars
	PetSpecialFillBar,
	PetHealthFillBar,
	PetSpeedFillBar,
	PetJumpFillBar;

	float
	maxSpecial = 10f,
	maxHealth = 10f,
	maxSpeed = 10f,
	maxJunp = 10f;


	// Use this for initialization
	void Start () 
	{
		UpdateText();
		PlayMenuBttn ();
		StartCoroutine (LateStart());
		SetWeeklyText ();
		Time.timeScale = 1;
	}

	IEnumerator LateStart()
	{
		yield return new WaitForSeconds (0.1f);
		UpdateText();
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateStatsBars ();
		SetWeeklyText ();
	}

	//set playerHUD
	void SetPlayerHUD ()
	{
		PlayerHUD.text = "Player Name"
		+ "\nFollower: " + PlayerStats.Followers
		+ "\nLicks: " + PlayerStats.Likes
		+ "\nDistans: " + PlayerStats.PlayerDistance 
		+ "\nTreats: " + PlayerStats.Treats 
		+ "\nTokens: " + PlayerStats.Tokens;
	}

	void SetLevelupPoints ()
	{
		LevelupText.text = "You have " + PlayerStats.PlayerLevelupPoints + " Levelup Points" 
			+ "\n to add to " + PetsStat.SelectedPetName + "'s stats" ;
	}

	//Selected Pet Stats, Play Panel
	void SetPlayPetStatsText()
	{
		SpecialPlayText.text = "Special: " + PetsStat.SpecialLvl;
		MaxHealthPlayText.text = "Max Health: "+ PetsStat.MaxHealth;
		SpeedPlayText.text = "Speed: " + PetsStat.Speed;
		JumpPlayText.text = "Jump: " + PetsStat.JumpHeight;

	}

	//Selected Pet Stats, Stats Panel
	void SetStatPetStatsText()
	{
		SpecialStatsText.text = "Special: " + PetsStat.SpecialLvl;
		MaxHealthStatsText.text = "Max Health: "+ PetsStat.MaxHealth;
		SpeedStatsText.text = "Speed: " + PetsStat.Speed;
		JumpStatsText.text = "Jump: " + PetsStat.JumpHeight;
	}

	//main buttons
	public void PlayMenuBttn()
	{
		SavePlayerGame();
		UpdateText();
		PlayMenu.SetActive (true);
		PetStatsMenu.SetActive (false);
		FriendMenu.SetActive (false);
		SettingsMenu.SetActive (false);
	}

	public void PetStatsMenuBttn()
	{
		SavePlayerGame();
		UpdateText();
		PlayMenu.SetActive (false);
		PetStatsMenu.SetActive (true);
		FriendMenu.SetActive (false);
		SettingsMenu.SetActive (false);
		PetStatsBttn ();
	}

	public void FriendMenuBttn()
	{
		SavePlayerGame();
		PlayMenu.SetActive (false);
		PetStatsMenu.SetActive (false);
		FriendMenu.SetActive (true);
		SettingsMenu.SetActive (false);
	}

	public void SettingsMenuBttn()
	{
		SavePlayerGame();
		PlayMenu.SetActive (false);
		PetStatsMenu.SetActive (false);
		FriendMenu.SetActive (false);
		SettingsMenu.SetActive (true);
	}

	//SaveGame
	public void SavePlayerGame()
	{
		GameObject.Find ("Canvas").GetComponent<PetsStat>().SavePetStats ();
		GameObject.Find ("Canvas").GetComponent<PlayerStats>().SavePlayerStats ();
	}

	//Buttons For Pet Stats Menu, PetStats PetInv
	public void PetStatsBttn()
	{
		PetStats.SetActive (true);
		PetInv.SetActive (false);
		PetTrophy.SetActive (false);
	}

	public void PetInvBttn()
	{
		PetStats.SetActive (false);
		PetInv.SetActive (true);
		PetTrophy.SetActive (false);
	}

	public void PetTrophyBttn()
	{
		PetStats.SetActive (false);
		PetInv.SetActive (false);
		PetTrophy.SetActive (true);
	}

	//set and update canvas text 
	public void UpdateText()
	{
		SetPlayerHUD ();
		SetLevelupPoints ();
		SetPlayPetStatsText ();
		SetStatPetStatsText ();


	}

	void UpdateStatsBars ()
	{
		PlaySpecialFillBar.fillAmount = PetsStat.SpecialLvl / maxSpecial;
		PlayHealthFillBar.fillAmount = PetsStat.MaxHealth / maxHealth;
		PlaySpeedFillBar.fillAmount = PetsStat.Speed / maxSpeed;
		PlayJumpFillBar.fillAmount = PetsStat.JumpHeight / maxJunp;
		//Pet stats bars
		PetSpecialFillBar.fillAmount = PetsStat.SpecialLvl / maxSpecial;
		PetHealthFillBar.fillAmount = PetsStat.MaxHealth / maxHealth;
		PetSpeedFillBar.fillAmount = PetsStat.Speed / maxSpeed;
		PetJumpFillBar.fillAmount = PetsStat.JumpHeight / maxJunp;
	}

	void SetWeeklyText()
	{
		//WeeklyDistText.text = "Weekly Distance: \n" + PlayerStats.weeklyDistance; 
	}
}
