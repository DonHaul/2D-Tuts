using UnityEngine;
using System.Collections;

public class meter : MonoBehaviour {

	GUIText guitexty;

	public GameObject player;

	float beginPos;
	float curPos;


	public int multiplier=10;

	// Use this for initialization
	void Start () {
		beginPos = player.transform.position.x;
		guitexty = GetComponent<GUIText> ();

	}
	
	// Update is called once per frame
	void Update () {



		curPos = player.transform.position.x - beginPos;


		int distance = Mathf.Abs(Mathf.RoundToInt (curPos * multiplier ));


		if(distance> PlayerPrefs.GetInt("Best"))
			PlayerPrefs.SetInt("Best",distance);

		guitexty.text="Distance: " + distance + "m /" + PlayerPrefs.GetInt("Best") + "m";

	}
}
