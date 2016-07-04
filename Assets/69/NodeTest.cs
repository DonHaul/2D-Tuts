using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class NodeTest : MonoBehaviour {
		public Scene scene;
		public TEST_nodeManager nodeMan;
		public NodeTest[] neiborghs = new NodeTest[4];


		public int state = 0;
		public string level;

	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		void OnDrawGizmos()
		{
				Gizmos.color = Color.red;
				if(neiborghs [0]!=null)
				Gizmos.DrawLine (transform.position, neiborghs [0].transform.position);

				Gizmos.color = Color.green;
				if(neiborghs [1]!=null)
				Gizmos.DrawLine (transform.position, neiborghs [1].transform.position);

				Gizmos.color = Color.blue;
				if(neiborghs [2]!=null)
				Gizmos.DrawLine (transform.position, neiborghs [2].transform.position);

				Gizmos.color = Color.yellow;
				if(neiborghs [3]!=null)
				Gizmos.DrawLine (transform.position, neiborghs [3].transform.position);
		}
}
