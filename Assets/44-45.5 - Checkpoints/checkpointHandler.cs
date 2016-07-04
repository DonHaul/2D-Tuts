using UnityEngine;
using System.Collections;

public class checkpointHandler : MonoBehaviour {

	public GameObject player;
	public GameObject spawn;
	int index;

	public enum Mode
		{
		Regular, Locked, Ordered
		}
	public Mode mode;

	public GameObject[] checkpoints;

	// Use this for initialization
	void Start () {
		if (mode != Mode.Ordered)
						checkpoints = GameObject.FindGameObjectsWithTag ("checkpoint");
				else
						Debug.LogWarning ("Make Sure You filled the checkpoints array");
		spawn=GameObject.Find("Spawn");
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetKeyDown (KeyCode.R)) {
			foreach (GameObject cp in checkpoints) {
				if (cp.GetComponent<checkpoint> ().status == checkpoint.state.Active) {
					player.transform.position= cp.transform.position;
					return;
				}
			}

			player.transform.position=spawn.transform.position;


				}

	}


	public void UpdateCheckpoints(GameObject curCheck)
	{

		if (mode == Mode.Regular) {
						foreach (GameObject cp in checkpoints) {
								if (cp.GetComponent<checkpoint> ().status != checkpoint.state.Inactive) {
										cp.GetComponent<checkpoint> ().status = checkpoint.state.Used;
								}
						}


						curCheck.GetComponent<checkpoint> ().status = checkpoint.state.Active;
				} else if (mode == Mode.Locked && curCheck.GetComponent<checkpoint> ().status != checkpoint.state.Locked) {

						foreach (GameObject cp in checkpoints) {
								if (cp != curCheck && cp.GetComponent<checkpoint> ().status != checkpoint.state.Inactive) {
										cp.GetComponent<checkpoint> ().status = checkpoint.state.Locked;
								}
						}


						curCheck.GetComponent<checkpoint> ().status = checkpoint.state.Active;



		} else if (mode == Mode.Ordered && index<checkpoints.Length && curCheck == checkpoints[index] ) {



			foreach (GameObject cp in checkpoints) {
				if (cp.GetComponent<checkpoint> ().status != checkpoint.state.Inactive) {
					cp.GetComponent<checkpoint> ().status = checkpoint.state.Locked;
				}
			}

			curCheck.GetComponent<checkpoint> ().status = checkpoint.state.Active;
			index++;


				}

	}
}
