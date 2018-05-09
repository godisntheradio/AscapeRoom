using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCLogin : MonoBehaviour, IInteractive
{
    Typing passwordRef;

    public GameObject desktopScreenRef;
    public void Inspect()
    {
        Manager.instance.ShowMessage("É preciso uma senha para acessar o computador");
    }

    public void Interact(Item item)
    {
        if (item.Name == "Senha")
        {
            StartCoroutine(passwordRef.Type());
        }
    }

    void Start ()
    {
        passwordRef = GetComponentInChildren<Typing>();
	}
    public void ChangeToDesktop()
    {
        GetComponentInParent<PCManager>().ChangeScreen(desktopScreenRef, gameObject);
    }
}
