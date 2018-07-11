using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpController : MonoBehaviour 
{
	public float DelayDestoyTime;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (Cleanup());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Cleanup()
	{

		yield return new WaitForSeconds (DelayDestoyTime);
		Destroy(gameObject);
		Debug.Log("Cleaned Up");
	}
}
