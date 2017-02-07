using UnityEngine;
using System.Collections;

public class Tooltip : MonoBehaviour {

	public GameObject tooltip;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
		void Update () {
				Vector3 tooltipPos = Camera.main.WorldToScreenPoint (gameObject.transform.position + new Vector3 (0,2,0));
		tooltip.transform.position = tooltipPos;
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
						tooltip.SetActive (true);

		}
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
			tooltip.SetActive (false);
		
	}
}
