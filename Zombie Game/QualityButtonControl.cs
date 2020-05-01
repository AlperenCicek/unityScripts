using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityButtonControl : MonoBehaviour {
	public int level = 0;
	Vector2 touchPos;
	Vector2 butPos;
	// Use this for initialization
	void Start () {
		QualitySettings.SetQualityLevel(level, true);
		butPos = new Vector2(Screen.width * 0.5f / 8, Screen.height * 3.7f / 4);
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.width / 19);
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 19);
		transform.position = butPos;
		Input.simulateMouseWithTouches = true;
	}
	
	// Update is called once per frame
	void Update () {
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
					level++;
					if (level == 6)
						level = 0;
					QualitySettings.SetQualityLevel(level, true);
				}
			}
			else
			{
				return;
			}
		}

	}
}
