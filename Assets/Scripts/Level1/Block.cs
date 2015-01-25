using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public float speed = 0.1f;
	public bool directionLeft = false;
	public bool move = true;

	public bool error = false;

	private GameObject blockManager;
	private GameManager gameManager;
	private PlayerMovement playerMovement;
	private Animator animator;

	void Start () {
		blockManager = GameObject.Find("BlockManager");
		if(directionLeft){
			speed *= -1;
		}
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		animator = GameObject.Find("Player").GetComponent<Animator>();
		playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	void Update () {
		if(move){
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.collider.tag == "Player"){
			if(error){
				animator.SetTrigger("RedHit");
				gameManager.AddScore(1);
				playerMovement.audio.PlayOneShot(playerMovement.damage);
			}
			else{
				animator.SetTrigger("GreenHit");
				gameManager.AddScore(-2);
			}
			var sBM = blockManager.GetComponent<BlockManager>();
			sBM.fire = true;
			Destroy(gameObject);
		}
	}
}
