using UnityEngine;
using System.Collections;

public class platform_gothrought : MonoBehaviour {


	  public float DownValue, UpValue;
	bool goUp;


	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKey (KeyCode.S))
						other.gameObject.transform.position += new Vector3 (0, DownValue);
		if (other.gameObject.tag == "Player" && Input.GetKey (KeyCode.W) && goUp)
			other.gameObject.transform.position += new Vector3 (0, UpValue);
		}




	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
						goUp = true;
				
						

	}
	void OnTriggerExit2D(Collider2D other)
	{
		goUp = false;
	}



	/*void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//other.gameObject.collider2D.isTrigger =true;
			other.gameObject.GetComponent<BoxCollider2D>().isTrigger =true;
			other.gameObject.GetComponent<CircleCollider2D>().isTrigger =true;
		}
		}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//other.gameObject.collider2D.isTrigger =true;
			other.gameObject.GetComponent<BoxCollider2D>().isTrigger =false;
			other.gameObject.GetComponent<CircleCollider2D>().isTrigger =false;
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKey (KeyCode.S)) {

			other.gameObject.GetComponent<BoxCollider2D>().isTrigger =true;
			other.gameObject.GetComponent<CircleCollider2D>().isTrigger =true;
				}
	}*/



}
