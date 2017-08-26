using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShooting : MonoBehaviour{
	public Transform gunRoot;
	public GameObject bulletPrefab;
	
	public float bulletSpeed = 1f;
	// Use this for initialization
	void Start(){

	}

	// Update is called once per frame
	void Update(){
		LookAtMouse();
		
		if (/*!Reloading() &&*/ Input.GetKeyDown(KeyCode.Mouse0)){
			Shoot();
		}
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
		b.GetComponent<TBullet>().Shot(bulletSpeed);
		reloading = reloadingTime;
	}

	void LookAtMouse(){
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(gunRoot.position);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
		gunRoot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
