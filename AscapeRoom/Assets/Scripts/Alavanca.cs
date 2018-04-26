using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour, IInteractive
{
    CaixaDeForca CaixaRef;

    AudioSource Source;
    [SerializeField]
    AudioClip Energy;
    float Volume;
    public float Speed;

    void Start ()
    {
        CaixaRef = GetComponentInParent<CaixaDeForca>();
        Source = GetComponentInParent<AudioSource>();
        if (CaixaRef == null || Source == null)
        {
            Debug.LogError("Couldn't correctly initialize alavanca");
        }
        Source.clip = Energy;
        Source.volume = 1;
        Volume = 0.001f;
	}
	void Update ()
    {
        FadeOut();
	}
    public void Inspect()
    {
        CaixaRef.PuxarAlavanca();
        TurnOnEnergySound();
    }

    public void Interact(Item item)
    {
        CaixaRef.PuxarAlavanca();
        TurnOnEnergySound();

    }
    public void TurnOnEnergySound()
    {
        Source.Play();
        GetComponent<BoxCollider>().enabled = false; // para evitar que outro clique na regiao da alavanca dispare o som novamente
    }
    public void FadeOut()
    {
        if (Source.isPlaying && Volume < 1)
        {
            Volume = Mathf.Lerp(Volume, 1, Time.deltaTime * Speed);
            Source.volume = 1 - Volume;
        }
    }
}
