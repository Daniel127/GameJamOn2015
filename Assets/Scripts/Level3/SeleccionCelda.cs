using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class SeleccionCelda : MonoBehaviour {

	[System.Serializable]
	private class FilaCeldas{
		public int[] indexCartas;
		public int seleccionado;
		public bool seleccionar;
		public GameObject[] cartas;

		public void generar(){
			for(int i = 0; i < indexCartas.Length; i++){
				var noValido = true;
				int n = 0;
				while(noValido){
					noValido = false;
					n = Random.Range(1,5);
					for(int j = 0; j < indexCartas.Length; j++){
						if(n == indexCartas[j]){
							noValido = true;
						}
					}
				}
				indexCartas[i] = n;
			}
		}

		public void detectarColision(){
		}

	}

	[SerializeField]
	FilaCeldas[] filas;
	public Sprite[] cartas;
	public Sprite baseCarta;
	public GameObject pivot;
	public GameObject[] equis;

	private Animator animator;
	private GameManager gameManager;
	private int destruidas = 0;

	public AudioClip giro;

	void Start(){
		foreach(FilaCeldas fila in filas){
			fila.generar();
		}
		animator = GameObject.Find("Overlord").GetComponent<Animator>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		//insertarImagenes();
	}

	void Update(){
		if(Seleccionados()){
			if(comprobarSeleccion()){
				Debug.Log("Iguales");
				animator.SetTrigger("Correct");
				DestruirSeleccionados();
				PermitirSeleccion();
				gameManager.AddScore(10);
				destruidas++;
			}else{
				Debug.Log("Distintos");
				StartCoroutine(GirarCartas());
			}
		}
		if(destruidas >= 4){
			gameManager.endStage = true;
		}
		///pivot.transform.Translate(Vector3.left * 5 * Time.deltaTime);
	}

	void ObtenerPosicion(GameObject boton){
		foreach(FilaCeldas fila in filas){
			for(int i = 0; i < fila.cartas.Length; i++){
				if(boton.GetInstanceID() == fila.cartas[i].GetInstanceID()){
					if(fila.seleccionar){
						fila.seleccionado = i;
						audio.PlayOneShot(giro);
						fila.cartas[i].GetComponent<Image>().sprite = cartas[fila.indexCartas[i] - 1];
						fila.seleccionar = false;
					}
				}
			}
		}
	}

	void insertarImagenes(){
		foreach(FilaCeldas fila in filas){
			for(int i = 0; i < cartas.Length; i++){
				fila.cartas[i].GetComponent<Image>().sprite = cartas[fila.indexCartas[i] - 1];
			}
		}
	}

	void PermitirSeleccion(){
		foreach(FilaCeldas fila in filas){
			fila.seleccionar = true;
		}
	}

	bool Seleccionados(){
		foreach(FilaCeldas fila in filas){
			if(fila.seleccionar){
				return false;
			}
		}
		return true;
	}

	bool comprobarSeleccion(){
		bool iguales = true;
		for(int i = 0; i < filas.Length - 1; i++){
			if(filas[i].indexCartas[filas[i].seleccionado] != filas[i+1].indexCartas[filas[i+1].seleccionado]){
				iguales = false;
			}
		}
		return iguales;
	}

	void DestruirSeleccionados(){
		equis[filas[0].indexCartas[filas[0].seleccionado] - 1].SetActive(true);
		foreach(FilaCeldas fila in filas){
			fila.cartas[fila.seleccionado].SetActive(false);
		}
	}

	IEnumerator GirarCartas(){
		yield return new WaitForSeconds(1);
		foreach(FilaCeldas fila in filas){
			fila.cartas[fila.seleccionado].GetComponent<Image>().sprite = baseCarta;
		}
		PermitirSeleccion();
	}
}
