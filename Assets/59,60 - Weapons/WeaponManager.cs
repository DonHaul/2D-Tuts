using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {


	public GameObject activeWeapon;
	weapon wpn;
	bool canShoot= true;


	// Use this for initialization
	void Start () {
		wpn = activeWeapon.GetComponent<weapon> ();
		GetComponent<SpriteRenderer> ().sprite = wpn.sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Q) && canShoot)
		{
			canShoot=false;
			StartCoroutine("CoolDown");


			Vector3 rotation = transform.parent.localScale.x==1 ? Vector3.zero : Vector3.forward * 180;
			GameObject projectile = (GameObject) Instantiate(wpn.projectile,transform.position+ activeWeapon.transform.GetChild (0).localPosition*transform.parent.localScale.x,Quaternion.Euler(rotation));

			if(wpn.projectileMode==weapon.Modes.Straight)
				projectile.GetComponent<Rigidbody2D>().velocity= transform.parent.localScale.x*Vector2.right*wpn.projectileSpeed;
			else  if(wpn.projectileMode==weapon.Modes.Throw)
			{
				projectile.GetComponent<Rigidbody2D>().isKinematic=false;

				projectile.GetComponent<Rigidbody2D>().velocity= new Vector2(transform.parent.localScale.x,1)*wpn.projectileSpeed;
			}
		
		
		}

	}

	IEnumerator CoolDown()
	{
		yield return new WaitForSeconds(wpn.coolDown);
		canShoot = true;

	}


	public void UpdateWeapon(GameObject newWeapon)
	{
		activeWeapon = newWeapon;
		wpn = activeWeapon.GetComponent<weapon> ();
		GetComponent<SpriteRenderer> ().sprite = wpn.sprite;
	}

}
