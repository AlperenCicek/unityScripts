using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour {
	bool count = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(count)
		{
			GetComponent<Rigidbody>().AddForce((transform.up * 150));
			count = false;
		}
		transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
		Destroy(this.gameObject, 3);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Zombie")
		{
			Destroy(col.gameObject);
		}
	}

}
