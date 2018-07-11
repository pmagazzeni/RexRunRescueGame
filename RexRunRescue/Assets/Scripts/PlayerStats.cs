using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour 
{
	public static int
	Followers,
	Likes,
	XP,
	XPMax,
	PlayerLevelupPoints,
	Treats,
	Tokens; 

	public static int 
	PlayerDistance, 
	newHighDistance, 
	weeklyDistance,
	lastWeeksDistance,
	resetTime; 

	public static string playerName = "Patrick";


	//win prize
	public static int winPrizCount;
	public GameObject prizePanel;
	public Text prizePanelText;

	// Use this for initialization
	void Awake () 
	{
		GetPlayerStats ();
	}

	// Use this for initialization
	void Start () 
	{
		GetPlayerStats ();
		SetDistances ();

		prizePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// test time
		SetDistances ();
		FollowerLevelup ();
		WinWeeklyPrize ();

	}

	public void SavePlayerStats()
	{
		PlayerPrefs.SetString ("playerName", playerName);

		PlayerPrefs.SetInt ("Followes", Followers);
		PlayerPrefs.SetInt ("Likes", Likes);
		PlayerPrefs.SetInt ("XP", XP);
		PlayerPrefs.SetInt ("XPMax", XPMax);
		PlayerPrefs.SetInt ("PlayerLevelupPoints", PlayerLevelupPoints);
		PlayerPrefs.SetInt ("Treats", Treats);
		PlayerPrefs.SetInt ("Tokens", Tokens);

		PlayerPrefs.SetInt ("PlayerDistance", PlayerDistance);
		PlayerPrefs.SetInt ("HighrDistance", newHighDistance);
		PlayerPrefs.SetInt ("WeeklyDistance", weeklyDistance);
		PlayerPrefs.SetInt ("lastWeeksDistance", lastWeeksDistance);
		PlayerPrefs.SetInt ("resetTime", resetTime);

		PlayerPrefs.SetInt ("winPrizCount", winPrizCount);
	}

	void GetPlayerStats()
	{
		playerName = PlayerPrefs.GetString ("playerName", playerName);

		Followers = PlayerPrefs.GetInt ("Followes", Followers);
		Likes = PlayerPrefs.GetInt ("Likes", Likes);
		XP = PlayerPrefs.GetInt ("XP", XP);
		XPMax = PlayerPrefs.GetInt ("XPMax", XPMax);
		PlayerLevelupPoints = PlayerPrefs.GetInt ("PlayerLevelupPoints", PlayerLevelupPoints);
		Treats = PlayerPrefs.GetInt ("Treats", Treats);
		Tokens = PlayerPrefs.GetInt ("Tokens", Tokens);


		PlayerDistance = PlayerPrefs.GetInt ("PlayerDistance", PlayerDistance);
		newHighDistance = PlayerPrefs.GetInt ("HighrDistance", newHighDistance);
		weeklyDistance = PlayerPrefs.GetInt ("WeeklyDistance", weeklyDistance);
		lastWeeksDistance = PlayerPrefs.GetInt ("lastWeeksDistance", lastWeeksDistance);
		resetTime = PlayerPrefs.GetInt ("resetTime", resetTime);

		winPrizCount = PlayerPrefs.GetInt ("winPrizCount", winPrizCount);
	}

	void FollowerLevelup ()
	{
		if(XPMax == 0)
		{
			XPMax = 1;
			Followers++;
		}

		if(XPMax <= XP)
		{
			XPMax *= 2;
			PlayerLevelupPoints++;
			Followers++;
		}
	}

	public void ResetPlayer()
	{
		Followers = 1;
		Likes = 0;
		XP = 0;
		XPMax = 0;
		PlayerLevelupPoints = 0;
		PlayerDistance = 0;
		Treats = 0;
		Tokens = 0;

		weeklyDistance = 0;
		winPrizCount = 0;
	}


	// seting up weekly distance
	void SaveWeeklyDistance ()
	{
		weeklyDistance = PlayerDistance - lastWeeksDistance;
		//Debug.Log ("Weekly" + weeklyDistance);
	}

	void SaveLastWeeksDistance()
	{
		lastWeeksDistance = PlayerDistance - weeklyDistance; 
		//Debug.Log ("last week" + lastWeeksDistance);
	}

	public void SetDistances()
	{
		//reset weekly score every 7 days
		var dayTime = 10000 * System.DateTime.Now.Year + 100 * System.DateTime.Now.Month + System.DateTime.Now.Day;

		//day of the week right now 
		int dayOfWeek = (int)System.DateTime.Now.DayOfWeek;

		// if the curent day and time is more then the saved day DO
		if(dayTime >= resetTime)
		{
			//sets the day to 7 days from now
			resetTime = dayTime + 7 - dayOfWeek;

			//resets players weekly score
			weeklyDistance = 0;
			winPrizCount = 0;
			//saves last weeks score
			SaveLastWeeksDistance();
			//just a note leting the game desiner know this if statement was exicuted 
			//Debug.Log ("weekly");
			//Debug.Log ("update Reset at: " + resetTime);
		}
		//saves players weekly score by taking saved last weeks score and subtracting it from curent over all score
		SaveWeeklyDistance ();
	}

	void WinWeeklyPrize()
	{
		if (weeklyDistance >= 100 && winPrizCount == 0) 
		{
			prizePanel.SetActive (true);
			prizePanelText.text = "You've reached a deistace over 100. Your prize is 100xp";
			XP += 100;
			winPrizCount = 1;
			Debug.Log ("winPrizCount = 1");
		}

		if (weeklyDistance >= 200 && winPrizCount == 1) 
		{
			prizePanel.SetActive (true);
			prizePanelText.text = "You've reached a deistace over 200. Your prize is 100xp";
			XP += 100;
			winPrizCount = 2;
			Debug.Log ("winPrizCount = 2");
		}
		if (weeklyDistance >= 300 && winPrizCount == 2) 
		{
			prizePanel.SetActive (true);
			prizePanelText.text = "You've reached a deistace over 300. Your prize is 100xp";
			XP += 100;
			winPrizCount = 3;
			Debug.Log ("winPrizCount = 3");
		}
		if (weeklyDistance >= 500 && winPrizCount == 3) 
		{
			prizePanel.SetActive (true);
			prizePanelText.text = "You've reached a deistace over 500. Your prize is 100xp";
			XP += 100;
			winPrizCount = 4;
			Debug.Log ("winPrizCount = 4");
		}
		//winPrizCount = 0;

		//Debug.Log (winPrizCount);
	}

	public void ResumeButton()
	{
		prizePanel.SetActive (false);
	}

}
