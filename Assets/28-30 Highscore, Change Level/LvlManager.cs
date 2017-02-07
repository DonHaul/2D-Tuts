using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour {
	public int score;

	public bool ended;

	public GUIText scoretxt;
	public GUIText besttxt;
	public GameObject pow;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (ended) {

			if(score>PlayerPrefs.GetInt(Application.loadedLevel + "Best"))
			{
				PlayerPrefs.SetInt(Application.loadedLevel + "Best",score);
				pow.SetActive(true);

			}


			scoretxt.text= "Score: " + score.ToString();
			besttxt.text= "Best: " + PlayerPrefs.GetInt(Application.loadedLevel + "Best");

			scoretxt.gameObject.SetActive(true);
			besttxt.gameObject.SetActive(true);


				}

	}


	public void AddPoints(int points)
	{
		score += points;


	}


	void OnGUI()
	{
		GUILayout.Label (score.ToString());

	}
}
