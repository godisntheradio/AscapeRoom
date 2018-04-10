using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
 
    public static Manager instance;

    public Inventory inventory;

	void Awake ()
    {
        instance = this;
        inventory = new Inventory();
	}
	
	void Update ()
    {
        ProcessInput();
	}

    void ProcessInput()
    {
        Ray ray = new Ray();
        RaycastHit hit;
        if (Application.platform == RuntimePlatform.Android)
        {
            foreach (Touch touch in Input.touches)
            {
                ray = Camera.main.ScreenPointToRay(touch.position);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
        }
        if (Physics.Raycast(ray, out hit))
        {
            TryToInteract(hit);
        }
    }
    void TryToInteract(RaycastHit hit)
    {
        IInteractive interactive = hit.transform.gameObject.GetComponent<IInteractive>();
        if (interactive != null)
        {
            if( inventory.Selected != null )
            {
                interactive.Interact(inventory.Selected);
            }
            else
            {
                interactive.Inspect();
            }
        }
    }
}
