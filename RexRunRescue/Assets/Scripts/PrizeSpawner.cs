using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeSpawner : MonoBehaviour 
{
	public GameObject prize; 
	public GameObject[] prizeArr; 

	public int prizeItemNum;
	public float xSpawnZone, zSpawnZone;

	// Use this for initialization
	void Start () 
	{
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
		SpawnRandomPrize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnRandomPrize()
	{
		prizeItemNum = Random.Range (0, 4);

		xSpawnZone = Random.Range (2.0f, 9.0f);
		zSpawnZone = Random.Range (2.0f, 9.0f);

		prize = prizeArr [prizeItemNum];

		Instantiate (prize, new Vector3((float)xSpawnZone, 1f, (float)zSpawnZone), Quaternion.identity);

		StartCoroutine (SpawnItem());
	}

	IEnumerator SpawnItem()
	{
		yield return new WaitForSeconds (60);
		SpawnRandomPrize ();
	}
}
