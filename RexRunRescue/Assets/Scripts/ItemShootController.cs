using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShootController : MonoBehaviour 
{
	public GameObject pickupObj; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.tag == "XP") {
			other.GetComponent<LevelObjController> ().XPTriggerByItemShoot();

			pickupObj = other.gameObject;
			pickupObj.transform.parent = this.transform;
		}

		if (other.transform.tag == "Treats") {
			other.GetComponent<LevelObjController> ().TreatTriggerByItemShoot();

			pickupObj = other.gameObject;
			pickupObj.transform.parent = this.transform;
		}

		if (other.transform.tag == "Token") {
			other.GetComponent<LevelObjController> ().TokenTriggerByItemShoot();

			pickupObj = other.gameObject;
			pickupObj.transform.parent = this.transform;
		}

		if (other.transform.tag == "Pet") {
			other.GetComponent<LevelObjController> ().TerrierTriggerByItemShoot();

			pickupObj = other.gameObject;
			pickupObj.transform.parent = this.transform;
		}
	}
}
