using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
	public float speedOfBullet;
	public float rangeOfBullet;
	GameObject player;
	Vector3 initialPos;
	GameObject gun;
	// Use this for initialization
	void Start () {
		gun = GameObject.Find("Pistol");
		player = GameObject.Find("Player");
		transform.position = gun.transform.position + new Vector3(0, 0, 0);
		initialPos = transform.position;
		transform.rotation = gun.transform.rotation;
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		shootingBullet();
	}

	void shootingBullet()
    {
		if (Vector3.Distance(initialPos, transform.position) < rangeOfBullet)
		{
			//transform.position += transform.up * speedOfBullet;
			this.GetComponent<Rigidbody>().velocity = transform.up * speedOfBullet;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.tag == "Zombie")
        {
			Destroy(col.gameObject);
			player.GetComponent<PlayerControl>().point += 10;
        }
		Destroy(this.gameObject);
    }
}
