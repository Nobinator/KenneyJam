using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBullet : MonoBehaviour{
	
	
	private Rigidbody2D rig;
	public float speed;
	
	public void Shot(float velo){
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
		
		GetComponent<Collider2D>().isTrigger = false;
	}

	private void OnCollisionExit2D(Collision2D other){
		Debug.Log("collexit");
		
		//GetComponent<Collider2D>().isTrigger = false;
	}
}
