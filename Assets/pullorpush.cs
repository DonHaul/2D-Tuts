using UnityEngine;
using System.Collections;

public class pullorpush : MonoBehaviour {

		public bool pushing;
		public LayerMask boxLayer;
		public float distance=2;
		Vector2 offset;
		GameObject box;


		public bool boxIsStatic;

		int holdpos;
	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {

				Physics2D.queriesStartInColliders = false;
				RaycastHit2D hit =Physics2D.Raycast (transform.position,Vector2.right*transform.localScale.x,distance,boxLayer);

				if (hit.collider != null && Input.GetKeyDown (KeyCode.E)) {
						pushing = true;

						Debug.Log ("Found");
						box = hit.collider.gameObject;
						//box.GetComponent<Rigidbody2D> ().isKinematic = false;
						offset = box.transform.position - transform.position;
						box.GetComponent<FixedJoint2D> ().enabled = true;
						box.GetComponent<FixedJoint2D> ().connectedBody = this.GetComponent<Rigidbody2D> ();

						box.GetComponent<pushable> ().beingPushed = true;
					
				} else if(Input.GetKey(KeyCode.E))
				{
						

						//box.transform.position = (Vector2)transform.position + offset;
				}else if (box != null) {

						box.GetComponent<pushable> ().beingPushed = false;
								//box.GetComponent<Rigidbody2D> ().isKinematic = true;

					
								box.GetComponent<FixedJoint2D> ().enabled = false;

				}

	}

		void OnDrawGizmos()
		{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x*distance);
		}
}
