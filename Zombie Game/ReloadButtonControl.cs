using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadButtonControl : MonoBehaviour {
	public GameObject gun;
	//public GameObject player;
	//int numberOfBulletInTheMagazine;
	//int magazineSizeOfTheGun;
	Vector2 touchPos;
	Vector2 butPos;
	// Use this for initialization
	void Start () {
		butPos = new Vector2(Screen.width * 7.5f / 8, Screen.height * 2.5f / 4);
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 9);
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 9);
		//transform.localScale = new Vector2(Screen.width / 1000, Screen.width / 1000);
		transform.position = butPos;
		Input.simulateMouseWithTouches = true;
		//magazineSizeOfTheGun = gun.GetComponent<GunControl>().magazineSize;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.touches[i];
			touchPos = touch.position;
			butPos = transform.position;
			if ( (touchPos.x - butPos.x) < 50 && (touchPos.x - butPos.x) > -50 && (touchPos.y - butPos.y) < 50 && (touchPos.y - butPos.y) > -50)
            {
				person.GetComponent<CubeController>().isItJumpping = true;
			}
			
		}*/
		int fingerCount = 0;
		foreach (Touch touchs in Input.touches)
		{
			if (touchs.phase != TouchPhase.Ended && touchs.phase != TouchPhase.Canceled)
			{
				fingerCount++;

			}
			if (fingerCount > 0)
			{
				Touch touch = touchs;
				touchPos = touch.position;
				butPos = transform.position;
				if ((touchPos.x - butPos.x) < 50 && (touchPos.x - butPos.x) > -50 && (touchPos.y - butPos.y) < 50 && (touchPos.y - butPos.y) > -50)
				{
					/*numberOfBulletInTheMagazine = gun.GetComponent<GunControl>().numberOfBullet;
					if(player.GetComponent<PlayerControl>().numberOfBulletInPlayer > magazineSizeOfTheGun)
                    {
						gun.GetComponent<GunControl>().numberOfBullet = magazineSizeOfTheGun;
						player.GetComponent<PlayerControl>().numberOfBulletInPlayer -= (magazineSizeOfTheGun - numberOfBulletInTheMagazine);
					}
					else
                    {
						gun.GetComponent<GunControl>().numberOfBullet = player.GetComponent<PlayerControl>().numberOfBulletInPlayer;
						player.GetComponent<PlayerControl>().numberOfBulletInPlayer -= player.GetComponent<PlayerControl>().numberOfBulletInPlayer; 
                    }*/
					gun.GetComponent<GunControl>().isItReloading = true;
				}
			}
			else
			{
				return;
			}
		}
	}
}

