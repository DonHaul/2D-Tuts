using UnityEngine;
using System.Collections;

public class slowTEST : MonoBehaviour {
	
		public float slow=1;
		public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
				rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
				rb.velocity *= slow;
	}
}
