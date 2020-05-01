using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackOfBulletsControl : MonoBehaviour {
	public GameObject player;
	public int numberOfAdditionBullets;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject == player)
		{
			player.GetComponent<PlayerControl>().numberOfBulletInPlayer += numberOfAdditionBullets;
		}
		Destroy(this.gameObject);
	}
}
