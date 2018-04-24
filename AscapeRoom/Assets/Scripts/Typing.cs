using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typing : MonoBehaviour 
{

	string message;

	//float currentInterval;
	public float minInterval;
	public float maxInterval;

	TextMesh text;

	//public AudioClip sound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{		
		text = GetComponent<TextMesh> ();
		message = text.text;
		text.text = "";

		audioSource = GetComponent<AudioSource> ();

		StartCoroutine(Type());
	}

	IEnumerator Type()
	{
		foreach (char letter in message.ToCharArray()) 
		{
			text.text += letter;
			if (audioSource)
				audioSource.Play ();
			yield return new WaitForSeconds (Random.Range (minInterval, maxInterval));
		}
	}
}
