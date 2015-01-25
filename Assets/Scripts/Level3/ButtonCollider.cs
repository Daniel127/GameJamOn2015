using UnityEngine;
using System.Collections;

public class ButtonCollider : MonoBehaviour {

	SeleccionCelda seleccion;

	void Start () {
		seleccion = GameObject.Find("Canvas").GetComponent<SeleccionCelda>();
	}
	
	void Update () {
		if(!seleccion){
			seleccion = GameObject.Find("Canvas").GetComponent<SeleccionCelda>();
		}
		rigidbody2D.velocity = new Vector2(-10, rigidbody2D.velocity.y);
	}

	void DarPosicion(){
		seleccion.SendMessage("ObtenerPosicion",this.gameObject);
	}
}
