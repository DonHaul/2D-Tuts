using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SimplePlayer0 : MonoBehaviour {
	public bool isDead;
	public GameObject restartText;

	//Lives
	public int lives;
	public bool isImmune;
	
	public float immuneTime;

	public bool outsideForce;

	//FOR QUICKSAND





	public Animator anim;
		public Rigidbody2D rb;
	
		
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
	

		float previousAxispos;
	

	public GameObject jumpsParticles;

	
	
	
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
		IEnumerator ImmuneTime()
		{
				yield return new WaitForSeconds (immuneTime);
				isImmune=false;

				anim.SetBool("Immune",false);
		}

	
	void Update () {


		


		
				if (isDead == true) {
		
						if (Input.GetButtonDown ("Restart"))
								SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			
			
						return;
			
				}


				if (!grounded && Input.GetAxisRaw ("Horizontal")!=previousAxispos) {
						BaseSpeed = 0;
						outsideForce = false;
				}
				previousAxispos = Input.GetAxisRaw ("Horizontal");


		
				//MOVING CODE
		
				anim.SetFloat ("velocityY",rb.velocity.y);
				if (!outsideForce) {

						if (Input.GetAxisRaw ("Horizontal") != 0) {
								anim.SetBool ("Moving", true);
								rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*speed + BaseSpeed, rb.velocity.y);
								transform.localScale = new Vector3 (Input.GetAxisRaw("Horizontal")*1, 1, 1);
						}
						 else {
								anim.SetBool ("Moving", false);
								rb.velocity =  new Vector2 (BaseSpeed, rb.velocity.y);
						}
				}
				//JUMPCODE
				grounded = Physics2D.OverlapArea (point1.position, point2.position, onlyGroundMask);
		
		
		

				anim.SetBool ("Grounded", grounded);

				if (grounded && Input.GetButtonDown("Jump") ){
						timer = 0;
						canJump = true;
						rb.AddForce (new Vector2 (0, jumpForce * 3));
				} 


			}

			
		void FixedUpdate()
		{
				if (grounded && Input.GetButtonDown("Jump")) {
						
				} else if (Input.GetKey (KeyCode.W) && canJump && timer < maxTime) {
						timer += Time.deltaTime;
						rb.AddForce (new Vector2 (0, jumpForce));
				} else {
						canJump = false;
				}
		}

	void OnTriggerStay2D(Collider2D other)
	{
				if (other.tag == "deadly" && !isDead && lives <=1 && !isImmune) {
						rb.velocity = Vector2.zero;
			lives=0;
						StartCoroutine ("ImmuneTime");
						anim.SetBool ("Dies", true);
						rb.AddForce (new Vector2 (0, 500));
						isDead = true;
			
			
				} else if (other.tag == "deadly" && lives > 1 && !isImmune) {
			lives--;
			anim.SetBool("Immune",true);
						StartCoroutine ("ImmuneTime");
			isImmune=true;
				}

	}


	
	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "deadly" && !isDead && lives <=1 && !isImmune) {
			rb.velocity = Vector2.zero;
			lives=0;
			anim.SetBool ("Dies", true);
			rb.AddForce (new Vector2 (0, 500));
			isDead = true;
			
			
		} else if (other.gameObject.tag == "deadly" && lives > 1 && !isImmune) {
			lives--;
			anim.SetBool("Immune",true);
			isImmune=true;
		}
		
	}





	void OnCollisionEnter2D(Collision2D other)
	{
				outsideForce = false;


		if (other.gameObject.tag == "Platform")
						BaseSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity.x;

						
	}


	void OnGUI(){
		GUILayout.Label ("  Lives: " + lives);

	}

}
