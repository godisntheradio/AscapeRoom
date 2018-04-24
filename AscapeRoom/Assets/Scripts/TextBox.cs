using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

	Vector2 originalSize;

	// Use this for initialization
	void Start () 
	{
		var rt = GetComponent<RectTransform> ();
		originalSize = new Vector2 (rt.rect.width, rt.rect.height);
		Resize ();
	}

	void Resize()
	{
		RectTransform[] allRT = GetComponentsInChildren<RectTransform> ();

		foreach (var rt in allRT) 
		{
			float yscale = Screen.height / 1080f;
			float xscale = Screen.width / originalSize.x;

			//rt.localScale = new Vector3 (xscale, yscale, 1f);
			rt.sizeDelta = new Vector3 (xscale * originalSize.x, yscale * originalSize.y, 1f);
		}
		allRT[0].position = new Vector3 (allRT[0].position.x, (allRT[0].rect.height / 2f) /* yscale*/, allRT[0].position.z);
	}

	// Update is called once per frame
	void Update () 
	{
		if (ScaleUI.Resized)
			Resize ();
	}

	public void Toggle(bool show)
	{
		gameObject.SetActive (show);
	}

	public void SetMessage(string message)
	{
		GetComponentInChildren<Text> ().text = message;
	}
}
