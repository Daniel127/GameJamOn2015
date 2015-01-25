using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuWin : MonoBehaviour {

	public GameManager gameManager;
	public Text scoreText;

	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		GameObject.DontDestroyOnLoad(this.gameObject);
	}
	
	void Update () {
		scoreText.text = "Score: " + gameManager.GetScore();
	}

	void Next(){
		Debug.Log("Next");
		gameManager.endStage = false;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	void Back(){
		Debug.Log("Back");
		gameManager.SetScore(gameManager.GetScoreAux());
		gameManager.endStage = false;
		Application.LoadLevel(Application.loadedLevel);
	}
}
