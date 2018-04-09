using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    void OnClick()
    {
        GameObject.Find("GameManager").GetComponent<Manager>().inventory.Select(int.Parse(transform.parent.name));
    }

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
	}
}
