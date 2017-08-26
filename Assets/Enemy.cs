using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
	private const string BULLET_TAG = "Bullet";

	public int armor = 1;

	// Use this for initialization
	void Start(){

	}

	// Update is called once per frame
	void Update(){

	}

	private void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag(BULLET_TAG)){
			var b = other.gameObject.GetComponent<Bullet>();
			if (b.force >= armor){
				Death();
			}
		}
	}

	void Death(){
		
	}

}
