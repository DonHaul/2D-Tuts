using UnityEngine;
using System.Collections;

public class playerpush : MonoBehaviour {

		public float distance=1f;
		public LayerMask boxMask;

		GameObject box;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
				Physics2D.queriesStartInColliders = false;
				RaycastHit2D hit= Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
	
				if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKeyDown (KeyCode.E)) {

						box = hit.collider.gameObject;

						box.GetComponent<FixedJoint2D> ().enabled = true;
						box.GetComponent<boxpull> ().beingPushed = true;
						box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();
				} else if (Input.GetKeyUp (KeyCode.E)) {
						box.GetComponent<FixedJoint2D> ().enabled = false;
						box.GetComponent<boxpull> ().beingPushed = false;
				}
		
		}


		void OnDrawGizmos()
		{
				Gizmos.color = Color.yellow;

				Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
		
			
		
		}
}
