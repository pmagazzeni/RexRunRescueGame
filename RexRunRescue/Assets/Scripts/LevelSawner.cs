using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSawner : MonoBehaviour 
{
	public GameObject LevelSelection;

	public GameObject[] LevelSelectionArr;

	int RandomNum, playerDistance, spawnDistance = 0;

	public int arraySize;

	public int Date;

	// Use this for initialization
	void Start () 
	{
		Date = 10000 * System.DateTime.Now.Year + 100 * System.DateTime.Now.Month + System.DateTime.Now.Day;
		PlayerController.highDistance = 0;
		Random.seed = Date;


	}
	
	// Update is called once per frame
	void Update () 
	{
		playerDistance = PlayerController.highDistance;
		SpawnRandomLevelSection ();

		//Debug.Log (System.DateTime.Today);
	}

	void SpawnRandomLevelSection()
	{
		if (playerDistance == spawnDistance) 
		{
			PlayerStats.XP += 10;
			//RandomNum = Random.Range (0, arraySize);
			RandomNum = Random.Range (0, arraySize);
			//Debug.Log (RandomNum + " " + playerDistance);

			//Debug.Log (RandomNum);
			LevelSelection = LevelSelectionArr [RandomNum];

			if(arraySize == arraySize)
			{
				RandomNum = 0;
			}

			Instantiate (LevelSelection, new Vector3((float)spawnDistance + 15f,0,0), Quaternion.identity);
			spawnDistance += 15;

		}

	}
}
