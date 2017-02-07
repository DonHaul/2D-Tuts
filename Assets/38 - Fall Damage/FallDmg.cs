using UnityEngine;
using System.Collections;

public class FallDmg : MonoBehaviour {

	int falldamage;
	bool canLoseDmg;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D other)
	{

		if (Mathf.Abs (other.relativeVelocity.y) > 30f  && canLoseDmg) {

			falldamage=(int)((0.1f)* Mathf.Abs (other.relativeVelocity.y) - 3f);
			gameObject.GetComponent<SimplePlayer0>().lives-=falldamage;
			Debug.Log(falldamage);
			canLoseDmg=false;
				}


		if (gameObject.GetComponent<SimplePlayer0> ().lives <= 0) {

			gameObject.GetComponent<SimplePlayer0> ().lives = 0 ;
			gameObject.GetComponent<SimplePlayer0> ().anim.SetBool("Dies",true);
			gameObject.GetComponent<SimplePlayer0> ().isDead=true;
				}


}
	void OnCollisionStay2D(Collision2D other)
	{
		canLoseDmg = true;

		}
}
