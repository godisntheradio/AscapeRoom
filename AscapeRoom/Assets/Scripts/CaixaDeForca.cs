using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeForca : MonoBehaviour, IInteractive
{
    private GameObject key;
    private bool playing = false;
    private Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
        key = GameObject.Find("Key").gameObject;
        key.SetActive(false);
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
        //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), transform);
    }

    public void Interact(Item item)
    {
        if(item.Name == "Key")
        {
            key.SetActive(true);
            animator.SetBool("Play", true);
            playing = true;
        }
    }
}
