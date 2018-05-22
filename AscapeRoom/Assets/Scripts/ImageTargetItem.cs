using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType
{
    SINGLE, COMBINATION
}


public class ImageTargetItem : MonoBehaviour
{
    public string Name;
    public Texture Thumbnail;
    bool HasGiven;

    public TriggerType type;

    Vuforia.TrackableBehaviour targetBehaviour;

    public AudioSource source;
    public AudioClip clip;

    public Vuforia.TrackableBehaviour otherTargetBehaviour;

    public GameObject Result;
    void Start ()
    {
        targetBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
        //otherTargetBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
        if (otherTargetBehaviour != null)
        {
            print("achou");
        }
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
        source.clip = clip;
	}
	
	void Update ()
    {
        if (!HasGiven)
        {
            switch (type)
            {
                case TriggerType.SINGLE:
                    if (targetBehaviour.CurrentStatus == Vuforia.TrackableBehaviour.Status.TRACKED)
                    {
                        GiveItem();
                    }
                    break;
                case TriggerType.COMBINATION:
                    if (targetBehaviour.CurrentStatus == Vuforia.TrackableBehaviour.Status.TRACKED && otherTargetBehaviour.CurrentStatus == Vuforia.TrackableBehaviour.Status.TRACKED)
                    {
                        GiveItem();
                        Result.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    void GiveItem()
    {
        Manager.instance.inventory.AddItem(new Item(Name, Thumbnail));
        Manager.instance.ShowMessage("Você pegou o item " + Name);
        source.Play();
        HasGiven = true;
    }
}
