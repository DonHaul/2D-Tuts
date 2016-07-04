using UnityEngine;
using System.Collections;

public class wallSlide : MonoBehaviour {

		public float distance = 0.4f;
		SimplePlayer0 movement;
		public float speed= -3;
		public float gravScale =0.5f;

		public bool onlyDown;


		// Use this for initialization
		void Start () {
				movement = GetComponent<SimplePlayer0> ();
		}

		// Update is called once per frame
		void Update () {
				Physics2D.queriesStartInColliders = false;
				RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);

				if (onlyDown) {
						if (!movement.grounded && hit.collider != null && GetComponent<Rigidbody2D> ().velocity.y < speed) {
								{

												GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);

								}

						}
				} 
				else {
						if (!movement.grounded && hit.collider != null) {
								GetComponent<Rigidbody2D > ().gravityScale = gravScale;
						}
						else
								{
										GetComponent<Rigidbody2D > ().gravityScale = 1;	
								}
						}

				}
	
}
