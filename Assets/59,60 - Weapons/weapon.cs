using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public enum Modes 
	{ melee, Straight, Follow, Throw}


	public Sprite sprite;
	public GameObject projectile;
	public float projectileSpeed;
	public float coolDown;

	public Modes projectileMode;




	// Use this for initialization
	void Start () {

	}

}
