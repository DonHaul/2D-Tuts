using UnityEngine;
using System.Collections;

public class SimplePlayer1 : MonoBehaviour {
	bool isDead;
	public GameObject restartText;

	//Lives
	public int lives;
	public bool isImmune;
	public float immuneCounter;
	public float immuneTime;



	
	Animator anim;
	
		
	//SpeedVariables

	float speed = 5f;
	public float BaseSpeed;
	
	//JumpVariables
	public bool grounded;
	public Transform point1;
	public Transform point2;
	public LayerMask onlyGroundMask;
	public float jumpForce;
	
	public float timer;
	bool canJump;
	public float maxTime = 0.1f;
	
	

	public GameObject jumpsParticles;

	
	
	
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	
	void Update () {


		if (isImmune) {

			immuneCounter -= Time.deltaTime;

				}
		if (immuneCounter <= 0) {

			isImmune=false;
			immuneCounter=immuneTime;
			anim.SetBool("Immune",false);
				}


		
				if (isDead == true) {
			
						restartText.SetActive (true);
						if (Input.GetKeyDown (KeyCode.R))
								Application.LoadLevel (Application.loadedLevel);
			
			
						return;
			
				}


		if (!grounded && (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)))
						BaseSpeed = 0;

		
				//MOVING CODE
		
				anim.SetFloat ("velocityY", GetComponent<Rigidbody2D>().velocity.y);
		
				if (Input.GetKey (KeyCode.A)) {
						anim.SetBool ("Moving", true);
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed + BaseSpeed, GetComponent<Rigidbody2D>().velocity.y);
						transform.localScale = new Vector3 (-1, 1, 1);
				
				} else if (Input.GetKey (KeyCode.D)) {
						anim.SetBool ("Moving", true);
			GetComponent<Rigidbody2D>().velocity = new Vector2 (speed + BaseSpeed, GetComponent<Rigidbody2D>().velocity.y);
						transform.localScale = new Vector3 (1, 1, 1);

				} else {
						anim.SetBool ("Moving", false);
						GetComponent<Rigidbody2D>().velocity = new Vector2 (BaseSpeed, GetComponent<Rigidbody2D>().velocity.y);
				}
		
				//JUMPCODE
				grounded = Physics2D.OverlapArea (point1.position, point2.position, onlyGroundMask);
		
		
		
				if (grounded && Input.GetKeyDown (KeyCode.W)) {
						timer = 0;
						canJump = true;
						GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpForce * 3));
				} else if (Input.GetKey (KeyCode.W) && canJump && timer < maxTime) {
						timer += Time.deltaTime;
						GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpForce));
				} else {
						canJump = false;
				}
				anim.SetBool ("Grounded", grounded);




	}
		
		

	
	
	
	
	
	
	
		
	

	void OnTriggerStay2D(Collider2D other)
	{
				if (other.tag == "deadly" && !isDead && lives <=1 && !isImmune) {
						GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			lives=0;
						anim.SetBool ("Dies", true);
						GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 500));
						isDead = true;
			
			
				} else if (other.tag == "deadly" && lives > 1 && !isImmune) {
			lives--;
			anim.SetBool("Immune",true);
			isImmune=true;
				}

	}


	
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "deadly" && !isDead && lives <=1 && !isImmune) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			lives=0;
			anim.SetBool ("Dies", true);
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 500));
			isDead = true;
			
			
		} else if (other.gameObject.tag == "deadly" && lives > 1 && !isImmune) {
			lives--;
			anim.SetBool("Immune",true);
			isImmune=true;
		}
		
	}





	void OnCollisionEnter2D(Collision2D other)
	{




		if (other.gameObject.tag == "Platform")
						BaseSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity.x;
		else 
					BaseSpeed = 0;
						
	}
	
	void OnCollisionExit2D(Collision2D other)
	{

	}

	void OnGUI(){
		GUILayout.Label ("  Lives: " + lives);

	}

}
