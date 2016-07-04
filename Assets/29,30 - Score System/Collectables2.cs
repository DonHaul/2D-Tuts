using UnityEngine;
using System.Collections;

public class Collectables2 : MonoBehaviour {

	//public LvlManager lvlman;
	public int gemPoints=10;

	public GameObject manager;
		LvlManager lvlman;


	// Use this for initialization
	void Awake () {
		lvlman = manager.GetComponent<LvlManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {

			lvlman.AddPoints(gemPoints);
			Destroy(this.gameObject);
				}


	}
}
