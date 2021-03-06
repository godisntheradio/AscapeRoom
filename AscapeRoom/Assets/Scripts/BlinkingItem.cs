﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingItem : MonoBehaviour
{
    public string Name;
    public Texture Thumbnail;
    bool HasGiven;

    public GameObject emiter;

    public AudioSource source;
    public AudioClip clip;

    Vuforia.VirtualButtonBehaviour ButtonComponent;
    void Start ()
    {
        HasGiven = false;
        ButtonComponent = GetComponent<Vuforia.VirtualButtonBehaviour>();
        if (Manager.instance == null)
        {
            Debug.LogError("Nao acha manager para interação");
        }
        source = gameObject.AddComponent<AudioSource>();
        source.loop = false;
        source.playOnAwake = false;
        source.clip = clip;
    }

    void Update ()
    {
        if (!HasGiven)
        {
            if (ButtonComponent.Pressed)
            {
                Manager.instance.inventory.AddItem(new Item(Name, Thumbnail));
                Manager.instance.ShowMessage("Você pegou o item " + Name);
                source.Play();
                HasGiven = true;
                emiter.SetActive(false);
            }
        }
	}
}
