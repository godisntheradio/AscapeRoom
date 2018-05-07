using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCLogin : MonoBehaviour, IInteractive
{
    Typing passwordRef;
    public void Inspect()
    {
        Manager.instance.ShowMessage("É preciso uma senha para acessar o computador");
    }

    public void Interact(Item item)
    {
        if (item.Name == "Senha")
        {
            PCManager a = GetComponentInParent<PCManager>();
            if (a != null)
            {
                Transform b = a.gameObject.GetComponentInChildren<Transform>();
                if (b != null)
                {
                    StartCoroutine(passwordRef.Type());
                }
                
            }


        }
    }

    void Start ()
    {
        passwordRef = GetComponentInChildren<Typing>();
	}
    public void ChangeToDesktop()
    {
        GetComponentInParent<PCManager>().ChangeScreen(transform.parent.GetComponentInChildren<Transform>().gameObject, gameObject);
    }
}
