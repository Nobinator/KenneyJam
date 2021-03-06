﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour{

	public GameObject bulletPrefab;

	public float rotationSpeed = 2f;
	public float upAngleLimit = 45f;
	public float downAngleLimit = 1f;
	public Transform gunRoot;
	public float bulletSpeed = 1f;
	
	
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)){
			Rotate(1);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			Rotate(-1);
		}

		if (/*!Reloading() &&*/ Input.GetKeyDown(KeyCode.X)){
			Shoot();
		}
	}

	void Rotate(int sign){

		var locangle = gunRoot.localRotation.eulerAngles.z > 180
			? gunRoot.localRotation.eulerAngles.z - 360
			: gunRoot.localRotation.eulerAngles.z;
		
		if (locangle >= upAngleLimit && sign == 1){
			
			//Debug.Log(string.Format("UP!{0} {1} {2}",gunRoot.localRotation.eulerAngles.z,upAngleLimit,sign));
			gunRoot.localRotation = Quaternion.AngleAxis(upAngleLimit,Vector3.forward);
			return;
		}
		if (locangle <= downAngleLimit && sign == -1){
			
			//Debug.Log(string.Format("UP!{0} {1} {2}",gunRoot.localRotation.eulerAngles.z,downAngleLimit,sign));
			gunRoot.localRotation = Quaternion.AngleAxis(downAngleLimit,Vector3.forward);
			//Debug.Log("DOWN!");
			return;
		}
		
		gunRoot.Rotate(Vector3.forward,sign * rotationSpeed);
	}

	private const float reloadingTime = 2f;
	public float reloading = reloadingTime;

	bool Reloading(){
		if (reloading <= 0) return false;
		reloading -= Time.deltaTime;
		return true;
	}

	void Shoot(){
		Debug.Log("Shot!");

		var b = Instantiate(bulletPrefab, gunRoot.position, gunRoot.rotation, null);
		b.GetComponent<Bullet>().Shot(bulletSpeed);
		reloading = reloadingTime;
	}
}
