using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : MonoBehaviour 
{

	public float moveSpeed = 1;

	bool gameStarted = false;

	int moveTypCount = 0;

	public GameObject pickupObj;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(gameStarted == true)
		{
			MoveClaw ();

		}

	}

	//void FixedUpdate()

	public void StartClawMachine()
	{
		if(gameStarted == false && PlayerStats.Tokens > 0)
		{
			gameStarted = true;
			moveTypCount += 1;
			PlayerStats.Tokens -= 1;
		}
	}

	void MoveClaw()
	{
		IfNoTap ();

		if (Input.GetButtonDown ("Fire1") && moveTypCount <= 2) 
		{
			moveTypCount += 1;

		}

		if (moveTypCount == 0 ) {
			transform.position += transform.up * 0;
		}
		else if (moveTypCount == 1 ) {
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		else if (moveTypCount == 2) {
			transform.position += transform.right * moveSpeed * Time.deltaTime;
		}
		else if (moveTypCount == 3 && moveTypCount != 4) {
			transform.position += transform.up * moveSpeed * -1 * Time.deltaTime;
		}
		else if (moveTypCount == 4 ) {
			transform.position += transform.up * moveSpeed * Time.deltaTime;
		}
		else if (moveTypCount == 5) {
			transform.position += transform.right * moveSpeed * -1 * Time.deltaTime;
		}
		else if (moveTypCount == 6) {
			transform.position += transform.forward * moveSpeed * -1 * Time.deltaTime;
		}
		else if (moveTypCount == 7) {
			moveTypCount = 0;
			gameStarted = false;
		}

	}

	void IfNoTap()
	{
		float xPos = this.transform.position.x;
		float yPos = this.transform.position.y;
		float zPos = this.transform.position.z;

		if(zPos >= 9 && moveTypCount == 1)
		{
			moveTypCount = 2;
		}
		if(xPos >= 9 && moveTypCount == 2)
		{
			moveTypCount = 3;
		}
		if(yPos <= 2 && moveTypCount == 3)
		{
			StartCoroutine (GrabItem());
			moveTypCount = 8;
		}
		if(yPos >= 5.3f && moveTypCount == 4)
		{
			moveTypCount = 5;
		}
		if(xPos <= 1 && moveTypCount == 5)
		{
			moveTypCount = 6;
		}
		if(zPos <= 1 && moveTypCount == 6)
		{
			moveTypCount = 7;
		}

		if(zPos <= 1 && zPos <= 1 && moveTypCount == 7)
		{
			if (pickupObj != null) {
				Debug.Log ("letGo");
				pickupObj.GetComponent<LevelObjController> ().ClawLetGo();
			}

		} 
	}

	IEnumerator GrabItem()
	{
		yield return new WaitForSeconds (2);
		moveTypCount = 4;
	}



	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "LevelObject" && pickupObj == null) {
			other.GetComponent<LevelObjController> ().TirggerdByClaw();

			pickupObj = other.gameObject;
			pickupObj.transform.parent = this.transform;


		}

	}


}
