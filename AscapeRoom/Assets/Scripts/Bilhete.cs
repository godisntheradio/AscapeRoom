using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilhete : MonoBehaviour, IInteractive
{
    [TextArea(15, 20)]
    public string message;

    public void Inspect()
    {
        Manager.instance.ShowMessage(message);
    }

    public void Interact(Item item)
    {
        Inspect();
    }
}
