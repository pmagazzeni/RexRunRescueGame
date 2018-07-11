using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStats : MonoBehaviour 
{
	public static string FaceItemName, NeckItemName, UpperBodyItemName, FeetItemName;

	// Use this for initialization
	void Start () 
	{
		GetInventoyStats ();
		//Debug.Log (FaceItemName);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SaveFaceInventory(string ItemName)
	{
		PlayerPrefs.SetString ("FaceItem", ItemName);
	}

	public void SaveNeckInventory(string ItemName)
	{
		PlayerPrefs.SetString ("NeckItem", ItemName);
	}

	public void SaveUpperBodyInventory(string ItemName)
	{
		PlayerPrefs.SetString ("UpperBodyItem", ItemName);
	}

	public void SaveFeetInventory(string ItemName)
	{
		PlayerPrefs.SetString ("FeetItem", ItemName);
	}

	void GetInventoyStats()
	{
		FaceItemName = PlayerPrefs.GetString ("FaceItem", FaceItemName);
		NeckItemName = PlayerPrefs.GetString ("NeckItem", NeckItemName);
		UpperBodyItemName = PlayerPrefs.GetString ("UpperBodyItem", UpperBodyItemName);
		FeetItemName = PlayerPrefs.GetString ("FeetItem", FeetItemName);
	}


}
