using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {

	public float coolDown = 2f;
	float counter;
	public GameObject[] weapons;
	public GameObject weaponHere;
	bool caught;


	// Use this for initialization
	void Start () {
		weaponHere = weapons [Random.Range (0, weapons.Length)];
		GetComponent<SpriteRenderer> ().sprite = weaponHere.GetComponent<SpriteRenderer> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (caught)
						counter += Time.deltaTime;
		if (counter >= coolDown) {
			caught=false;
			counter=0;
			weaponHere = weapons [Random.Range (0, weapons.Length)];
			GetComponent<SpriteRenderer> ().sprite = weaponHere.GetComponent<SpriteRenderer> ().sprite;

				}


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			other.transform.Find("WeaponSlot").GetComponent<WeaponManager>().UpdateWeapon(weaponHere);
			caught=true;
			GetComponent<SpriteRenderer>().sprite=null;
				}

	}
}
