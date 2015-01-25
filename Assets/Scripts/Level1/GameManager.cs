using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int score = 0;
	private int scoreStartScene = 0;

	public GameObject menuWin;
	public bool endStage = false;

	void Start () {
		GameObject.DontDestroyOnLoad(this.gameObject);
		menuWin = GameObject.FindGameObjectWithTag("MenuWin");
		DesactivarMenu();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.S)){
			Debug.Log("El score es: " + score);
		}

		if(Application.isLoadingLevel){
			scoreStartScene = score;
			endStage = false;
		}

		if(endStage){
			ActivarMenu();
			Debug.Log("Activar");
		}
		else{
			DesactivarMenu();
		}
	}

	public void AddScore(int points){
		this.score += points;
	}

	public int GetScore(){
		return this.score;
	}

	public void SetScore(int score){
		this.score = score;
	}

	public int GetScoreAux(){
		return this.scoreStartScene;
	}

	public void ActivarMenu(){
		menuWin.SetActive(true);
	}
	
	public void DesactivarMenu(){
		menuWin.SetActive(false);
	}
}
