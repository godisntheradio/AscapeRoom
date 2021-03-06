﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
 
    public static Manager instance;

    public Inventory inventory;
    [SerializeField]
	private TextBox textBox;


    //game flags
    public bool HasEnergy;
    public bool IsComOn; //communications
    public bool IsGameOver;
	void Awake ()
    {
        instance = this;
        inventory = new Inventory();


        //set flags
        HasEnergy = false;
        IsComOn = false;
        IsGameOver = false;
	}
	
	void Update ()
    {
        if (!textBox.GetActive())
        {
            ProcessInput();
        }
        // colocar items no inventario para debug
        GiveKeyItems();
    }

    void ProcessInput()
    {
        Ray ray = new Ray();
		RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
    void GiveKeyItems()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            inventory.AddItem(new Item("Chave"));

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            inventory.AddItem(new Item("Senha"));

        }
    }
	public void ShowMessage(string message)
	{
		textBox.Toggle (true);
		textBox.SetMessage (message);
	}
	public void DismissMessage()
	{
        if (!IsGameOver)
        {
		    textBox.Toggle (false);
        }
	}

}
