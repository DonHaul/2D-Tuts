using UnityEngine;
using System.Collections;

public class fireball : MonoBehaviour {

		public Rigidbody2D rb;
		public Vector2 velocity;
		public GameObject explosion;


	// Use this for initialization
	void Start () {
		
				Destroy (this.gameObject, 10);

				rb = GetComponent<Rigidbody2D> ();

				velocity = rb.velocity;

	}
	
	// Update is called once per frame
	void Update () {
	
				if (rb.velocity.y < velocity.y) {


						rb.velocity = velocity;
				}



	}

		void OnCollisionEnter2D(Collision2D col)
		{
				if (col.collider.tag == "deadly") {

						Destroy (col.gameObject);
						Explode ();


				}
				foreach (var item in col.contacts) {
						Debug.Log (item.normal);
						Debug.Log (item.collider.name);
				}
				if (Mathf.Abs (col.contacts [0].normal.x) ==1f)
						Explode ();

				rb.velocity = new Vector2 (velocity.x,- velocity.y);

		}


		void Explode()
		{
				Destroy (this.gameObject);

				Instantiate (explosion, transform.position, Quaternion.identity);
		}

}
