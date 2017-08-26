using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TMovement : MonoBehaviour {

	private Rigidbody2D rig;
	
	void Start (){
		rig = GetComponent<Rigidbody2D>();
	}

	public float speed;
	public float backSpeed;
	public float angularSpeed;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.D)){
			rig.rotation -= angularSpeed;
		}
		if (Input.GetKey(KeyCode.A)){
			rig.rotation += angularSpeed;
		}
		if (Input.GetKey(KeyCode.W)){
			rig.velocity = transform.up * speed;
		}
		if (Input.GetKey(KeyCode.S)){
			rig.velocity = transform.up * backSpeed;
		}

	}

	private void OnDrawGizmos(){
		Gizmos.DrawLine(transform.position, transform.position + transform.up);
	}
}


//float x = Input.GetAxis("Horizontal");
//float y = Input.GetAxis("Vertical");
//var target = new Vector2(x, y) * 4f;
//if (target.magnitude > 1f){
////direction = Vector3.Lerp(direction, target, 0.07f);
//transform.up = - Vector3.Slerp(-transform.up, target, 0.07f);
//rig.velocity = -transform.up * speed;
