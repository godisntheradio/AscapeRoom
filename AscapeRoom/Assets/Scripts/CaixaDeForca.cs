using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeForca : MonoBehaviour, IInteractive
{
    private GameObject key;
    private bool playing = false;
    private Animator animator;
    private bool HasBeenUsed;

    AudioSource source;

    void Start ()
    {
        animator = GetComponent<Animator>();
        key = GameObject.Find("Key");
        if (key == null)
        {
            Debug.LogError("Couldn't find key");
        }
        key.SetActive(false);
        HasBeenUsed = false;
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogError("Couldn't find audioSource");
        }
        source.playOnAwake = false;
        source.loop = false;
    }
	void Update ()
    {
		if (playing)
        {
            if(animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Base Layer")).IsName("End"))
            {
                key.SetActive(false);
                playing = false;
            }
        }
	}
    public void Inspect()
    {
        if (!HasBeenUsed)
        {
            // mensagem para o jogador dizendo que está trancado e precisa de uma chave
        }
        else
        {
            // mensagem para o jogador que não precisa fazer mais nada com esse objeto
        }
    }

    public void Interact(Item item)
    {
        if(item.Name == "Key" && !HasBeenUsed)
        {
            key.SetActive(true);
            source.Play();
            animator.SetBool("Abrir", true);
            playing = true;
            GetComponent<BoxCollider>().enabled = false;
            HasBeenUsed = true;
        }
    }
    public void PuxarAlavanca()
    {
        animator.SetBool("PuxarAlavanca", true);
    }
}
