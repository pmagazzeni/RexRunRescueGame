using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendWeeklyController : MonoBehaviour 
{
	public Text [] playerInPlaceText;

	string[] friend; 

	int[] friendScore;

	int friendInt = 0;

	int prizeInt1 = 0;
	int prizeInt2 = 0;
	int prizeInt3 = 0;
	int prizeInt4 = 0;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		int[] friendScore = new int[] { 101, 202, 303, 404, 505, 606, 77, 88, 90, PlayerStats.weeklyDistance, 100, 200, 300, 500};
		string[] friend = new string[] { "Jason", "Mike", "Phil", "Joe", "Dave", "Aaron", "Bob", "Logan", "Sam", "Mike" , "Bill", "Anna", "Frank", "Fred"};

		System.Array.Sort(friendScore);

		if(friendScore [friendInt] < PlayerStats.weeklyDistance)  
		{
			friendInt++;
		}

		if(friendScore [prizeInt1] < 100)  
		{
			prizeInt1++;
		}

		if(friendScore [prizeInt2] < 200)  
		{
			prizeInt2++;
		}
		if(friendScore [prizeInt3] < 300)  
		{
			prizeInt3++;
		}
		if(friendScore [prizeInt4] < 500)  
		{
			prizeInt4++;
		}

		friend [friendInt] = PlayerStats.playerName;
		friend [prizeInt1] = "Prize 1";
		friend [prizeInt2] = "Prize 2";
		friend [prizeInt3] = "Prize 3";
		friend [prizeInt4] = "Prize 4";


		playerInPlaceText[0].text = friend [0] + "\n" + friendScore [0];
		playerInPlaceText[1].text = friend [1] + "\n" + friendScore [1]; 
		playerInPlaceText[2].text = friend [2] + "\n" + friendScore [2];
		playerInPlaceText[3].text = friend [3] + "\n" + friendScore [3];
		playerInPlaceText[4].text = friend [4] + "\n" + friendScore [4];
		playerInPlaceText[5].text = friend [5] + "\n" + friendScore [5];
		playerInPlaceText[6].text = friend [6] + "\n" + friendScore [6];
		playerInPlaceText[7].text = friend [7] + "\n" + friendScore [7];
		playerInPlaceText[8].text = friend [8] + "\n" + friendScore [8];
		playerInPlaceText[9].text = friend [9] + "\n" + friendScore [9];
		playerInPlaceText[10].text = friend [10] + "\n" + friendScore [10];
		playerInPlaceText[11].text = friend [11] + "\n" + friendScore [11];
		playerInPlaceText[12].text = friend [12] + "\n" + friendScore [12];
		playerInPlaceText[13].text = friend [13] + "\n" + friendScore [13];

		//SetPlayerScore ();
		//Debug.Log (friendScore [friendInt]);



	}

	public void SetPlayerScore()
	{
		//Debug.Log (friendScore [friendInt]);
		/*
		if(friendScore [friendInt] < PlayerStats.weeklyDistance) 
		{
			friendInt++;
			Debug.Log (friendScore [friendInt]);
			friendScore [friendInt] = PlayerStats.weeklyDistance;
		}*/
		//Debug.Log (friendInt);

	}
}
