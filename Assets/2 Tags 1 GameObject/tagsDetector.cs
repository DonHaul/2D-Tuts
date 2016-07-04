using UnityEngine;
using System.Collections;

public class tagsDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void OnTriggerEnter2D(Collider2D other)
		{


				if (other.GetComponent<Sign_tag> () != null) {


						Debug.Log ("Has sign tag");
				}

				CheckThisTag ("sign", other);




		}



		void CheckThisTag(string tag, Collider2D other)
		{

				if (other.GetComponent<tags> () != null) {

						foreach (string str in other.GetComponent<tags> ().objTags) {
								if (str == tag) {
										Debug.Log ("Has tag"+ tag);

								}

						}

				}
		}
	
}
