using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour {
	public GameObject player;
	public GameObject gun;
	[Space(10)]
	public GameObject pointTextValue;
	public GameObject pointImage;
	[Space(10)]
	public GameObject bulletTextValue;
	public GameObject bulletImage;
	[Space(10)]
	public GameObject gunTextValue;
	public GameObject gunImage;
	[Space(10)]
	public GameObject oxygenTextValue;
	public GameObject oxygenImage;
	[Space(10)]
	public GameObject healthTextValue;
	public GameObject healthImage;
	[Space(10)]
	public GameObject suitTextValue;
	public GameObject suitImage;
	// Use this for initialization
	void Start () {
		pointImage.transform.position = new Vector2(Screen.width * 1 / 8, Screen.height * 3.7f / 4);
		pointImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		pointImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 19);
		pointTextValue.transform.position = new Vector2(Screen.width * 1.5f / 8, Screen.height * 3.7f / 4);
		pointTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().point;
		pointTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		pointTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 38);

		oxygenImage.transform.position = new Vector2(Screen.width * 2 / 8, Screen.height * 3.7f / 4);
		oxygenImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		oxygenImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 19);
		oxygenTextValue.transform.position = new Vector2(Screen.width * 2.5f / 8, Screen.height * 3.7f / 4);
		oxygenTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().oxygen;
		oxygenTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		oxygenTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 38);

		healthImage.transform.position = new Vector2(Screen.width * 3 / 8, Screen.height * 3.7f / 4);
		healthImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		healthImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 19);
		healthTextValue.transform.position = new Vector2(Screen.width * 3.4f / 8, Screen.height * 3.7f / 4);
		healthTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().health;
		healthTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		healthTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 38);

		suitImage.transform.position = new Vector2(Screen.width * 4 / 8, Screen.height * 3.7f / 4);
		suitImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		suitImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 19);
		suitTextValue.transform.position = new Vector2(Screen.width * 4.5f / 8, Screen.height * 3.7f / 4);
		suitTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().damageOfSuit;
		suitTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		suitTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 38);

		bulletImage.transform.position = new Vector2(Screen.width * 5 / 8, Screen.height * 3.7f / 4);
		bulletImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 19);
		bulletImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		bulletTextValue.transform.position = new Vector2(Screen.width * 5.5f / 8 , Screen.height * 3.7f / 4);
		bulletTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().numberOfBulletInPlayer;
		bulletTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		bulletTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 38);
		
		gunImage.transform.position = new Vector2(Screen.width * 6 / 8, Screen.height * 3.7f / 4);
		gunImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 19);
		gunImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		gunTextValue.transform.position = new Vector2(Screen.width * 6.4f / 8, Screen.height * 3.7f / 4);
		gunTextValue.GetComponent<Text>().text = "" + gun.GetComponent<GunControl>().numberOfBullet;
		gunTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		gunTextValue.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 38);

	}
	
	// Update is called once per frame
	void Update () {
		pointTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().point;
		bulletTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().numberOfBulletInPlayer;
		gunTextValue.GetComponent<Text>().text = "" + gun.GetComponent<GunControl>().numberOfBullet;
		oxygenTextValue.GetComponent<Text>().text = "" + (int)player.GetComponent<PlayerControl>().oxygen;
		healthTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().health;
		suitTextValue.GetComponent<Text>().text = "" + player.GetComponent<PlayerControl>().damageOfSuit;
	}
}
