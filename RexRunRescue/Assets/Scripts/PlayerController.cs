using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class PlayerController : MonoBehaviour 
{
	CharacterController MyController;
	public float GravityForce;
	public float ySpeed;
	public float JumpForce;
	public float HangTime;
	public float HangTimer;
	public float GravityModifier; 
	public float ForwardSpeed;
	public float RunSpeed;
	public float LerpTime;

	public static float Health, Stamina, MaxHealth;

	//Distance
	int myDistance;
	int oldDistance;
	int oldDistance2;
	public static int highDistance = 0;

	public AudioSource RexBark1;
	public AudioSource RexBarkGrall1;
	public AudioSource RexFeetRun1;

	public bool playerIsAliveBool = true;

	//Animation
	public Animator myAnimator;

	//wall jump
	private Quaternion MyRotation;

	// Special Pickup
	//public static int specialCount;// coinScore;
	//public Text coinText;
	//public GameObject CoinScore;

	//level settings
	public int deadZone;
	public static bool isAlive = true;
	//public GameObject gameOverText;

	//get game1camvas 
	public GameObject gm1CvsObj;

	//Hud Text
	public Text HudText;
	public GameObject HunTextObj;

	public Text StamText;
	public GameObject StamTextObj;

	public bool isMoving;
	float moveNum4;

	public Rigidbody rb;
  

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1;
		//specialCount = 0;
		HunTextObj = GameObject.Find("Canvas/MenusPanel/PlayPanel/DistanceHud");
		HudText = HunTextObj.GetComponent<Text> ();

		StamTextObj = GameObject.Find("Canvas/MenusPanel/PlayPanel/StamObject/StamText");
		StamText = StamTextObj.GetComponent<Text> ();


		MyController = GetComponent<CharacterController> ();
		MyRotation = transform.rotation;

		GetPetStats ();
		isAlive = true;
		Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetDistance();
		IsDeadIf ();

		HudText.text = "High Distance: " + PlayerStats.newHighDistance
			+ "\nDistance: " + highDistance
			+ "\nTreats: " + PlayerStats.Treats;

		StamText.text = "Stamina: " + (int)Health + "/" + (int)MaxHealth;

		//set New High Score
		SaveHighDistance ();
		DrainStamina ();


		if (MyController.isGrounded) 
		{
			if (!RexFeetRun1.isPlaying) 
			{

				if (rb.IsSleeping () == false && playerIsAliveBool == true) {
					PlayRexRunAudio ();
				}
				else if (rb.IsSleeping () == false && playerIsAliveBool == false) {
					StopRexRunAudio();
				}
			}


		}
		else 
		{
			StopRexRunAudio (); 
		}

		if(rb.IsSleeping () == true)
		{
			StopRexRunAudio (); 
		}
		//Debug.Log (rb.IsSleeping());
		//rb.IsSleeping ();
	} 

	void FixedUpdate () 
	{
		myAnimator.SetBool ("IsGrounded", MyController.isGrounded);

		MyGravity ();
		Jump ();
		ForwardMovement ();
		SpeedApply ();

	}

	void MyGravity()
	{
		ySpeed = MyController.velocity.y;
		ySpeed -= GravityForce * Time.deltaTime;
	}

	void Jump()
	{
		if (Input.GetButton ("Fire1")) 
		{
			if (MyController.isGrounded) {
				HangTimer = HangTime;
				ySpeed = JumpForce;
			} 
			else 
			{
				if (HangTimer > 0) 
				{
					HangTimer -= Time.deltaTime;
					ySpeed += GravityModifier * HangTimer * Time.deltaTime;
				}
			}

		}
		if (Input.GetButtonDown ("Fire1")) 
		{
			PlayRandomBarkAudio ();
		}
	}

	void ForwardMovement()
	{
		if(MyController.isGrounded)
		{
			if (ForwardSpeed <= RunSpeed - 0.1f || ForwardSpeed >= RunSpeed + 0.1f)
				ForwardSpeed = Mathf.Lerp (ForwardSpeed, RunSpeed, LerpTime);
			else
				ForwardSpeed = RunSpeed;
			
		}
	}

	void SpeedApply()
	{
		MyController.Move (transform.forward * ForwardSpeed * Time.deltaTime);
		myAnimator.SetFloat ("xSpeed", MyController.velocity.x);
		MyController.Move (new Vector3(0,ySpeed,0)*Time.deltaTime);
		myAnimator.SetFloat ("ySpeed", MyController.velocity.y);



	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		GroundLanding ();
		WallJump (hit);
	}

	void WallJump(ControllerColliderHit hitSent)
	{
		if(!MyController.isGrounded && hitSent.normal.y < 0.1f && hitSent.normal.y > -0.1f)
		{

			//StopRexRunAudio ();
			
			myAnimator.SetBool ("IsWall", true);
			{
				if (Input.GetButtonDown ("Fire1")) {
					myAnimator.SetBool ("IsWall", false);
					transform.forward = hitSent.normal;
					transform.rotation = Quaternion.Euler (new Vector3 (0, transform.rotation.eulerAngles.y, 0));
					ForwardSpeed = RunSpeed;
					HangTimer = HangTime;
					ySpeed = JumpForce;
				}
			}
		}
	}

	void GroundLanding()
	{
		if (MyRotation != transform.rotation && MyController.isGrounded) 
		{
			myAnimator.SetBool ("IsWall", false);
			transform.rotation = MyRotation;
			PlayRexRunAudio ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "LevelObject") 
		{
			other.GetComponent<LevelObjController>().TirggerdByPlayer();
		}

		if (other.transform.tag == "Block") 
		{
			if (Special.SpecialActive == true) 
			{
				//Destroy (other.gameObject);
				other.GetComponent<LevelObjController>().DestoyObject();
			}
		}

		if (other.transform.tag == "Enemy1") 
		{
			if (Special.SpecialActive == true) {
				//Destroy (other.gameObject);
				other.GetComponent<LevelObjController> ().EnemySpecial();
			} 
			else 
			{
				other.GetComponent<LevelObjController> ().Enemy();
			}
		}

		if (other.transform.tag == "DeathZone") 
		{
			playerIsAliveBool = false;
			StopRexRunAudio ();
			Dead ();
		}
	}

	IEnumerator Death()
	{
		 
		yield return new WaitForSeconds (1);
		//load scene overworld or deathpanal
		//Debug.Log("Game Over");
	}

	public void GetDistance()
	{
		float DistanceFloat = this.transform.position.x;


		myDistance = oldDistance + (int)DistanceFloat;

		if (highDistance < myDistance && isAlive == true) 
		{
			highDistance = myDistance;
			//coinText.text = "Distance: " + highDistance.ToString ();
		}


		//Debug.Log ("DF" + (int)DistanceFloat + "MD" + myDistance);
		//distance is more or less move is true if 0 false
		float moveNum1 = oldDistance2 - DistanceFloat;
		float moveNum = moveNum1;

		float moveNum3 = oldDistance2 * 100 + moveNum;
		moveNum4 = moveNum3;
		oldDistance2 = myDistance;


		if (moveNum4 == moveNum3) {
			//StopRexRunAudio ();
		} 
		//Debug.Log (moveNum4);

	}

	void GetPetStats()
	{
		RunSpeed = PetsStat.Speed * 0.1f + 4;
		JumpForce = PetsStat.JumpHeight * 0.1f + 4;
		MaxHealth = PetsStat.MaxHealth * 100;

	}

	public void SaveThisDistance()
	{
		if (isAlive == true) 
		{
			PlayerStats.PlayerDistance = PlayerStats.PlayerDistance + highDistance;
			GameObject.Find ("Canvas").GetComponent<PlayerStats>().SavePlayerStats();

		}
		//highDistance  ;
	}

	void IsDeadIf()
	{
		float yPos = this.transform.position.y;

		if (yPos <= deadZone) 
		{
			Dead ();
		}

		if (Health <= 0) 
		{
			Dead ();
		}
	}

	void Dead()
	{
		SaveThisDistance ();

		GameObject.Find ("Canvas").GetComponent<Game1Canves>().IfPetIsDead ();
		isAlive = false;
		//gameOverText.SetActive (true);
		Time.timeScale = 0.25f;

		StartCoroutine (Death ());
	}

	void SaveHighDistance ()
	{
		if(PlayerStats.newHighDistance < myDistance)
		{
			PlayerStats.newHighDistance = myDistance;
		}
	}

	void DrainStamina()
	{
		if (Health > MaxHealth) 
		{
			Health = MaxHealth;
		}

		// health = stamina
		Health -= 2.0f * Time.deltaTime;
	}

	/*
	void SaveWeeklyDistance ()
	{

	}*/

	/* //This Will delete all saved progres
	public void DeletePrefs()
	{
		PlayerPrefs.DeleteAll();
	}*/

	void PlayRandomBarkAudio()
	{
		//RexBark1.Play ();

		//int num = Random.Range (1, 3);

		int num = System.DateTime.Now.Second;
		//Debug.Log (num);


		if (num >= 5 && num < 10 /*|| num >= 15 && num < 20*/ || num >= 25 && num < 30 /*|| num >= 35 && num < 40*/ || num >= 45 && num < 50 || num >= 55 && num < 60)  
		{
			RexBarkGrall1.Play ();
		}
		else 
		{
			RexBark1.Play ();
		}
	}

	void PlayRandomBarkGrallAudio() 
	{
		RexBarkGrall1.Play ();

	}

	void PlayRexRunAudio()
	{
		RexFeetRun1.Play ();
	}

	void StopRexRunAudio()
	{
		RexFeetRun1.Stop ();
	}

}
