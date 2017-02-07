using UnityEngine;
using System.Collections;

public class duckmove : MonoBehaviour {

	public float time2jump = 2f;
	public float chance;
	public Vector2 jumpForce;
	public float radius;
	public float downLenght;

	public GameObject target;
	// Use this for initialization
	void Start () {
		StartCoroutine ("DuckMove");

		if(target==null)
			target=GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator DuckMove()
	{
		while (true) {



			yield return new WaitForSeconds(time2jump);

			int i=1;
			if(Random.value<chance)
			{
				if(target.transform.position.x>transform.position.x)
					i=1;
				else
					i=-1;
			}else
			{
				if(target.transform.position.x>transform.position.x)
					i=-1;
				else
					i=1;


			}
			Physics2D.queriesStartInColliders=false;
			Collider2D[] hits= Physics2D.OverlapCircleAll(transform.position,radius);
			foreach(Collider2D h in hits)
				if(h.gameObject==target && Physics2D.Raycast(transform.position,Vector2.down,downLenght))
					GetComponent<Rigidbody2D>().velocity= new Vector2(jumpForce.x*i,jumpForce.y);



			

				}
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;

		Gizmos.DrawWireSphere (transform.position, radius);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, transform.position + Vector3.down * downLenght);
	}

}
