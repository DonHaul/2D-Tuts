using UnityEngine;
using System.Collections;

public class Sprits : MonoBehaviour {
	public string spriteName;
	public int curSprite;

	public Sprite[] sprites;

	// Use this for initialization
	void Start () {

		sprites = Resources.LoadAll<Sprite> (spriteName);

		if (curSprite == -1)
						curSprite = Random.Range (0, sprites.Length);


		GetComponent<SpriteRenderer> ().sprite = sprites [curSprite];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
