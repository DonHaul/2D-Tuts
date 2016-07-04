using UnityEngine;
using System.Collections;

public class SimpleEnemyScripy : MonoBehaviour {

	public float velocity = 1f;

	public Transform sightStart;
	public Transform sightEnd;

	public LayerMask detectWhat;

	public Transform weakness;

	public bool colliding;

	Animator anim;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
				Physics2D.queriesStartInColliders = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity, GetComponent<Rigidbody2D>().velocity.y);

		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position, detectWhat);

		if (colliding) {
					
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			velocity*= -1;

				}

	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;

		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {

			float height= col.contacts[0].point.y - weakness.position.y;

			if(height>0)
			{
				Dies();
				col.rigidbody.AddForce(new Vector2(0,300));


			}


				}
				
		
		}

	void Dies()
	{
		anim.SetBool ("stomped", true);
		Destroy (this.gameObject, 0.5f);
		gameObject.tag = "neutralized";


		}









}
