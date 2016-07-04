using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(NodeTest))]
public class TEST_lvlselect : Editor {
		public  void OnValidate()
		{
				
				//Debug.Log ("Ran");

				NodeTest myTarget = (NodeTest)target;


				myTarget.nodeMan =  GameObject.FindGameObjectWithTag ("LvlManager").GetComponent<TEST_nodeManager>();






			/*	if (GUILayout.Button ("Set Start")) {

						myTarget.pathpoints[0].position= myTarget.transform.position;
				}
				if(GUILayout.Button("Add New Point In End"))
				{
						GameObject go = new GameObject ();
						go.transform.position = myTarget.pathpoints [myTarget.pathpoints.Count - 1].position + Vector3.right;
						go.name="wayPoint";
						go.transform.SetParent (myTarget.transform.parent);

						myTarget.pathpoints.Add(go.transform);
						Selection.activeGameObject = go;
				}*/


		}

		public override void OnInspectorGUI ()
		{
				Debug.Log ("a");
				DrawDefaultInspector ();

				NodeTest myTarget = (NodeTest)target;


				if (GUILayout.Button ("Pair")) {
						for (int i = 0; i < 4; i++) {



								int k = i + 2;
								if (k >= 4)
										k -= 4;

								//Debug.Log ("Changed neighour:" + i);
								//	Debug.Log ("Changed in neighbor:" + k);
					

								if (myTarget.neiborghs [i] != null)
										myTarget.neiborghs [i].neiborghs [k] = myTarget;


						}
				}


				if (GUILayout.Button ("ClearConns")) {
						for (int k = 0; k < 3; k++) {
								myTarget.neiborghs [k] = null;
						}
						for (int i = 0; i < myTarget.nodeMan.nodes.Length; i++) {

								for (int k = 0; k < 3; k++) {
										myTarget.nodeMan.nodes [i].neiborghs [k] = null;
								}

						}
				
				}

				if (GUILayout.Button ("Complement Connections")) {
						for (int k = 0; k < 3; k++) {
								myTarget.neiborghs [k] = null;
						}
						/*for (int i = 0; i < myTarget.nodeMan.nodes.Length; i++) {

								for (int k = 0; k < 3; k++) {
										myTarget.nodeMan.nodes [i].neiborghs [k] = null;
								}

						}*/

				}
		}
}