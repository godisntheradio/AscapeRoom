using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computador : MonoBehaviour, IInteractive
{


    public void Inspect()
    {
        Manager.instance.ShowMessage("É preciso de uma senha para acessar o computador");
    }

    public void Interact(Item item)
    {
        if (item.Name == "Chave" && !Manager.instance.HasEnergy)
        {

        }
    }
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
