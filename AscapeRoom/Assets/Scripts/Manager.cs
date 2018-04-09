using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public IItem Active;
    public List<IItem> items;

    //o inventario ficaria aqui
	void Start ()
    {
		
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
            if( Active != null )
            {
                interactive.Interact(Active);
            }
            else
            {
                interactive.Inspect();
            }
        }
    }
    // esses funções serão usadas para manipulação no inventário 
    public void EquipItem(IItem toEquip)
    {
        Active = toEquip;
    }
    public void UnequipItem()
    {
        Active = null;
    }
    // serve para controlar a entrada de itens no inventário vindos de fora
    public void GetItem(IItem toAdd)
    {
        if (!items.Contains(toAdd))
        {
            items.Add(toAdd);
        }
    }
}
