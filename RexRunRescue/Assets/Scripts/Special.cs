using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour 
{
	public static int specialNeeded;
	public float TimeLimit;
	public float SpecialLvl;
	public GameObject NormalPet, SpecialPet;

	public static bool SpecialActive = false;

	// Use this for initialization
	void Start () 
	{
		SetSpecailStat ();

		NormalPet.SetActive (true);
		SpecialPet.SetActive (false);
		SpecialActive = false;

	}
	
	// Update is called once per frame
	void Update ()
	{/*
		if (PlayerController.specialCount >= specialNeeded) 
		{
			NormalPet.SetActive (false);
			SpecialPet.SetActive (true);
			SpecialActive = true;
			PlayerController.specialCount -= specialNeeded;

			StartCoroutine (UndoSpecial ());
		}*/
	}

	IEnumerator UndoSpecial() 
	{
		yield return new WaitForSeconds (TimeLimit);
		NormalPet.SetActive (true);
		SpecialPet.SetActive (false); 
		SpecialActive = false; 
	}

	void SetSpecailStat ()
	{
		SpecialLvl = PetsStat.SpecialLvl;
		specialNeeded = 6- (int)SpecialLvl;
		TimeLimit = SpecialLvl * 0.25f + 4; 
	}

}
