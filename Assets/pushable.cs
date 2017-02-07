using UnityEngine;
using System.Collections;

public class pushable : MonoBehaviour {

		public bool beingPushed=true;
		public Vector2 position;
	// Use this for initialization
	void Start () {
				position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
				if (!beingPushed) {
						transform.position = new Vector3(position.x,transform.position.y);
				}
				if (beingPushed) {
					position = transform.position;
				}
	}
}
