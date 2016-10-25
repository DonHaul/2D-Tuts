using UnityEngine;
using System.Collections;

public class boxpull : MonoBehaviour {


		public bool beingPushed;
		float xPos;

	// Use this for initialization
	void Start () {
				xPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

				if (beingPushed == false) {
						transform.position = new Vector3 (xPos, transform.position.y);
				} else
						xPos = transform.position.x;
	
	}
}
