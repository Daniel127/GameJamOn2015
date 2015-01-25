using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	void Update () {
		if(Input.GetButtonDown("Jump")){
			Application.LoadLevel(1);
		}
	}	
}
