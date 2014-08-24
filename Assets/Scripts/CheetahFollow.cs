using UnityEngine;
using System.Collections;

public class CheetahFollow : MonoBehaviour {

	private Transform player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update ()
	{
		TrackPlayer();
	}
	
	
	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = player.position.x;
		float targetY = player.position.y;
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
