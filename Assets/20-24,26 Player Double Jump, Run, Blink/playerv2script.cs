using UnityEngine;
using System.Collections;

public class playerv2script : MonoBehaviour {


	public AudioClip[] audioClip;



	bool isDead;
	public GameObject restartText;

	Animator anim;

	//BlinkVariables
	public float blinkDistance;
	float blinkTimer;
	public float blinkTime = 1f;
	bool facingRight;
	bool canBlink=true;


	//SpeedVariables
	public float initialSpeed=5f;
	public float runMultiplier;
	float speed = 5f;
	public GameObject runParticles;

	//JumpVariables
	public bool grounded;
	public Transform point1;
	public Transform point2;
	public LayerMask onlyGroundMask;
	public float jumpForce;

	public float timer;
	bool canJump;
	public float maxTime = 0.1f;


	public int TotalJumps=2;
	public int curJumps;
	public GameObject jumpsParticles;
	public Transform playersfeet;




	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	void Update () {


		if (isDead == true) {
						
			restartText.SetActive(true);
			if(Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(Application.loadedLevel);


			return;

			}

				//BLINK CODE
				if (Input.GetKeyDown (KeyCode.J) && canBlink) {
			PlaySound(0);
						anim.SetBool ("Blink", true);
						canBlink = false;
				} else
						anim.SetBool ("Blink", false);

				if (!canBlink) {
						blinkTimer += Time.deltaTime;
				}

				if (blinkTimer > blinkTime) {

						canBlink = true;
						blinkTimer = 0;
				}


				if (transform.localScale.x == 1)
						facingRight = true;
				else
						facingRight = false;


				//SPRINT CODE
				speed = Input.GetKey (KeyCode.LeftShift) ? initialSpeed * runMultiplier : initialSpeed;

				if (Input.GetKey (KeyCode.LeftShift) && grounded && GetComponent<Rigidbody2D>().velocity.x != 0) {
						runParticles.SetActive (true);
						anim.SetBool ("Run", true);
				} else {
						runParticles.SetActive (false);
						anim.SetBool ("Run", false);
				}

				//MOVING CODE

				anim.SetFloat ("velocityY", GetComponent<Rigidbody2D>().velocity.y);

				if (Input.GetKey (KeyCode.A)) {
						anim.SetBool ("Moving", true);
						GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D>().velocity.y);
						transform.localScale = new Vector3 (-1, 1, 1);
						runParticles.transform.rotation = Quaternion.Euler (new Vector3 (345, 90, -90));	
				} else if (Input.GetKey (KeyCode.D)) {
						anim.SetBool ("Moving", true);
						GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
						transform.localScale = new Vector3 (1, 1, 1);
						runParticles.transform.rotation = Quaternion.Euler (new Vector3 (345, 270, 90));
				} else {
						anim.SetBool ("Moving", false);
						GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
				}

				//JUMPCODE
				grounded = Physics2D.OverlapArea (point1.position, point2.position, onlyGroundMask);



		if(Input.GetKeyDown(KeyCode.W)&& !grounded && curJumps>0)
		{
			PlaySound(1);
			Instantiate(jumpsParticles,playersfeet.position,Quaternion.identity);
			curJumps--;
			timer = 0;
			canJump = true;
			GetComponent<Rigidbody2D>().velocity=new Vector2(GetComponent<Rigidbody2D>().velocity.x,3);


				}
			else if (grounded && Input.GetKeyDown (KeyCode.W)) {
			PlaySound(1);
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


		if (grounded)
						curJumps = TotalJumps;


		}







	void Blink()
	{
		Vector3 blink;
		if(facingRight)
			blink = new Vector3(blinkDistance,0,0);
		else
			blink = new Vector3(-blinkDistance,0,0);

		transform.position += blink;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "deadly" && !isDead) {
			GetComponent<Rigidbody2D>().velocity=Vector2.zero;

			anim.SetBool("Dies",true);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,500));
			isDead=true;

			
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "deadly" && !isDead) {
			GetComponent<Rigidbody2D>().velocity=Vector2.zero;
			
			anim.SetBool("Dies",true);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,500));
			isDead=true;
			
			
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "deadly" && !isDead) {
			GetComponent<Rigidbody2D>().velocity=Vector2.zero;
			
			anim.SetBool("Dies",true);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,500));
			isDead=true;
			
			
		}
	}


	void PlaySound(int clip)
	{
		GetComponent<AudioSource>().clip = audioClip [clip];
		GetComponent<AudioSource>().Play ();


		}

}
