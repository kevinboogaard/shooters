using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shooter : MonoBehaviour {
	public bool saw;
	public bool inrange;
	public Transform blockjes;
	public GameObject bullet;
	private Transform Target;
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

		if (state == States.patrolState && saw == true) {
			state = States.chaseState;

		}
		else if (state == States.chaseState && inrange == true) {	
			state = States.attackState;
		}
		else if(state == States.attackState)
		{
			shoot();
			state = States.patrolState;
		}



	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "enemy") {
			Target = other.transform;
			targets.Add(Target);
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "enemy") {
			Target = other.transform;
			targets.Remove(Target);
		}
	}

	void shoot(){
		Instantiate(bullet, transform.position, transform.rotation);
	}
}