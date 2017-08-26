using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTank : MonoBehaviour{

	public int armor = 1;
	public int health = 3;
	public THealthbar bar;

	private void Start(){
		bar.Set(health);
	}

	public bool Damage(int bulletForce){
		if (bulletForce <= armor) return false;
		health--;
		bar.Set(health);
		return true;
	}

	private void Update(){
		if (health <= 0){
			Destroy(this.gameObject);
		}
	}
}
