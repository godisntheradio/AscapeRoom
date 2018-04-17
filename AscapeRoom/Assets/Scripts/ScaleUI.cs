using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUI : MonoBehaviour 
{
	int screenHeight;
	static bool resized = false;
	public static bool Resized { get { return resized; } }

	void Awake()
	{
		Resize();
	}

	// Use this for initialization
	void Resize () 
	{
		screenHeight = Screen.height;

		RectTransform rt = gameObject.GetComponent<RectTransform>();
		float yScl = Screen.height / 1080f;
		float xScl = yScl;

		rt.transform.localScale = new Vector3 (xScl, yScl, 1f);

		rt.position = new Vector3((-rt.rect.width * rt.localScale.x)/2f, rt.position.y, rt.position.z);
	}

	void Update()
	{
		if (Screen.height != screenHeight) 
		{
			Resize ();
			resized = true;
		} 
		else
			resized = false;
	}
}
