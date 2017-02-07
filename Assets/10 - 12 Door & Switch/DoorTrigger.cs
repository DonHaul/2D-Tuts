using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public DoorScript door;


	public bool ignoreTrigger;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){

		if (ignoreTrigger)
						return;

		if (other.tag == "Player")
						door.DoorOpens ();

		}

	void OnTriggerExit2D(Collider2D other){


		if (ignoreTrigger)
			return;

		if (other.tag == "Player")
			door.DoorCloses();
		
	}

	public void Toggle(bool state)
	{
		if (state)
						door.DoorOpens ();
				else
						door.DoorCloses ();
		}


	void OnDrawGizmos()
	{
		if (!ignoreTrigger) {
			BoxCollider2D box = GetComponent<BoxCollider2D>();

			Gizmos.DrawWireCube(transform.position, new Vector2(box.size.x,box.size.y));

				}


	}
}
