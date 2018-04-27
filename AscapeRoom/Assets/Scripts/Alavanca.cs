using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour, IInteractive
{
    CaixaDeForca CaixaRef;

    AudioSource Source;
    [SerializeField]
    AudioClip EnergyOn;
    [SerializeField]
    AudioClip EnergyOff;
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
        Source.clip = EnergyOn;
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
    }

    public void Interact(Item item)
    {
        CaixaRef.PuxarAlavanca();
    }
    public void TurnOnEnergySound()
    {
        Volume = 0.001f;
        Source.clip = EnergyOn;
        Source.Play();
        SetColliderActive(false);
    }
    public void TurnOffEnergySound()
    {
        Volume = 1;
        Source.clip = EnergyOff;
        Source.Play();
        SetColliderActive(false);
    }
    public void FadeOut()
    {
        if (Source.isPlaying && Volume < 1)
        {
            Volume = Mathf.Lerp(Volume, 1, Time.deltaTime * Speed);
            Source.volume = 1 - Volume;
        }
    }
    public void SetColliderActive(bool isActive) // para evitar que clique na regiao da alavanca dispare o som novamente
    {
        GetComponent<BoxCollider>().enabled = isActive;
    }
}
