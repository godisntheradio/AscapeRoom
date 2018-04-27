using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeForca : MonoBehaviour, IInteractive
{
    private GameObject Key;
    private bool Playing = false;
    private Animator AnimatorRef;

    Alavanca AlavancaRef;

    AudioSource Source;
    [SerializeField]
    AudioClip Open;
    [SerializeField]
    AudioClip Close;
    void Start ()
    {
        //alvanca initialization
        AlavancaRef = GetComponentInChildren<Alavanca>();
        AlavancaRef.SetColliderActive(false);
        //animator
        AnimatorRef = GetComponent<Animator>();
        // Key initialization
        Key = GameObject.Find("Key");
        if (Key == null)
        {
            Debug.LogError("Couldn't find key");
        }
        Key.SetActive(false);
        
        //audio init
        Source = GetComponent<AudioSource>();
        if (Source == null)
        {
            Debug.LogError("Couldn't find audioSource");
        }
        Source.playOnAwake = false;
        Source.loop = false;
        Source.clip = Open;
    }
	void Update ()
    {
		if (Playing)
        {
            if(AnimatorRef.GetCurrentAnimatorStateInfo(AnimatorRef.GetLayerIndex("Base Layer")).IsName("Ligado") && AnimatorRef.GetBool("PuxarAlavanca"))
            {
                AnimatorRef.SetBool("Abrir", false);
                AnimatorRef.SetBool("PuxarAlavanca", false);
                AlavancaRef.SetColliderActive(false);

                Key.SetActive(false);
                Playing = false;
            }
            if (AnimatorRef.GetCurrentAnimatorStateInfo(AnimatorRef.GetLayerIndex("Base Layer")).IsName("Desligado") && AnimatorRef.GetBool("PuxarAlavanca_desligar"))
            {
                AnimatorRef.SetBool("Abrir_desligar", false);
                AnimatorRef.SetBool("PuxarAlavanca_desligar", false);
                AlavancaRef.SetColliderActive(false);

                Key.SetActive(false);
                Playing = false;
            }
        }
	}
    public void Inspect()
    {
        if (true)
        {
            Manager.instance.ShowMessage("Está trancado");
        }
        else
        {
            // mensagem para o jogador que não precisa fazer mais nada com esse objeto
        }
    }

    public void Interact(Item item)
    {
        if(item.Name == "Key" && !Manager.instance.HasEnergy)
        {
            TurnOnEnergy();
        }
        else if (item.Name == "Key" && Manager.instance.HasEnergy)
        {
            TurnOffEnergy();
        }
        
    }
    public void PuxarAlavanca()
    {
        if (!Manager.instance.HasEnergy) //aqui fica ao contrario pq tem que sincronizar os bools com as animações no update
        {
            AnimatorRef.SetBool("PuxarAlavanca", true);
            AlavancaRef.TurnOnEnergySound();
            Manager.instance.HasEnergy = true;
            Manager.instance.ShowMessage("Você ligou a energia!");
        }
        else
        {
            AnimatorRef.SetBool("PuxarAlavanca_desligar", true);
            AlavancaRef.TurnOffEnergySound();
            Manager.instance.ShowMessage("Você desligou a energia!");
            Manager.instance.HasEnergy = false;
        }
        SetColliderActive(true);

        Source.clip = Close;
        Source.Play();
    }
    void TurnOnEnergy()
    {
        Key.SetActive(true); // mostra a chave
        AnimatorRef.SetBool("Abrir", true); //ativa a animação
        Playing = true;
        SetColliderActive(false);
        AlavancaRef.SetColliderActive(true);
        Source.Play();

    }
    void TurnOffEnergy()
    {
        Key.SetActive(true); // mostra a chave
        AnimatorRef.SetBool("Abrir_desligar", true); //ativa a animação
        Playing = true;
        SetColliderActive(false);
        AlavancaRef.SetColliderActive(true);
        Source.Play();

    }
    public void SetColliderActive(bool isActive) // para evitar que clique na regiao da alavanca dispare o som novamente
    {
        GetComponent<BoxCollider>().enabled = isActive;
    }
}
