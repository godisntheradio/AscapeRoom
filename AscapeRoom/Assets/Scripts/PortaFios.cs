using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFios : MonoBehaviour, IInteractive
{
    private Animator AnimatorRef;
    bool Inspected;

    public void Inspect()
    {
        if (!Inspected)
        {
            Manager.instance.ShowMessage("Essa placa está solta, se fazer um pouco de força é possível remove-la.");
            Inspected = true;
        }
        else
        {
            AnimatorRef.SetBool("Abrir", true);
        }
    }

    public void Interact(Item item)
    {
        Inspect();
    }

    void Start ()
    {
        AnimatorRef = GetComponentInParent<Animator>();
    }

    void Update ()
    {
		
	}
}
