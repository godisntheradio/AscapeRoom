using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    //Painel de items na UI
    private GameObject itemPanelUI;
    //Cor para highlight do item selecionado na UI
    public Color slotSelectedColour;


    //Atualiza textura dos slots na UI
    private void UpdateUI()
    {
        for(int i = 0; i < Manager.instance.inventory.Items.Length; ++i)
        {
            if (Manager.instance.inventory.Items[i] == null)
                break;
            else
            {
                var slot = itemPanelUI.transform.Find((i + 1).ToString()).GetComponent<RawImage>();
                slot.texture =Manager.instance.inventory.Items[i].Thumbnail;
                if (Manager.instance.inventory.selectedIndex == i)
                    slot.color = slotSelectedColour;
                else
                    slot.color = Color.white;
            }
        }
    }
    

    void Start()
    {
        itemPanelUI = transform.Find("ItemPanel").gameObject; //Pega painel dos items na UI
    }

    void Update()
    {
        UpdateUI();
    }
}
