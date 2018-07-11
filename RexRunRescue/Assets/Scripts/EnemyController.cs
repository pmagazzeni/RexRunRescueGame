using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public bool enemyTypeRandom;

	public int enemyType;

	public GameObject Player;
	private Vector3 playerPos;

	public float enemySpeed; 

	public float waitTime;

	float xPos;
	float yPos;
	float zPos;
	public bool moveUp = false;

	// Use this for initialization
	void Start () 
	{
		SetEnemy ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		xPos = this.transform.position.x;
		yPos = this.transform.position.y;
		zPos = this.transform.position.z;

		playerPos = GameObject.FindWithTag ("Player").transform.position;

		ControlEnemy ();

	}

	void SetEnemy ()
	{
		if(enemyTypeRandom == true)
			{
				enemyType = Random.Range (1, 4);
			}
		

		if(enemyType == 2)
		{
			enemySpeed = (float)Random.Range (1, 10);
			waitTime  = (float)Random.Range (1, 10);
			StartCoroutine (LookAtDelay ());
		}

		if(enemyType == 3)
		{
			enemySpeed = (float)Random.Range (1, 10);
		}
		else
		{
			enemySpeed = (float)Random.Range (1, 5);
		}
	}


	void ControlEnemy()
	{
		if(enemyType == 1)
		{
			moveTypeForward();
		}

		if(enemyType == 2)
		{
			moveTypeForward();
		}

		if(enemyType == 3)
		{
			
			if (yPos > enemySpeed) 
			{
				moveUp = false;
			}
			if (yPos < 1) 
			{
				moveUp = true;
			}

			if (moveUp == true) {
				moveTypeUp ();
			}
			if (moveUp == false) {
				moveTypeDown ();
			}

		}
	}


	//StartCoroutine (LookAtDelay());
	IEnumerator LookAtDelay()
	{
		yield return new WaitForSeconds (waitTime);
		LookAtPlayer (); 
		StartCoroutine (LookAtDelay ());
	}

	void moveTypeUp()
	{
		transform.position += transform.up * enemySpeed * Time.deltaTime;
	}
	void moveTypeDown()
	{
		transform.position += transform.up * enemySpeed * -1 * Time.deltaTime;
	}
	void moveTypeForward()
	{
		transform.position += transform.forward * enemySpeed * Time.deltaTime;
	}
	void moveTypeBack()
	{
		transform.position += transform.forward * enemySpeed * -1 * Time.deltaTime;
	}
	void LookAtPlayer()
	{
		transform.LookAt (playerPos);
	}




}
