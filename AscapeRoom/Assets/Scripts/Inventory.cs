using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    //Guarda os items (6 slots)
    private Item[] items = new Item[6];
    public Item[] Items { get { return items; } }

    //Index do item selecionado
    public int selectedIndex { get; set; }
    //Retorna o item selecionado. Indice menor que 0 significa que nenhum item está selecionado
    public Item Selected { get { if (selectedIndex >= 0) return items[selectedIndex]; else return null; } }

    public Inventory()
    {
        selectedIndex = -1;
    }

    //Seleciona o item no index passado e atualiza UI
    public void Select(int index)
    {
		if (index - 1 == selectedIndex || items[index-1] == null)
			selectedIndex = -1;
        else
            selectedIndex = index - 1;
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < items.Length; ++i) //Procura primeiro slot vazio
        {
            if (items[i] == null)
            {
                items[i] = item;
                //UpdateUI();
                return;
            }
        }

        Debug.Log("Inventory Full!"); //Mensagem para debug
    }

    public void RemoveItem(string name)
    {
        int i = 0;
        for (; i < items.Length; ++i) //Procura item com nome recebido
        {
            if (items[i] == null) //Se achar um slot vazio o item não está no inventário
            {
                i = items.Length;
                break;
            }
            if (items[i].Name == name) //Se achar o item remove do array
            {
                items[i] = null;
                break;
            }
        }
        if (i == items.Length) //Se o iterador é igual o tamanho do array, o item não foi encontrado
        {
            Debug.Log("Remove Item: Not found."); //Mensagem de debug
            return;
        }
        if (i < items.Length - 1) //Empurra itens depois do removido para o slot anterior
        {
            i++;
            for (; i < items.Length; ++i)
            {
                items[i - 1] = items[i];
                items[i] = null;
            }
        }

        //UpdateUI();
    }

    //Retorna item pelo nome
    public bool ContainItem(string name)
    {
        for (int i = 0; i < items.Length; ++i)
        {
            if (items[i] != null)
            {
                if (items[i].Name == name)
                {
                    return true;    
                }
            }
        }
        return false;
    }
}
