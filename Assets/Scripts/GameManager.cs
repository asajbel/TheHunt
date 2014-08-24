using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Vector2 box;
	public string instruct; 
	public string gameEnd; 
	public GUIStyle font = new GUIStyle(); 

	private bool gameOver = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Start") && gameOver) {
			Time.timeScale = 1f; 
			Application.LoadLevel(Application.loadedLevelName); 
		}
		if (Input.GetButton("Quit")) {
			Application.Quit(); 
		}
	}

	void OnGUI() {
		if (gameOver) {
			GUI.Box(new Rect(Screen.width/2 - box.x/2, 
			                 Screen.height/2 - box.y/2, 
			                 box.x, 
			                 box.y),
			        gameEnd,
			        font); 
		}
	}

	void ChangeTimeScale() {
		if (Time.timeScale == 0f) Time.timeScale = 1f;
		else Time.timeScale = 0f; 
	}

	public void GameOver() {
		gameOver = true; 
	}
}
