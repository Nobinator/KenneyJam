using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour{

	public Transform target;
	public float left;
	public float right;
	public float up;
	public float down;

	private Vector3 vec;

	private float hw,hh;

	private void Start(){
		hw = Camera.main.orthographicSize * Camera.main.aspect;
		hh = Camera.main.orthographicSize;
		
		var x = target.position.x;
		var y = target.position.y;

		if (-left > x - hw){
			vec.x = -left + hw;
		}

		if(x + hw > right){
			vec.x = right-hw;
		}

		if (y + hh > up){
			vec.y = up - hh;
		}

		if(y - hh < -down){
			vec.y = -down + hh;
		}
		
		
	}

	// Update is called once per frame
	void Update (){

		var x = target.position.x;
		var y = target.position.y;


		if (-left < x - hw && x + hw < right){
			vec.x = x;
		}
		if (y + hh < up && y - hh > -down){
			vec.y = y;
		}
		
		this.transform.position = vec;
	}

	private void OnDrawGizmosSelected(){
		Gizmos.color = Color.black;
		Gizmos.DrawLine(Vector3.left*left + Vector3.down * down, Vector3.left*left + Vector3.up * up);
		Gizmos.DrawLine(Vector3.right*right + Vector3.down * down, Vector3.right*right + Vector3.up * up);
		Gizmos.DrawLine(Vector3.down * down + Vector3.left*left, Vector3.down * down + Vector3.right*right);
		Gizmos.DrawLine(Vector3.up * up + Vector3.left*left, Vector3.up * up + Vector3.right*right);
	}
}
