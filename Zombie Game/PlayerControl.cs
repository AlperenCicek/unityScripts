using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {
	public SingleJoystick singleJoystick;
	public Transform myRotationObject;
	public GameObject bomb;
	public GameObject capsule;
	[Space(10)]
	public int health = 100;
	public float moveSpeed = 6.0f;
	public int rotationSpeed = 8;
	public float oxygen = 100;
	public int damageOfSuit = 0;
	public int point = 0;
	public int numberOfBulletInPlayer;
	public int rangeOfJumpping;
	int bombReloadingTime = 0;
	[Space(10)]
	public bool isItRunning;
	public bool isItJumpping;
	public bool isItBombing = false;
	public bool canIChangeTime = true;
	Vector3 input;
	Rigidbody rigidBody;
	int InitialRoj;
	float speedOfDowning = 0.1f;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		isItRunning = false;
		isItJumpping = false;
		InitialRoj = rangeOfJumpping;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Movement();
		Oxygen();
		if (isItBombing)
		{
			Bomb();
		}

		if (isItJumpping)
        {
			if(rangeOfJumpping == 0)
            {
				rangeOfJumpping = InitialRoj;
				Jump();
			}
        }
		ControllingRangeOfJumping();
	}

	void Movement()
    {
		input = singleJoystick.GetInputDirection();
		float xMovementInput = input.x;
		float zMovementInput = input.y;

		if (input == Vector3.zero)
		{
			isItRunning = false;
			//Time.timeScale = 0.1f;
			//bullet.transform.position = transform.position;
			//bullet.transform.rotation = myRotationObject.transform.rotation;
		}
		else
		{
			//Time.timeScale = 1.0f;
			float tempAngle = Mathf.Atan2(zMovementInput, xMovementInput);
			xMovementInput *= Mathf.Abs(Mathf.Cos(tempAngle));
			zMovementInput *= Mathf.Abs(Mathf.Sin(tempAngle));

			input = new Vector3(xMovementInput, 0, zMovementInput);
			input = transform.TransformDirection(input);
			input *= moveSpeed;

			Vector3 temp = transform.position;
			temp.x += xMovementInput;
			temp.z += zMovementInput;
			Vector3 lookingVector = temp - transform.position;
			if (lookingVector != Vector3.zero)
			{
				myRotationObject.localRotation = Quaternion.Slerp(myRotationObject.localRotation, Quaternion.LookRotation(lookingVector), rotationSpeed * Time.deltaTime);
			}
			isItRunning = true;
			rigidBody.transform.Translate(input * Time.fixedDeltaTime);
		}
	}
	void Jump()
    {
		rigidBody.AddForce(1, 150, 1);
		isItJumpping = false;
	}

	void ControllingRangeOfJumping()
    {
		if(rangeOfJumpping != 0)
        {
			rangeOfJumpping--;
		}
	}
	
	void Bomb()
    {
		if (bombReloadingTime == 0)
		{
			Instantiate(bomb, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
			bombReloadingTime = 10;
			isItBombing = false;
		}
		else
		{
			bombReloadingTime--;
		}
	}

	void Oxygen()
    {
		if(oxygen <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
        else
		{
			oxygen -= (damageOfSuit + 1) * speedOfDowning / 10;
		}
		
    }

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Zombie")
		{
			health -= Random.Range(10, 20);
			damageOfSuit += 1;
			if (health <= 0)
            {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	void OnTriggerEnter(Collider coll)
	{
		
		if (coll.gameObject == capsule)
		{
			oxygen = 100f;
			damageOfSuit = 0;
		}
	}

}
