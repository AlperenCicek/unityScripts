using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	GameObject player;
	public int distanceOfView;
	public float speedOfZombie;
	float targetInitialPosY = 0.5f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Body");
	}

	// Update is called once per frame
	void Update()
	{
		if(rangeOfView())
			movingZombie();
	}
	
	bool rangeOfView()
    {
		if(Vector3.Distance(player.transform.position, transform.position) < distanceOfView)
			return true;
        else
			return false;
    }
	void movingZombie()
	{
		transform.LookAt(new Vector3(player.transform.position.x, targetInitialPosY, player.transform.position.z));
		this.GetComponent<Rigidbody>().velocity = transform.forward * speedOfZombie;
		//transform.position += transform.forward * speedOfZombie / 50;
	}
}
