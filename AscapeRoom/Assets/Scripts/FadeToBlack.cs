using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    Image imageRef;
	void Start ()
    {
        imageRef = GetComponent<Image>();
        imageRef.color = new Color(imageRef.color.r, imageRef.color.g, imageRef.color.b, 0);
        imageRef.enabled = false;
	}
	
	void Update ()
    {
        if (Manager.instance.IsGameOver)
        {
            Fade();
        }
	}
    void Fade()
    {
        imageRef.enabled = true;

        float alpha = Mathf.Lerp(imageRef.color.a, 1, Time.deltaTime);
        imageRef.color = new Color(imageRef.color.r, imageRef.color.g, imageRef.color.b, alpha);
    }

}
