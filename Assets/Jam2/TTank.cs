using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTank : MonoBehaviour{

	public int armor = 1;
	public int health = 3;

	public bool Damage(int bulletForce){
		if (bulletForce <= armor) return false;
		health--;
		return true;
	}

	private void Update(){
		if (health <= 0){
			Destroy(this.gameObject);
		}
	}
}
