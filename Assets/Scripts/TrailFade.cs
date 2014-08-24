using UnityEngine;
using System.Collections;

public class TrailFade : MonoBehaviour {

	public float fadeTime = 20f;

	private float time = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= fadeTime) 
			Destroy(this.gameObject); 
	}
}
