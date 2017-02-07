using UnityEngine;
using System.Collections;

public class climbledges : MonoBehaviour {

		//for hanging
		public Vector2 rayhangOffset;
		public float raySize;
		public Vector2 hangOffset;
		public Vector2 size;
		//for climbing
		/*public Vector2 rayclimbOffset;
		public float rayclimbSize;
		public Vector2 climbOffset;
		public Vector2 climbSize;
*/


		float cooldown=0.2f;
	

		public bool canHang=true;

		Animator anim;
	// Use this for initialization
	void Start () {
				anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
			
				Collider2D col= Physics2D.OverlapBox (transform.position + new Vector3(hangOffset.x*transform.localScale.x,hangOffset.y), size, 0);
				if (col == null && canHang && GetComponent<SimplePlayer0> ().hanging==false) {
						RaycastHit2D hit=	Physics2D.Raycast (transform.position + new Vector3(rayhangOffset.x*transform.localScale.x,rayhangOffset.y),Vector2.down,raySize);

						if (hit.collider != null && hit.point!=(Vector2)transform.position + new Vector2(rayhangOffset.x*transform.localScale.x,rayhangOffset.y)) {
								
								GetComponent<SimplePlayer0> ().hanging=true;
								GetComponent<Rigidbody2D> ().isKinematic = true;
								Debug.Log ("CantHangNow");
								canHang = false;
							//	GetComponent<Rigidbody2D> ().drag =9999999;
			
								GetComponent<SimplePlayer0> ().hanging= true;
								anim.SetBool ("hanging",true);
								anim.Play ("player2hang");

						}
				}

		/*		if (Input.GetKeyDown (KeyCode.E) && GetComponent<SimplePlayer0> ().hanging==true) {

						col= Physics2D.OverlapBox (transform.position + new Vector3(climbOffset.x*transform.localScale.x,climbOffset.y), climbSize, 0);
						if (col == null) {

								transform.position = transform.position + new Vector3(climbOffset.x*transform.localScale.x,climbOffset.y);
								GetComponent<SimplePlayer0> ().hanging=false;
								GetComponent<Rigidbody2D> ().isKinematic = false;
								StartCoroutine(WaitABit());
								anim.SetBool ("hanging",false);
								GetComponent<SimplePlayer0> ().hanging=false;

						}
				}*/

				if (GetComponent<SimplePlayer0> ().hanging == false) {
						GetComponent<Rigidbody2D> ().isKinematic = false;
						if(canHang==false)
						StartCoroutine(WaitABit());
						anim.SetBool ("hanging",false);
				}
				if (Input.GetKeyDown (KeyCode.S)) {
						GetComponent<SimplePlayer0> ().hanging=false;

						GetComponent<Rigidbody2D> ().isKinematic = false;
						StartCoroutine(WaitABit());
						anim.SetBool ("hanging",false);
				}
	}
		IEnumerator WaitABit()
		{
				Debug.Log ("cooldown");
		canHang = false;
				yield return new WaitForSeconds (cooldown);
						canHang=true;

			
		}

		void OnDrawGizmos()
		{

				Gizmos.color = Color.blue;

				Gizmos.DrawWireCube (transform.position +  new Vector3(hangOffset.x*transform.localScale.x,hangOffset.y), size);
				Gizmos.DrawLine (transform.position + new Vector3(rayhangOffset.x*transform.localScale.x,rayhangOffset.y),transform.position +new Vector3(rayhangOffset.x*transform.localScale.x,rayhangOffset.y)+Vector3.down*raySize);


		//		Gizmos.DrawWireCube (transform.position +  new Vector3(climbOffset.x*transform.localScale.x,climbOffset.y), climbSize);
		//		Gizmos.DrawLine (transform.position + new Vector3(rayclimbOffset.x*transform.localScale.x,rayclimbOffset.y),transform.position +new Vector3(rayclimbOffset.x*transform.localScale.x,rayclimbOffset.y)+Vector3.right*transform.localScale.x*rayclimbSize);

		
		}

	
}
