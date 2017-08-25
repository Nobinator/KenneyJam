using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
	private Rigidbody2D rig;
	public float multi = 2.8f;
	
	// Use this for initialization
	void Start (){
		rig = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update (){

		if (Input.GetKey(KeyCode.Z)){
			Move(-1);
		}
		if (Input.GetKey(KeyCode.C)){
			Move(1);
		}
	}

	void Move(int sign){
		rig.velocity = sign * transform.right * multi;
	}

//	private void OnCollisionStay2D(Collision2D other){
//		Debug.Log("Stay");
//		//if(rig.drag!=dragLock)
//		//rig.drag = dragLock;
//	}
}



// LookAt 2D mouse
//Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
//float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//gun.rotation = Quaternion.AngleAxis(angle, Vector3.forward);