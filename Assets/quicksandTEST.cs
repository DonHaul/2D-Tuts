using UnityEngine;
using System.Collections;

public class quicksandTEST : MonoBehaviour {

	public float slowAmount;
		public bool slow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void OnTriggerStay2D(Collider2D col)
		{
				slow = true;

				col.GetComponent<SimplePlayer0> ().slow = 0.1f;




		}
		void OnTriggerExit2D(Collider2D col)
		{
				col.GetComponent<SimplePlayer0> ().slow = 1f;
				slow = false;
		}
}
