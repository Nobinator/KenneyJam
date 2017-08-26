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
		if(transform.position.magnitude > 100) Destroy(this.gameObject);
	}
}
