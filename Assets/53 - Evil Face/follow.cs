using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {

	public Sprite[] sprites;
	public GameObject target;
	public float ratio=0.05f;
	bool gotIt;
	public float range;
	public GameObject explosion;


	// Use this for initialization
	void Start () {

	if (target == null)
						target = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {


		if (!gotIt) {
						Collider2D[] hits = Physics2D.OverlapCircleAll (transform.position, range);

						foreach (Collider2D h in hits)
								if (h.gameObject == target) {
										gotIt = true;
										break;			
		
								}
				}



if (gotIt) {
						float step;

						if (Vector3.Dot (target.transform.position - transform.position, target.transform.localScale.x * Vector3.right) > 0) {
								step = ratio * 2;
								GetComponent<SpriteRenderer> ().sprite = sprites [1];
						} else {
								step = ratio;
								GetComponent<SpriteRenderer> ().sprite = sprites [0];

						}


						transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
				}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile" || other.tag == "Player")
						Die ();

		}


	public void Die()
		{

		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (this.gameObject,0.1f);
		}



	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;

		Gizmos.DrawWireSphere (transform.position, range);


		}
}
