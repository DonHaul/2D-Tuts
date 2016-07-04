using UnityEngine;
using System.Collections;

public class TEST_nodeManager : MonoBehaviour {
		public GameObject player;
		public NodeTest[] nodes;
		public float speed = 0.5f;
		public NodeTest curNode;

		public Vector3 playerdestiny;

	// Use this for initialization
	void Start () {
				player.transform.position = curNode.transform.position;
				playerdestiny=curNode.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


				if (player.transform.position != playerdestiny ) {	

						player.transform.position = Vector2.MoveTowards (player.transform.position, playerdestiny, speed);

				} else {
						//if is
						if(curNode.state==0)

						if (Input.GetKey (KeyCode.W)) {
								UpdateCurrent (0);
						} else if (Input.GetKey (KeyCode.D)) {
								UpdateCurrent (1);
						} else if (Input.GetKey (KeyCode.S)) {
								UpdateCurrent (2);
						} else if (Input.GetKey (KeyCode.A)) {
								UpdateCurrent (3);
						}
				}


			
						
}



		void UpdateCurrent(int i)
		{
				if (curNode.neiborghs [i] != null) {
						curNode = curNode.neiborghs [i];
						playerdestiny= curNode.transform.position;
				}
		}
}