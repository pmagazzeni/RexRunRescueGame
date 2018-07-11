using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public GameObject player;
	private float xDelta;
	private float yCamera;
	private float zCamera;

	public float yDelta;
	// Use this for initialization



	void Awake()
	{
		//player = GameObject.FindWithTag ("Player");
	}
		
	void Start () 
	{
		player = GameObject.FindWithTag ("Player");

		xDelta = Mathf.Abs (player.transform.position.x - transform.position.x);
		yCamera = transform.position.y;
		zCamera = transform.position.z;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		player = GameObject.FindWithTag ("Player");

		if(PlayerController.isAlive)
		{
			YFollow ();
			SetCameraPosition ();
		}

	}

	void SetCameraPosition()
	{
		transform.position = new Vector3 (player.transform.position.x + xDelta, yCamera,zCamera);
	}

	void YFollow()
	{
		if (player.transform.position.y < transform.position.y - yDelta) {
			yCamera = player.transform.position.y + yDelta;
		} 
		else if(player.transform.position.y > transform.position.y + yDelta)
		{
			yCamera = player.transform.position.y - yDelta;
		}
	}
}
