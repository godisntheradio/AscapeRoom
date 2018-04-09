using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractive
{
    void Inspect();
    void Interact(IItem item);
}
