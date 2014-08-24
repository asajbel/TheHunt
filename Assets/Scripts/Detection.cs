using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {

	public float shrinkRate = 0.01f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D ( Collider2D col ) {
		if (col.gameObject.tag == "Player") {
			transform.localScale -= new Vector3(shrinkRate,shrinkRate,shrinkRate); 
			bool hidden = col.gameObject.transform.GetComponent<CheetahController>().isHidden(); 
			if (!hidden) {
				transform.GetComponentInParent<GazelleCode>().StartRunning(col.gameObject.transform.position); 
			}
		}
	}
}
