using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetSpawner : MonoBehaviour 
{
	public string PetName;

	public GameObject 
	RexPreFab, 
	LincolnPreFab, 
	TuckerPreFab, 
	PoppyPreFab; // add later // , CustomPreFab;


	void Awake()
	{
		
		PetName = PetsStat.SelectedPetName;

		if (PetName == "Rex") 
		{
			Instantiate (RexPreFab, transform.position, transform.rotation);
		}
		if (PetName == "Lincoln") 
		{
			Instantiate (LincolnPreFab, transform.position, transform.rotation);
		}
		if (PetName == "Tucker") 
		{
			Instantiate (TuckerPreFab, transform.position, transform.rotation);
		}
		if (PetName == "Poppy") 
		{
			Instantiate (PoppyPreFab, transform.position, transform.rotation);
		}
		if (PetName == null)
		{
			SceneManager.LoadScene ("MainMenu"); 
		}
	}

	// Use this for initialization
	void Start () 
	{
		//Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
