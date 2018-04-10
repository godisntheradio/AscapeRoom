using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour, IInteractive
{
    CaixaDeForca caixaRef;
    void Start ()
    {
        caixaRef = GetComponentInParent<CaixaDeForca>();
        if (caixaRef == null)
        {
            Debug.LogError("Couldn't find ref for caixa");
        }
	}
	
	void Update ()
    {
		
	}
    public void Inspect()
    {
        caixaRef.PuxarAlavanca();
    }

    public void Interact(Item item)
    {
        caixaRef.PuxarAlavanca();
    }

}
