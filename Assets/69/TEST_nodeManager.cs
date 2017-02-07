using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TEST_nodeManager : MonoBehaviour {


		//
		public GameObject canvas;
		public Text leveltext;


		//
		public GameObject player;


		public float speed = 0.5f;
		public NodeTest curNode;

		NodeTest cameFrom;

		public Vector3 playerdestiny;

	// Use this for initialization
	void Start () {
				player.transform.position = curNode.transform.position;
				playerdestiny=curNode.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


				if (player.transform.position != playerdestiny ) {	
						canvas.SetActive (false);

						player.transform.position = Vector2.MoveTowards (player.transform.position, playerdestiny, speed);

				} else {
						

						
						if (curNode.state == 0) {
								//intermediate node
								GoToNext ();

						} else {

								if (curNode.level != "") {
										leveltext.text = curNode.level;
										canvas.SetActive (true);
								}

								if (Input.GetKey (KeyCode.W)) {
										UpdateCurrent (0);
								} else if (Input.GetKey (KeyCode.D)) {
										UpdateCurrent (1);
								} else if (Input.GetKey (KeyCode.S)) {
										UpdateCurrent (2);
								} else if (Input.GetKey (KeyCode.A)) {
										UpdateCurrent (3);
								} else if (Input.GetKey (KeyCode.E)) {
										UnityEngine.SceneManagement.SceneManager.LoadScene (curNode.level);
								}

						}


				}


			
						
}



		void UpdateCurrent(int i)
		{
				cameFrom = curNode;

				if (curNode.neiborghs [i] != null) {
						curNode = curNode.neiborghs [i];
						playerdestiny= curNode.transform.position;
						Debug.Log ("going");
				}
				Debug.Log ("not going");
		}

		void GoToNext()
		{
				foreach (var item in curNode.neiborghs) {
						if (item != null && item != cameFrom) {
								curNode = item;
								playerdestiny= curNode.transform.position;
						}
				}


		}
}