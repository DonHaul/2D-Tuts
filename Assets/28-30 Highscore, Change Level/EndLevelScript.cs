using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {

	public GUIText endLevelText;
	bool hasEnded;
	public string nextLevel;

	public LvlManager manager;


	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("Manager").GetComponent<LvlManager> ();
		endLevelText.transform.position = new Vector2 (.5f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
	if (hasEnded && Input.GetKeyDown (KeyCode.Return)) {

			Time.timeScale=1f;
			Application.LoadLevel(nextLevel);
				}


	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			endLevelText.gameObject.SetActive(true);
			hasEnded=true;
			manager.ended=true;
			Time.timeScale=0;
			GetComponent<AudioSource>().Play();

				}

	}
}
