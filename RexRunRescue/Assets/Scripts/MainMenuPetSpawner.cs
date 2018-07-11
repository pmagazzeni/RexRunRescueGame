using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPetSpawner : MonoBehaviour 
{
	public GameObject[] MainMenuPet;
	public string PetName;

	//public int arrayInt;

	void Awake() 
	{
		
	}

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (LateStart ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator LateStart ()
	{
		yield return new WaitForSeconds (0.25f);
		PetName = PetsStat.SelectedPetName;
		SpawnMenuPet ();
	}

	public void SpawnMenuPet()
	{
		PetName = PetsStat.SelectedPetName;

		Destroy (GameObject.FindWithTag("Pet"));

		if (PetName == "Rex") 
		{
			Instantiate (MainMenuPet[0], transform.position, transform.rotation);
		}
		if (PetName == "Lincoln") 
		{
			Instantiate (MainMenuPet[1], transform.position, transform.rotation);
		}
		if (PetName == "Tucker") 
		{
			Instantiate (MainMenuPet[2], transform.position, transform.rotation);
		}
		if (PetName == "Poppy") 
		{
			Instantiate (MainMenuPet[3], transform.position, transform.rotation);
		}
		if (PetName == null)
		{
			Instantiate (MainMenuPet[4], transform.position, transform.rotation); 
		}
	}

}
