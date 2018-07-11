using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInventory : MonoBehaviour 
{
	public GameObject InventoryItem;
	public GameObject[] InventoryItemArr;

	public string oldItemName, ItemName;

	public string ObjItemName; 

	public int ItemNum;

	public bool IsButton;

	//public bool 

	// Use this for initialization
	void Start () 
	{
		if (IsButton == false) 
		{
			SpawnItem ();
			InventoryItem = GameObject.FindWithTag (oldItemName);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		//SpawnItem ();
	}

	public void SpawnInventoryItem(int ItemNum) 
	{
		//ItemNum = 
		SpawnItem ();

	}

	public void SpawnItem()
	{
		if (ItemName == "Face") 
		{
			ObjItemName = PlayerPrefs.GetString ("FaceItem", ObjItemName);

			if(ObjItemName == "SunGlassesBlack")
			{
				ItemNum = 0;
			}
			if(ObjItemName == "SunGlassesBlue")
			{
				ItemNum = 1;
			}
			if(ObjItemName == "SunGlassesGreen")
			{
				ItemNum = 2;
			}
		}

		if (ItemName == "Neck") 
		{
			ObjItemName = PlayerPrefs.GetString ("NeckItem", ObjItemName);

			if(ObjItemName == "HankyBlack")
			{
				ItemNum = 0;
			}
			if(ObjItemName == "HankyBlue")
			{
				ItemNum = 1;
			}
			if(ObjItemName == "HankyGreen")
			{
				ItemNum = 2;
			}
		}

		if (ItemName == "Back") 
		{
			ObjItemName = PlayerPrefs.GetString ("UpperBodyItem", ObjItemName);
			if(ObjItemName == "BeltBlack")
			{
				ItemNum = 0;
			}
			if(ObjItemName == "BeltBlue")
			{
				ItemNum = 1;
			}
			if(ObjItemName == "BeltGreen")
			{
				ItemNum = 2;
			}
		}

		if (ItemName == "Feet") 
		{
			ObjItemName = PlayerPrefs.GetString ("FeetItem", ObjItemName);
			if(ObjItemName == "FeetBlack")
			{
				ItemNum = 0;
			}
			if(ObjItemName == "FeetBlue")
			{
				ItemNum = 1;
			}
			if(ObjItemName == "FeetGreen")
			{
				ItemNum = 2;
			}
		}
		

		if (InventoryItem != null) 
		{
			InventoryItem = GameObject.FindWithTag (oldItemName);
			Destroy (InventoryItem);
		}

		InventoryItem = InventoryItemArr[ItemNum];
		GameObject parentObj = (GameObject)Instantiate (InventoryItem, transform.position, transform.rotation);
		parentObj.transform.parent = transform;
		InventoryItem = GameObject.FindWithTag (oldItemName);

	}
}
