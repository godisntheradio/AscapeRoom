using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingItem : MonoBehaviour
{
    public Manager manager;
    public IItem ItemToGet;
    bool HasGiven;


    Vuforia.VirtualButtonBehaviour ButtonComponent;
    void Start ()
    {
        ButtonComponent = GetComponent<Vuforia.VirtualButtonBehaviour>();
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
        if (manager == null)
        {
            Debug.LogError("Nao acha manager para interação");
        }
    }

    void Update ()
    {
        if (!HasGiven)
        {
            if (ButtonComponent.Pressed)
            {

            }
        }
	}
}
