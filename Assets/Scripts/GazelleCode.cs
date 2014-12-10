using UnityEngine;
using System.Collections;

public class GazelleCode : MonoBehaviour {

	public Vector2 minXandY;
	public Vector2 maxXandY;

	public Vector2 range = new Vector2(3f, 5f); 
	public float walkSpeed = 0.5f; 
	public float runSpeed = 10f; 
	public float runTime = 20f; 
	public float runTimeDecrease = 5f;
	public float waitTime = 5f; 

	public GameObject trail; 
	public AudioSource runSound;

	private float speed = 5f; 
	private float travelTime = 5f;
	private Vector3 pos1;
	private Vector3 pos2;
	private float deltaTime = 0f;
	private float lerpTime = 0f; 

	private bool isRunning = false; 
	private float wait = 0f; 
	private float dashTime = 0f; 
	private bool facingRight = true; 
	private bool stop = false; 


	// Use this for initialization
	void Start () {
		SetSpeed (walkSpeed); 
		wait = waitTime; 
		FindPos (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (!stop) {
		deltaTime += Time.deltaTime; 
		if ( deltaTime <= travelTime ) {
			lerpTime = deltaTime/travelTime; 
			transform.position = Vector3.Lerp(pos1, pos2, lerpTime );
		}
		else if ( deltaTime <= travelTime + wait ) {
		}
		else {
			FindPos();
			if (!isRunning) {
				GameObject path;
				path = Instantiate(trail, transform.position, Quaternion.identity) as GameObject;
				Vector3 dir = pos2 - pos1;
				float angle = Mathf.Atan2 (dir.y,dir.x) * Mathf.Rad2Deg;
				path.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
			}
		}
		
		if (isRunning) {
			dashTime += Time.deltaTime;
			if (dashTime > runTime) {
				isRunning = false;
				SetSpeed(walkSpeed);
				wait = waitTime;
				if (runTime > 5) 
					runTime -= runTimeDecrease;

			}
		}
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void FindPos() {
		deltaTime = 0f; 
		pos1 = transform.position;
		float x = Random.Range(minXandY.x, maxXandY.x);
		float y = Random.Range(minXandY.y, maxXandY.y);

		pos2 = new Vector3(x, y, 0); 

		float r = Random.Range(range.x, range.y); 

		Vector3 dir = Vector3.Normalize(pos2-pos1) * r;

		pos2 = pos1 + dir; 

		travelTime = Vector3.Magnitude (dir) / speed; 
		RaycastHit2D hit = Physics2D.Raycast(pos1, pos2 - pos1); 
		if (pos2.x > pos1.x && !facingRight) 
			Flip ();
		else if (pos2.x < pos1.x && facingRight)
			Flip ();
//		if (hit.collider.gameObject.name == "AvoidArea" || hit.collider.gameObject.tag == "Player") {
//			FindPos();
//		}
	}

	public void SetSpeed(float s) {
		speed = s;
	}

	public void StartRunning(Vector3 playerPos) {
		dashTime = 0f;
		isRunning = true;
		SetSpeed(runSpeed);
		wait = 0f;
		deltaTime = 0f; 
		pos1 = transform.position;
		Vector3 dir = -1* (playerPos - pos1);
		pos2 = Vector3.Normalize(dir) * range.y;
		if (pos2.x > pos1.x && !facingRight) 
			Flip ();
		else if (pos2.x < pos1.x && facingRight)
			Flip ();
		travelTime = Vector3.Magnitude (pos2 - pos1) / speed;  
		if (!runSound.isPlaying) 
			runSound.Play(); 
	}

	public void Stop() {
		stop = true;
	}

}
