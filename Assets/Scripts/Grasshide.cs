using UnityEngine;
using System.Collections;

public class Grasshide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<CheetahController>().Hide(); 
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<CheetahController>().Reveal(); 
		}
	}
}
