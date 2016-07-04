using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {


	public DoorTrigger[] doorTrig;



	Animator anim;
	public bool sticks;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerStay2D()
	{
		anim.SetBool ("goDown", true);

		foreach (DoorTrigger trigger in doorTrig) {

			trigger.Toggle(true);

				}

	}

	void OnTriggerExit2D()
	{
		if(sticks)
			return;

		anim.SetBool ("goDown", false);

		foreach (DoorTrigger trigger in doorTrig) {
			
			trigger.Toggle(false);
			
		}





	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;

		foreach (DoorTrigger trigger in doorTrig) {
			
			Gizmos.DrawLine(transform.position,trigger.transform.position);
			
		}


		}


}
