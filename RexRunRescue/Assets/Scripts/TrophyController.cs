using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyController : MonoBehaviour 
{
	public GameObject lockedTrophy;

	public int isLocked;

	public string TrophyName; 

	public int scoreNeeded;

	public bool 
	overAllDistance, 
	weeklyDistance, 
	followers,
	Likes, 
	tokens, 
	treats,
	savedPuppy,
	savedArt;

	// Use this for initialization
	void Start () 
	{
		GetTrophyBool ();
		ObtainTrophy ();

		if (savedPuppy != true) 
		{
			if (isLocked <= 0) 
			{
				lockedTrophy.SetActive (true);
			}
			if (isLocked > 0) 
			{
				lockedTrophy.SetActive (false);
			}
		}

		if (savedPuppy == true) 
		{
			if (isLocked <= 0) 
			{
				lockedTrophy.SetActive (true);
			}
			if (isLocked > 0) 
			{
				lockedTrophy.SetActive (false);
			}
		}




	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void GetTrophyBool ()
	{
		isLocked = PlayerPrefs.GetInt (TrophyName + "Bool", isLocked);
	}

	void SetItemBool()
	{
		PlayerPrefs.SetInt (TrophyName + "Bool", isLocked);
	}

	void ObtainTrophy()
	{
		if(scoreNeeded <= PlayerStats.PlayerDistance && overAllDistance == true && isLocked == 0)
		{
			isLocked = 1;
			//lockedTrophy.SetActive (false);
			Debug.Log ("over all dist trophy");
		}

		if(scoreNeeded >= PlayerStats.weeklyDistance && weeklyDistance == true && isLocked == 0)
		{
			isLocked = 1;
			lockedTrophy.SetActive (false);
			Debug.Log ("weekly dist trophy");
		}

		if(scoreNeeded >= PlayerStats.Followers && followers == true && isLocked == 0)
		{
			isLocked = 1;
			lockedTrophy.SetActive (false);
			Debug.Log ("followers dist trophy");
		}

		if(scoreNeeded >= PlayerStats.Likes && Likes == true && isLocked == 0)
		{
			isLocked = 1;
			lockedTrophy.SetActive (false);
			Debug.Log ("Likes trophy");
		}

		if(PlayerPrefs.GetInt (TrophyName + "Bool", isLocked) >= 1 && savedPuppy == true && isLocked < 2)
		{
			isLocked += 1;
			lockedTrophy.SetActive (false);
			Debug.Log ("puppy trophy");
		}
	}

	public void ResetTrophy()
	{
		isLocked = 0;
		SetItemBool ();
	}
}
