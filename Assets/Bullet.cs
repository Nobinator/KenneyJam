using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Rigidbody2D rig;
	

	public void Shot(float velo){
		rig = GetComponent<Rigidbody2D>();
		rig.velocity = transform.right*velo;
	}
}
