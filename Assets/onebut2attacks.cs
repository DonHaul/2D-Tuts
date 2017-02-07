using UnityEngine;
using System.Collections;

public class onebut2attacks : MonoBehaviour {
		public bool attacking;
		public float timeForSecondaryAction=0.2f;
		public float counter=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
		{

				//On Press the key start counting time and set to be attacking
				if (Input.GetKeyDown (KeyCode.E)) {
						attacking = true;
						counter += Time.deltaTime;
				}
				//while key is pressed keep counting time 
				else if (Input.GetKey (KeyCode.E) && attacking) {

						counter += Time.deltaTime;
				} 
				//on key release do action if still in attactk
				else if (Input.GetKeyUp (KeyCode.E) && attacking) {

						//Do Action in Here
						Debug.Log ("PrimaryAction");

						//Set attack to false
						counter = 0;
						attacking = false;
				}


				//if enough time then do secondary action
				if (counter > timeForSecondaryAction && attacking) {

						//Do Action in Here
						Debug.Log ("SecondaryAction");

						//Set attacking to false
						attacking = false;
						counter = 0;
				}
		}
}
