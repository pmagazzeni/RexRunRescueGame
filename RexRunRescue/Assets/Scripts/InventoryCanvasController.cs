using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvasController : MonoBehaviour 
{
	public GameObject lockedButtons;
	public GameObject unlockedButtons;

	public int isLocked;
	public int price;

	public string itemName;
	// Use this for initialization
	void Start () 
	{
		GetItemBool ();
		if (isLocked == 0) 
		{
			lockedButtons.SetActive (true);
			unlockedButtons.SetActive(false);
		}
		if (isLocked == 1) 
		{
			lockedButtons.SetActive (false);
			unlockedButtons.SetActive(true);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void GetItemBool()
	{
		isLocked = PlayerPrefs.GetInt (itemName + "Bool", isLocked);
	}

	void SetItemBool()
	{
		PlayerPrefs.SetInt (itemName + "Bool", isLocked);
	}

	public void BuyItem()
	{
		if (PlayerStats.Treats >= price) 
		{
			lockedButtons.SetActive (false);
			unlockedButtons.SetActive(true);
			isLocked = 1;
			SetItemBool ();
			PlayerStats.Treats -= price;
		}
	}

	public void UnbuyItem()
	{
		isLocked = 0;
		SetItemBool ();
		lockedButtons.SetActive (true);
		unlockedButtons.SetActive(false);
	}
}
