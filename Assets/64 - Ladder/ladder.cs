using UnityEngine;
using System.Collections;

public class ladder : MonoBehaviour {

		public float speed =6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void OnTriggerStay2D(Collider2D other)
		{
				if (other.tag == "Player" && Input.GetKey (KeyCode.W)) {
						other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);

				} else if (other.tag == "Player" && Input.GetKey (KeyCode.S)) {
						other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);

				} else {

						other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,1);

				}



		}
}
