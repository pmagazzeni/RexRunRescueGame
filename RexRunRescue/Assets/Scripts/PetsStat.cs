using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsStat : MonoBehaviour 
{
	public static int 
	SpecialLvl,
	MaxHealth,
	Speed,
	JumpHeight;

	public static string 
	Rex = "Rex", 
	Lincoln = "Lincoln", 
	Poppy = "Poppy", 
	Tucker = "Tucker",
	CustomPet;


	public static string SelectedPetName;

	public int PlayerLevelupPoints;

	// Use this for initialization
	void Start () 
	{
		GetPlayerStats ();

		SelectedPetName = Rex;
		GetPetStats ();

		if (SpecialLvl == 0) 
		{
			ResetPets ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
				 
	}

	void GetPetStats()
	{
		SelectedPetName = PlayerPrefs.GetString ("SelectedPetName", SelectedPetName);

		SpecialLvl = PlayerPrefs.GetInt (SelectedPetName + "SpecialLvl", SpecialLvl);
		MaxHealth = PlayerPrefs.GetInt (SelectedPetName + "MaxHealth", MaxHealth);
		Speed = PlayerPrefs.GetInt (SelectedPetName + "Speed", Speed);
		JumpHeight = PlayerPrefs.GetInt (SelectedPetName + "JumpHeight", JumpHeight); 
	}

	public void SavePetStats()
	{
		//SelectedPetName = PlayerPrefs.GetString ("SelectedPetName", SelectedPetName);
		
		PlayerPrefs.SetInt (SelectedPetName + "SpecialLvl", SpecialLvl);
		PlayerPrefs.SetInt (SelectedPetName + "MaxHealth", MaxHealth); 
		PlayerPrefs.SetInt (SelectedPetName + "Speed", Speed);
		PlayerPrefs.SetInt (SelectedPetName + "JumpHeight", JumpHeight);
	}

	void GetPlayerStats()
	{
		PlayerLevelupPoints = PlayerStats.PlayerLevelupPoints;
	}

	public void SetRex() 
	{
		SelectedPetName = Rex;
		GetPetStats ();
	}

	public void SetLincoln()
	{
		SelectedPetName = Lincoln;
		GetPetStats ();
	}

	public void SetPoppy()
	{
		SelectedPetName = Poppy;
		GetPetStats ();
	}

	public void SetTucker()
	{
		SelectedPetName = Tucker;
		GetPetStats ();
	}

	public void SetCustomPet()
	{
		SelectedPetName = null;
		GetPetStats ();
	}

	public void ResetPets()
	{
		
		
		//Reset Rex
		PlayerPrefs.SetInt (Rex + "SpecialLvl", 1);
		PlayerPrefs.SetInt (Rex + "MaxHealth", 2);
		PlayerPrefs.SetInt (Rex + "Speed", 2);
		PlayerPrefs.SetInt (Rex + "JumpHeight", 2);

		//Reset Lincoln
		PlayerPrefs.SetInt (Lincoln + "SpecialLvl", 1);
		PlayerPrefs.SetInt (Lincoln + "MaxHealth", 1);
		PlayerPrefs.SetInt (Lincoln + "Speed", 3);
		PlayerPrefs.SetInt (Lincoln + "JumpHeight", 2);

		//Reset Poppy
		PlayerPrefs.SetInt (Poppy + "SpecialLvl", 1);
		PlayerPrefs.SetInt (Poppy + "MaxHealth", 1);
		PlayerPrefs.SetInt (Poppy + "Speed", 1);
		PlayerPrefs.SetInt (Poppy + "JumpHeight", 3);

		//Reset Tucker
		PlayerPrefs.SetInt (Tucker+ "SpecialLvl", 1);
		PlayerPrefs.SetInt (Tucker + "MaxHealth", 3);
		PlayerPrefs.SetInt (Tucker + "Speed", 1);
		PlayerPrefs.SetInt (Tucker + "JumpHeight", 2);

		GetPetStats ();
	}

	//Add 1 Levelup Point to Curently Selected Pet's SpecialLvl
	public void AddToPetSpecial()
	{
		GetPetStats ();

		if (PlayerLevelupPoints > 0)
		{
			SpecialLvl++;
			PlayerStats.PlayerLevelupPoints--;
			PlayerLevelupPoints--;
			SavePetStats ();
		}

	}

	//Add 1 Levelup Point to Curently Selected Pet's MaxHealth
	public void AddToPetMaxHealth()
	{
		GetPetStats ();

		if (PlayerLevelupPoints > 0) 
		{
			MaxHealth++;
			PlayerStats.PlayerLevelupPoints--;
			PlayerLevelupPoints--;
			SavePetStats ();
		}
	}

	public void MinusToPetMaxHealth()
	{
		GetPetStats ();

		if (MaxHealth > 1) 
		{
			MaxHealth--;
			PlayerStats.PlayerLevelupPoints++;
			PlayerLevelupPoints++;
			SavePetStats ();
		}
	}

	//Add 1 Levelup Point to Curently Selected Pet's Speed
	public void AddToPetSpeed()
	{
		GetPetStats ();

		if (PlayerLevelupPoints > 0) 
		{
			Speed++;
			PlayerStats.PlayerLevelupPoints--;
			PlayerLevelupPoints--;
			SavePetStats ();
		}
	}

	public void MinusToPetSpeed()
	{
		GetPetStats ();

		if (Speed > 1) 
		{
			Speed--;
			PlayerStats.PlayerLevelupPoints++;
			PlayerLevelupPoints++;
			SavePetStats ();
		}
	}

	//Add 1 Levelup Point to Curently Selected Pet's JumpHeight
	public void AddToPetJumpHeight()
	{
		GetPetStats ();

		if (PlayerLevelupPoints > 0) 
		{
			JumpHeight++;
			PlayerStats.PlayerLevelupPoints--;
			PlayerLevelupPoints--;
			SavePetStats (); 
		}
	}

	public void MinusToPetJumpHeight()
	{
		GetPetStats ();

		if (JumpHeight > 1) 
		{
			JumpHeight--;
			PlayerStats.PlayerLevelupPoints++;
			PlayerLevelupPoints++;
			SavePetStats (); 
		}
	}

}
