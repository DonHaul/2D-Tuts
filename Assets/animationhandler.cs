using UnityEngine;
using System.Collections;

public class animationhandler : MonoBehaviour {

		float xPos;
		Animator anim;
		SpriteRenderer srenderer;

	// Use this for initialization
	void Start () {
				srenderer = GetComponent<SpriteRenderer> ();
				anim = GetComponent<Animator> ();
				xPos =transform.position.x;
				anim.SetBool ("Grounded", true);
	}
	
	// Update is called once per frame
	void Update () {
	
				if (transform.position.x != xPos) {
						anim.SetBool ("Moving", true);

						if (transform.position.x > xPos)
								srenderer.flipX = false;
						else
								srenderer.flipX = true;


				}else
						anim.SetBool ("Moving", false);


				xPos = transform.position.x;
	}
}
