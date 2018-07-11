using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelObjController : MonoBehaviour 
{
	public GameObject Block2;

	public string ThisObjName;

	public AudioSource Squeak1, Squeak2, Squeak3;

	/*
	private bool isQuitting = false;

	void OnApplicationQuit()
	{
		isQuitting = true;
	}

	void OnDestroy()
	{
		if (!isQuitting) 
		{
			//Add Block Destry functions here
			Instantiate (Block2, transform.position, transform.rotation);
		}
	}*/

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (Cleanup());
		//Destroy(gameObject, DelayDestoyTime);
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator Cleanup()
	{

		yield return new WaitForSeconds (120);
		Destroy(gameObject);
		Debug.Log("Cleaned Up");
	}

	public void DestoyObject()
	{
		//Add Block Destry functions here
		Instantiate (Block2, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	public void Enemy()
	{
		PlayerStats.XP++;
		PlayerStats.Likes++;
		PlayerController.Health -= 20;
		Destroy(gameObject);
	}

	public void EnemySpecial()
	{
		PlayerStats.XP++;
		PlayerStats.Likes++;
		Destroy(gameObject);
	}

	public void TirggerdByPlayer()
	{
		// Payer Pickups
		if(ThisObjName == "XP")
		{
			PlayerStats.XP++;
			PlayerStats.Likes++;

			PlayerController.Health += 1;
			PlayRandomAudio();

			Destroy(gameObject);

		}
		if(ThisObjName == "Treat")
		{
			PlayerStats.Treats++;
			PlayerStats.Likes++;

			PlayerController.Health += 1;

			PlayRandomAudio();

			Destroy(gameObject);
		}
		if(ThisObjName == "Token")
		{
			PlayerStats.Tokens++;
			PlayerStats.Likes++;

			PlayerController.Health += 1;

			PlayRandomAudio();

			Destroy(gameObject);
		}
		if(ThisObjName == "Special")
		{
			PlayerController.Health += 10;
			PlayerStats.Likes++;

			PlayRandomAudio();

			Destroy(gameObject);
		}
		if(ThisObjName == "AddHealth")
		{
			if(PlayerController.Health < PlayerController.MaxHealth)
			{
				PlayerController.Health += 5;
			}
			PlayerStats.Likes++;

			PlayRandomAudio();

			Destroy(gameObject);
		}

	}

	public void TirggerdByClaw()
	{
		Debug.Log ("claw");

	}

	public void ClawLetGo()
	{
		Debug.Log ("claw let go");
		Instantiate (Block2, transform.position, transform.rotation);
		Destroy(gameObject);

	}

	public void XPTriggerByItemShoot()
	{
		Debug.Log ("xp item shoot");
		//Instantiate (Block2, transform.position, transform.rotation);
		PlayerStats.XP += Random.Range(1, 20);
		Destroy(gameObject);

	}

	public void TreatTriggerByItemShoot()
	{
		Debug.Log ("treat item shoot");
		PlayerStats.Treats += Random.Range(1, 20);
		//Instantiate (Block2, transform.position, transform.rotation);
		Destroy(gameObject);

	}

	public void TokenTriggerByItemShoot()
	{
		Debug.Log ("token item shoot");
		PlayerStats.Tokens += Random.Range(1, 5);
		//Instantiate (Block2, transform.position, transform.rotation);
		Destroy(gameObject);

	}

	public void TerrierTriggerByItemShoot()
	{
		Debug.Log ("terrier item shoot");

		PlayerPrefs.SetInt ("TerrierBool", 1);
		Destroy(gameObject);

	}

	void PlayRandomAudio()
	{
		//Squeak1.Play ();
		//int num = Random.Range (1, 4);
		int num = System.DateTime.Now.Second;
			
		if (num >= 5 && num < 10 /*|| num >= 15 && num < 20*/ || num >= 25 && num < 30 /*|| num >= 35 && num < 40*/ || num >= 45 && num < 50 || num >= 55 && num < 60) 
		{
			Squeak1.Play ();
		}
		else
		{
			Squeak3.Play ();
			//Squeak2.Play ();
		}/*
		if (num == 3) 
		{
			Squeak3.Play ();
		}
		if (num == 4) 
		{
			Squeak1.Play ();
		}*/
	}
}
