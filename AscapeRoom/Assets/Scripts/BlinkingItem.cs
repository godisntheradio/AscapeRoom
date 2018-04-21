using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingItem : MonoBehaviour
{
    public string Name;
    public Texture Thumbnail;
    bool HasGiven;

    public GameObject emiter;

    Vuforia.VirtualButtonBehaviour ButtonComponent;
    void Start ()
    {
        HasGiven = false;
        ButtonComponent = GetComponent<Vuforia.VirtualButtonBehaviour>();
        if (Manager.instance == null)
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
                Manager.instance.inventory.AddItem(new Item(Name, Thumbnail));
                HasGiven = true;
                emiter.SetActive(false);
            }
        }
	}
}
