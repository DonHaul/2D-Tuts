using UnityEngine;
using System.Collections;

public class shootSomething : MonoBehaviour {

		bool canShoot = true;
		public GameObject projectile;
		public Vector2 offset = new Vector2 (0.4f,0.2f);
		public float cooldown= 1;
		public Vector2 velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

				if (Input.GetKeyDown (KeyCode.T) && canShoot) {

						GetComponent<Animator> ().SetTrigger ("throw");


						GameObject go = (GameObject) Instantiate (projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
						go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x * transform.localScale.x, velocity.y);

						StartCoroutine (CanShoot ());
				}

	}


		IEnumerator CanShoot()
		{
				canShoot = false;
				yield return new WaitForSeconds (cooldown);
				canShoot = true;	

		}

}
