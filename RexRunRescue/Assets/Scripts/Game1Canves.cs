using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game1Canves : MonoBehaviour 
{
	public GameObject PlayPanel, PusePanel, ResumeBttn;

	public Text PuseText, PlayerHUDText;



	// Use this for initialization
	void Start () 
	{
		ResumeButton();
		//Special.SpecialLvl = 0; 
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		PlayerHUDText.text = "Followers: " + PlayerStats.Followers
			+ "\nXP: " + PlayerStats.XP + "/" + PlayerStats.XPMax
			+ "\nLicks: " + PlayerStats.Likes; 
			//+ "\nTreats: " + PlayerStats.Treats;
	}

	public void PuseButton()
	{
		PlayPanel.SetActive (false);
		PusePanel.SetActive (true);
		ResumeBttn.SetActive (true);

		Time.timeScale = 0;
	}

	public void ResumeButton()
	{
		PlayPanel.SetActive (true);
		PusePanel.SetActive (false);
		ResumeBttn.SetActive (true);

		Time.timeScale = 1;
	}

	public void HomeButton(string LevelName)
	{
		GetPlayersDistFromController ();
		GameObject.Find ("Canvas").GetComponent<PlayerStats>().SavePlayerStats();
		SceneManager.LoadScene (LevelName);
	}

	public void RetryButton(string LevelName)
	{
		GetPlayersDistFromController ();
		GameObject.Find ("Canvas").GetComponent<PlayerStats>().SavePlayerStats();
		SceneManager.LoadScene (LevelName);
	}

	public void SettingsButton()
	{
		
	}

	public void IfPetIsDead()
	{
		PuseText.text = "Game Over" 
			+ "\n\nYou've met with a terrible fate, havent you?" 
			+ "\n\nWould you like to try again?";
		GameObject.Find ("Canvas").GetComponent<PlayerStats>().SavePlayerStats();
		PuseButton ();
		ResumeBttn.SetActive (false); 
	}

	public void SavePlayerGame1()
	{
		GameObject.Find ("Canvas").GetComponent<PetsStat>().SavePetStats ();
		GameObject.Find ("Canvas").GetComponent<PlayerStats>().SavePlayerStats ();
	}

	void GetPlayersDistFromController()
	{
		//GameObject.Find ("Canvas").GetComponent<PlayerStats>().SavePlayerStats();
		GameObject.FindWithTag("Player").GetComponent<PlayerController>().SaveThisDistance(); 
	}
}
