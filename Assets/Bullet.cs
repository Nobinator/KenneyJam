using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Rigidbody2D rig;

	public int force;

	public void Shot(float velo){
		rig = GetComponent<Rigidbody2D>();
		rig.velocity = transform.right*velo;
	}

	void Update(){
		if (transform.position.y < -10) Destroy(this.gameObject);
	}
}
