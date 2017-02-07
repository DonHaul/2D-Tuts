using UnityEngine;
using System.Collections;

public class walkonwalls : MonoBehaviour {


		public float speed;
		Vector2 moveDirection;
		public float dir;
		Vector2 worldVelocity;
		public float maxSpeed;
		Vector2 downVel;
		// Use this for initialization
		public float upForce;


		public float step = 0.3f;
		public Vector2 localVelocity;



		public LayerMask notPlayer;


		public bool grounded;

		Rigidbody2D rb;

	// Use this for initialization
	void Start () {
				Physics2D.queriesStartInColliders = false;
				rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

				Debug.Log (rb.velocity);
				dir = Input.GetAxisRaw ("Horizontal");


				float worldYspeed = rb.velocity.y;

				//converts world velocity to  local
				localVelocity = transform.InverseTransformDirection (rb.velocity);



				//converts local velocity to world
				//the new velocity conserves the velocity it had up
				worldVelocity = transform.TransformDirection (new Vector2(dir*speed,localVelocity.y)); 

				if (worldYspeed > worldVelocity.y)
						worldVelocity.y = worldYspeed;

				rb.velocity = worldVelocity;


				/*if (Input.GetAxisRaw ("Horizontal") == 0) {
						GetComponent<Rigidbody2D> ().velocity =	transform.TransformDirection(new Vector2 (0,transform.InverseTransformDirection (GetComponent<Rigidbody2D> ().velocity).y));

				}*/


			/*	GetComponent<Rigidbody2D> ().velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, GetComponent<Rigidbody2D> ().velocity.y);

				Debug.Log (GetComponent<Rigidbody2D> ().velocity);

*/
				if (Input.GetKeyDown (KeyCode.W) && grounded==true) {

						rb.velocity = new Vector2 (rb.velocity.x, upForce);
						Debug.Log (rb.velocity);
				}





				Vector2 upDir;
				RaycastHit2D hit= Physics2D.Raycast (transform.position, -transform.up, 1, notPlayer);

				if (hit.collider != null) {
						upDir = hit.normal;
						grounded = true;
						rb.gravityScale = 0;
				} else {
						upDir = Vector2.up;
						grounded = false;

						rb.gravityScale = 1;
				}
		

				float rot_z = Mathf.Atan2 (upDir.y, upDir.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0f, 0f, rot_z - 90), step);

				//transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);

		}

	
}
