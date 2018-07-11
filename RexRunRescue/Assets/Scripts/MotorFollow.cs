using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFollow : MonoBehaviour 
{

	public GameObject claw;

	//private Vector3 offset;

	private float xOffset, zOffset;

	void Start()
	{
		xOffset = transform.position.x;
		zOffset = transform.position.z;
	}

	void Update()
	{
		SetMotorPosition ();
	}

	void SetMotorPosition ()
	{
		transform.position = new Vector3 (claw.transform.position.x, 6.5f, claw.transform.position.z);
	}
}
 