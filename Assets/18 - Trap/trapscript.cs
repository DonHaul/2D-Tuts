using UnityEngine;
using System.Collections;

public class trapscript : MonoBehaviour {


	public float triggerTime;
	public float activeTime;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("attack", false);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
			StartCoroutine(Attack());


	}

	IEnumerator Attack()
	{
		yield return new WaitForSeconds (triggerTime);
		anim.SetBool ("attack", true);
		gameObject.tag = "deadly";
		yield return new WaitForSeconds(activeTime);
		gameObject.tag = "neutralized";

	}
}
