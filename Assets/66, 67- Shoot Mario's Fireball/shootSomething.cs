using UnityEngine;
using System.Collections;

public class shootSomething : MonoBehaviour {

		public GameObject projectile;
		public Vector2 velocity;
		bool canShoot= true;
		public Vector2 offset = new Vector2(0.4f,0.1f);
		public float cooldown = 1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
				if (Input.GetKeyDown (KeyCode.T) && canShoot) {

						GameObject go = (GameObject)	Instantiate (projectile,(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

						go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x * transform.localScale.x, velocity.y);

						
						GetComponent<Animator> ().SetTrigger ("shoot");

					
						StartCoroutine (CanShoot()); //ADDED RECENTLY bug found by EndUser & orlando 
				}


	}

	
		IEnumerator CanShoot()
		{
				canShoot = false;
				yield return new WaitForSeconds (cooldown);
				canShoot = true;


		}
}
