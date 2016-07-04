using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public bool byTime;
	public bool byContact;
	public float destroyTime;

	// Use this for initialization
	void Start () {

		Destroy (this.gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag!="shooter" && other.tag!="neutralized")
		Destroy (this.gameObject);

	}
}
