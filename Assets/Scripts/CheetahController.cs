using UnityEngine;
using System.Collections;

public class CheetahController : MonoBehaviour {

	public float speed = 4; 
	public GameObject car; 

	private bool hidden = false;
	private bool facingRight = true; 
	private bool gameOver = false; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
		transform.Translate(speed * Input.GetAxis("Horizontal"),
		                    speed * Input.GetAxis("Vertical"),
		                    0); 

		
		if (Input.GetAxis("Horizontal") > 0 && !facingRight)
			Flip();
		else if (Input.GetAxis("Horizontal") < 0 && facingRight)
			Flip();
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "gazelle") {
			float x = transform.position.x - 5;
			float y = transform.position.y + 1;
			float z = transform.position.z; 
			Vector3 pos = new Vector3(x,y,z);
			Instantiate(car, pos, Quaternion.identity); 
			gameOver = true; 
			col.gameObject.transform.GetComponent<GazelleCode>().Stop(); 
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Hide() { hidden = true; }

	public void Reveal() { hidden = false; }

	public bool isHidden() { return hidden; }
}
