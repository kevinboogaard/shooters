﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shooter : MonoBehaviour {
	public bool saw;
	public Transform blockjes;
	public GameObject bullet;
	private Transform Target;
	public bool block = true;
	public int aantal = 100;
	public int counter = 0;
	public List<Transform> targets = new List<Transform>();
	
	public enum States
	{
		patrolState,
		chaseState,
		attackState		
	}
	
	public States state;

	void Start () {
		switch (state) {
		case States.patrolState:
			Debug.Log ("Patrol");
			break;
		case States.chaseState:
			Debug.Log ("Chase");
			break;
		case States.attackState:
			break;
		}
	}
	
	void Update () {
		transform.LookAt (Target);

		if (aantal == 0) {
				
			saw = false;
			block = false;
		}
		if (state == States.patrolState && saw == true) {
						state = States.chaseState;

				} else if (state == States.chaseState) {	
						state = States.attackState;
				} else if (state == States.attackState) {
						shoot ();
						state = States.patrolState;
				} else if (saw == false && block == false) {
						Destroy(GetComponent<shooter>());
				}



	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "enemy") {
			Target = other.transform;
			targets.Add(Target);
			saw = true;
		}
	}
	
	void OnTrigeExit(Collider other){
		if (other.tag == "enemy") {
			Target = other.transform;
			targets.Remove(Target);
			saw = false;
		}
	}
	void shoot(){

		if (counter == 0) {
Instantiate (bullet, transform.position, transform.rotation); 
			counter +=30;
				}
		counter --;

		aantal--;
	}
}