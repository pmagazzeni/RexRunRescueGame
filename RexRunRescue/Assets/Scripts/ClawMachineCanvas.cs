using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClawMachineCanvas : MonoBehaviour 
{
	public Text HUDText; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HUDText.text = "Player Name" 
			+ "\nFollower: " + PlayerStats.Followers 
			+ "\nLikes: " + PlayerStats.Likes 
			+ "\nXP: " + PlayerStats.XP + "/" + PlayerStats.XPMax
			+ "\nTreats: " + PlayerStats.Treats 
			+ "\nTokens: " + PlayerStats.Tokens;
	}
}
