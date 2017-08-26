using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class THealthbar : MonoBehaviour{
	public Transform target;
	public Text text;

	public void Set(int h){
		text.text = new string('-',h);
	}

	public void SetTarget(Transform t){
		target = t;
	}

	// Update is called once per frame
	void Update (){
		if (target == null) return;
		transform.position = target.position + Vector3.up;
	}
}
