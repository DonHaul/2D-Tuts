using UnityEngine;
using System.Collections;

public class trampolinescript : MonoBehaviour {


	public bool customSpeed;
	public Vector2 customVelocity;
	public float multiplier;


	bool onTop;
	public GameObject bouncer;
	Animator anim;
	Vector2 velocity;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionStay2D(Collision2D other)
	{

		if (onTop) {
						anim.SetBool ("isStepped", true);
						bouncer = other.gameObject;
				}

		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent<SimplePlayer0>().BaseSpeed = velocity.x;
				}
		}



	void OnTriggerEnter2D()
	{
		onTop = true;
	}
	void OnTriggerExit2D()
	{
		onTop = false;
		anim.SetBool ("isStepped", false);

		}

	void OnTriggerStay2D()
	{
		onTop = true;
	}
		
		
	void Jump()
	{

		if (customSpeed)
						velocity = customVelocity;
				else
						velocity = transform.up * multiplier;



		bouncer.GetComponent<Rigidbody2D>().velocity = velocity;

		}


		
	}



		
	
