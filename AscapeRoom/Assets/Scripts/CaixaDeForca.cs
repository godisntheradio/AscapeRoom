using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeForca : MonoBehaviour, IInteractive
{
    private GameObject Key;
    private bool Playing = false;
    private Animator AnimatorRef;
    private bool HasBeenUsed;

    AudioSource source;
    [SerializeField]
    AudioClip Open;
    [SerializeField]
    AudioClip Close;
    void Start ()
    {
        AnimatorRef = GetComponent<Animator>();
        Key = GameObject.Find("Key");
        if (Key == null)
        {
            Debug.LogError("Couldn't find key");
        }
        Key.SetActive(false);
        HasBeenUsed = false;
        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogError("Couldn't find audioSource");
        }
        source.playOnAwake = false;
        source.loop = false;
        source.clip = Open;
    }
	void Update ()
    {
		if (Playing)
        {
            if(AnimatorRef.GetCurrentAnimatorStateInfo(AnimatorRef.GetLayerIndex("Base Layer")).IsName("End"))
            {
                Key.SetActive(false);
                Playing = false;
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
            Key.SetActive(true);
            AnimatorRef.SetBool("Abrir", true);
            Playing = true;
            GetComponent<BoxCollider>().enabled = false;
            HasBeenUsed = true;
            source.Play();
        }
    }
    public void PuxarAlavanca()
    {
        AnimatorRef.SetBool("PuxarAlavanca", true);
        source.clip = Close;
        source.Play();
    }
}
