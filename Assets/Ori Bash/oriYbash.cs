using UnityEngine;
using System.Collections;

public class oriYbash : MonoBehaviour {

		public float reachRadius = 5f;
		RaycastHit2D[] objectsNear;
		Vector3 direction;
		public float speed= 20f;
		public bool canBash;
		GameObject bashableObj;
		public float maxtime=1f;
		public Transform arrow;
		public GameObject effect;

	// Use this for initialization
	void Start () {
				arrow.gameObject.SetActive (false);
	}
	

		IEnumerator Counter()
		{
				//yield return new WaitForSeconds()
				float pauseTime = Time.realtimeSinceStartup+maxtime;

				while (Time.realtimeSinceStartup < pauseTime) {
				
						yield return null;
				
				}

				if (Time.timeScale == 0) {
						Time.timeScale = 1f;
						canBash = false;
						arrow.gameObject.SetActive (false);

				}


		}


	// Update is called once per frame
	void Update () {
	
				if (Input.GetButtonDown ("Fire2")) {


						objectsNear = Physics2D.CircleCastAll (transform.position, reachRadius, Vector3.forward);
						{
								foreach (RaycastHit2D obj in objectsNear) {
										if (obj.collider.gameObject.GetComponent<bashable> () != null) {
											

												bashableObj = obj.collider.gameObject;
												StartCoroutine ("Counter");
												Time.timeScale = 0;
								
												canBash = true;
												arrow.position = bashableObj.transform.position;
												arrow.Translate (0, 0, 10);

												arrow.gameObject.SetActive (true);
												break;


								
										}
										
								}
						}
				} else if (Input.GetButtonUp ("Fire2") && canBash) {
						Time.timeScale = 1;

						direction = (Camera.main.ScreenToWorldPoint (Input.mousePosition) - bashableObj.transform.position);
						direction.z = 0;
						direction = direction.normalized;

						transform.position = bashableObj.transform.position + direction * 1.2f;

						GetComponent<SimplePlayer0> ().outsideForce = true;
						GetComponent<Rigidbody2D> ().velocity = direction * speed;

						bashableObj.GetComponent<Rigidbody2D> ().velocity = direction * (-1) * bashableObj.GetComponent<Rigidbody2D> ().velocity.magnitude;


						canBash = false;
						arrow.gameObject.SetActive (false);


				} else if (Input.GetButton ("Fire2") && canBash) {


						Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
						diff.Normalize();

						float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
						arrow.transform.rotation = Quaternion.Euler(0f, 0f, rot_z );
						Instantiate (effect, bashableObj.transform.position, Quaternion.identity);



				}


	}



		void OnDrawGizmos()
		{

				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere (transform.position, reachRadius);

		}
}
