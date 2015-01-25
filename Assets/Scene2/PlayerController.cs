using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float forceJump = 10f;
	public float speed = 4f;
	public LayerMask layerMaskGround;
	public Transform testerGround;

	private bool running = false;
	public bool inGround = true;
	private float testerRadius = 0.5f;
	private bool doubleJump;
	private Animator animator;

	public AudioClip item;
	public AudioClip salto;
	public AudioClip final;

	void Awake(){
		animator = gameObject.GetComponent<Animator>();
	}

	void FixedUpdate(){
		if(running){
			rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
		}
		animator.SetFloat("Speed", rigidbody2D.velocity.x);
		inGround = Physics2D.OverlapCircle(testerGround.position, testerRadius, layerMaskGround);
		animator.SetBool("isGrounded",inGround);
		if(inGround){
			doubleJump = false;
		}
	}

	void Update () {
		if(Input.GetButtonDown("Jump")){
			audio.PlayOneShot(salto);
			if(running){
				if(inGround || !doubleJump){
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, forceJump);
					if(!inGround || !doubleJump){
						doubleJump = true;	
					}
				}
			}
			else{
				running = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "PlayerStart");
			}
		}
	}
}
