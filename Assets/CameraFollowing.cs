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

	private void Start(){
		var hw = Camera.main.orthographicSize * Camera.main.aspect;
		var hh = Camera.main.orthographicSize;
		
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

		var g = new GameObject{name = "Border"};
		var e = g.AddComponent<EdgeCollider2D>();
		e.points = new Vector2[]{
			Vector3.left*left + Vector3.down * down,// left-down
			Vector3.left*left + Vector3.up * up, // left-up
			Vector3.right*right + Vector3.up * up, // right-up
			Vector3.right*right + Vector3.down * down // right-down
		};

	}

	// Update is called once per frame
	void Update (){
		var hw = Camera.main.orthographicSize * Camera.main.aspect;
		var hh = Camera.main.orthographicSize;
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

	private void OnDrawGizmos(){
		Gizmos.color = Color.black;
		Gizmos.DrawLine(Vector3.left*left + Vector3.down * down, Vector3.left*left + Vector3.up * up);
		Gizmos.DrawLine(Vector3.right*right + Vector3.down * down, Vector3.right*right + Vector3.up * up);
		Gizmos.DrawLine(Vector3.down * down + Vector3.left*left, Vector3.down * down + Vector3.right*right);
		Gizmos.DrawLine(Vector3.up * up + Vector3.left*left, Vector3.up * up + Vector3.right*right);
	}
}
