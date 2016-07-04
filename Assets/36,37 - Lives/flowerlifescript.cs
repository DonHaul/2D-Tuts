using UnityEngine;
using System.Collections;

public class flowerlifescript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<SimplePlayer0>().lives++;
			gameObject.GetComponent<Collider2D>().enabled=false;
			gameObject.GetComponent<SpriteRenderer>().enabled=false;
			//gameObject.GetComponentInChildren<SpriteRenderer>().enabled=false;
			gameObject.GetComponentInChildren<Transform>().localScale=Vector2.zero;
			GetComponent<AudioSource>().Play();
			Destroy(this.gameObject,2f);
				}
	}
}
