using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeForca : MonoBehaviour, IInteractive
{
    void Start ()
    {
	    	
	}
	void Update ()
    {
		
	}
    public void Inspect()
    {
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), transform);
    }

    public void Interact(IItem item)
    {
        throw new System.NotImplementedException();
    }
}
