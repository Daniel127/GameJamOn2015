using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public int score = 0;

	private Text text;

	void Start (){
		NotificationCenter.DefaultCenter().AddObserver(this,"AddScore");
		text = GetComponent<Text>();
	}

	void AddScore(Notification notification){
		score += (int) notification.data;
	}

	void Update () {
		text.text = "Score: " + score; 
	}
}
