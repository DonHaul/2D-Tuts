using UnityEngine;
using System.Collections;

public class Evolution : MonoBehaviour {

	int lifeChecker;
	bool canShoot;
	public GameObject projectile;
	public Transform catmouth;
	public float velocity;

	public float time=1f;
	float timer;

	// Use this for initialization
	void Start () {
		lifeChecker = 1;

	}
	
	// Update is called once per frame
	void Update () {

		if (!canShoot) {
			timer-=Time.deltaTime;
		
		}
		if (timer <= 0) {
			canShoot=true;
			timer=time;
				}

		

	
		if (gameObject.GetComponent<SimplePlayer0> ().lives >= 2 && Input.GetKey (KeyCode.J) && canShoot) {

			GameObject furBall = (GameObject) Instantiate(projectile, catmouth.position,Quaternion.identity);
			furBall.GetComponent<Rigidbody2D>().velocity= new Vector2 (velocity * gameObject.transform.localScale.x,0);
			canShoot=false;
				}




		if (lifeChecker != gameObject.GetComponent<SimplePlayer0> ().lives) {

			if (gameObject.GetComponent<SimplePlayer0> ().lives==1)
			{
				gameObject.GetComponent<Animator>().SetInteger("Transformation",1);
			} else if (gameObject.GetComponent<SimplePlayer0> ().lives >= 2)
			{
				gameObject.GetComponent<Animator>().SetInteger("Transformation",2);
			}


			lifeChecker = gameObject.GetComponent<SimplePlayer0> ().lives;
				}

	}

	public void Trans()
	{
				if (gameObject.GetComponent<SimplePlayer0> ().lives == 1) {
						gameObject.GetComponent<Animator> ().SetLayerWeight (2, 0.3f);
				} else if (gameObject.GetComponent<SimplePlayer0> ().lives >= 2) {
						gameObject.GetComponent<Animator> ().SetLayerWeight (2, 0.7f);
				}
		}
}
