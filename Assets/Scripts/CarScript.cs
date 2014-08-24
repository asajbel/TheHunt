using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {
	
	public float travelTime = 0.6f;
	public float waitTime = 0.25f;
	public GameObject gazelle;
	public AudioSource shot; 

	private float lerpTime = 0f; 
	private float dTime = 0f; 
	
	private Vector3 pos1;
	private Vector3 pos2;
	private bool hasShot = false;

	// Use this for initialization
	void Start () {
		if (gazelle == null) {
			gazelle = GameObject.FindGameObjectWithTag("gazelle"); 
		}
		pos1 = transform.position;
		pos2 = gazelle.transform.position; 
		shot.PlayDelayed(travelTime); 
	}
	
	// Update is called once per frame
	void Update () {
		dTime += Time.deltaTime; 
		if (dTime <= travelTime) {
			lerpTime = dTime/travelTime; 
			transform.position = Vector3.Lerp(pos1,pos2,lerpTime);
		}
		else if (hasShot) {
			GameOver();
		}
		else if (dTime > travelTime + waitTime) {
			pos1 = transform.position;
			pos2 = new Vector3(transform.position.x + 5,
			                   transform.position.y - 1,
			                   transform.position.z); 
			hasShot = true; 
			dTime = 0f; 
		}
		else {
			Destroy(gazelle); 
		}
	}

	void GameOver() {
		GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().GameOver(); 
	}
}
