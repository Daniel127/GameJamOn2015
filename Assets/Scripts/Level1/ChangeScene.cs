using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public float time;
	private float aux;
	private GameManager gameManager;

	void Start(){
		aux = Time.time + time;
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.endStage = false;
	}

	void Update () {
		if(Time.time > aux || Input.GetButtonDown("Jump")){
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

}
