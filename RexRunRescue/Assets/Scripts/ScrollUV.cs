using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour {

	public float parralax;
	public float parralay;

	// Use this for initialization
	/*void Start () {
		
	}*/

	// Update is called once per frame
	void Update () 
	{
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;

		offset.x = transform.position.x / transform.localScale.x * parralax;
		offset.y = transform.position.y / transform.localScale.y * parralay;

		mat.mainTextureOffset = offset; 

	}
}
