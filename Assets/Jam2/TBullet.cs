using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBullet : MonoBehaviour{
	
	
	private Rigidbody2D rig;
	public float speed;
	private Collider2D coll;

	private int force = 1;
	
	public void Shot(float velo){
		coll = GetComponent<Collider2D>();
		rig = GetComponent<Rigidbody2D>();
		rig.velocity = transform.up*velo;
	}
	
	void Update () {
		if(transform.position.magnitude > 30) Destroy(this.gameObject);

		AlignWithVelocity();
	}

	private Vector2 oldvelo;
	
	void AlignWithVelocity(){
		if (oldvelo != rig.velocity){
			float angle = Mathf.Atan2(rig.velocity.y, rig.velocity.x) * Mathf.Rad2Deg -90;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			rig.angularVelocity = 0;
		}
		oldvelo = rig.velocity;
	}


	private void OnTriggerExit2D(Collider2D other){
		// При выходе из коллайдера стрелявшего
		Debug.Log("Trigexit");
		
		coll.isTrigger = false;
	}

//	private void OnCollisionExit2D(Collision2D other){
//		Debug.Log("collexit");
//	}

	private void OnCollisionEnter2D(Collision2D other){
		if (coll.isTrigger) return;
		
		Debug.Log(other.gameObject.tag);

		if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy")){
			var t = other.gameObject.GetComponent<TTank>();
			if (t.Damage(force)){
				Debug.Log("Explosion");
				Explosion();
			}
			else{
				Debug.Log("Bounce");
				Bounce();
			}
		}
		else{
			Bounce();
		}
	}

	void Bounce(){
		force++;
	}


	void Explosion(){
		// play anim
		Destroy(this.gameObject);
	}
}
