using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	public GameObject bullet;
	public GameObject player;
	public bool isItBulleting;
	public bool isItReloading;
	int reloadingTimeOfBullet = 10;
	int reloadingTimeBulletCount;
	int reloadingTimeOfMagazine = 10;
	int reloadingTimeMagazineCount;
	public int magazineSizeOfTheGun;
	public int numberOfBullet;
	int numberOfBulletInTheMagazine;
	// Use this for initialization
	void Start () {
		isItBulleting = false;
		reloadingTimeBulletCount = reloadingTimeOfBullet;
		reloadingTimeMagazineCount = reloadingTimeOfMagazine;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (isItBulleting)
        {
			ShootControl();
		}
		if(isItReloading)
        {
			MagazineControl();
        }
	}

	void ShootControl()
    {
		if (reloadingTimeBulletCount == reloadingTimeOfBullet)
		{
			if (numberOfBullet > 0)
			{
				Instantiate(bullet, transform.position, Quaternion.identity);
				reloadingTimeBulletCount = 0;
				numberOfBullet--;
			}
		}
		isItBulleting = false;
		ReloadingOfBullet();
	}
	void ReloadingOfBullet()
    {
		if (reloadingTimeBulletCount != reloadingTimeOfBullet)
		{
			reloadingTimeBulletCount++;
		}
	}
	void ReloadingOfMagazine()
	{
		if (reloadingTimeMagazineCount != reloadingTimeOfMagazine)
		{
			reloadingTimeMagazineCount++;
		}
	}

	void MagazineControl()
    {
		if (reloadingTimeMagazineCount == reloadingTimeOfMagazine)
		{
			numberOfBulletInTheMagazine = numberOfBullet;
			if (player.GetComponent<PlayerControl>().numberOfBulletInPlayer >= magazineSizeOfTheGun)
			{
				numberOfBullet = magazineSizeOfTheGun;
				player.GetComponent<PlayerControl>().numberOfBulletInPlayer -= (magazineSizeOfTheGun - numberOfBulletInTheMagazine);
			}
			else
			{
				if(numberOfBullet + player.GetComponent<PlayerControl>().numberOfBulletInPlayer > magazineSizeOfTheGun)
                {
					player.GetComponent<PlayerControl>().numberOfBulletInPlayer -= (magazineSizeOfTheGun - numberOfBullet);
					numberOfBullet = magazineSizeOfTheGun;
				}
                else
				{
					numberOfBullet = player.GetComponent<PlayerControl>().numberOfBulletInPlayer + numberOfBullet;
					player.GetComponent<PlayerControl>().numberOfBulletInPlayer -= player.GetComponent<PlayerControl>().numberOfBulletInPlayer;
				}
			}
			print(player.GetComponent<PlayerControl>().numberOfBulletInPlayer);
			print(numberOfBullet);
			reloadingTimeMagazineCount = 0;
		}
		isItReloading = false;
		ReloadingOfMagazine();
	}
}
