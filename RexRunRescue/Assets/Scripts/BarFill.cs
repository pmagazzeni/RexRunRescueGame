using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour 
{

	public Image FillBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FillBar.fillAmount = PlayerController.Health / PlayerController.MaxHealth;
	}
}
