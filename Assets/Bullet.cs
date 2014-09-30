using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	public int speed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other);
		if (other.gameObject.tag == "enemy") {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		
		}
	}
}
