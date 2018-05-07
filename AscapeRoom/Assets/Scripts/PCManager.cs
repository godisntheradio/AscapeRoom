using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCManager : MonoBehaviour, IInteractive
{
    public GameObject changeTo;
    public GameObject OffScreen;
    
    bool Changed;

    Vector3 center;
    Vector3 size;

    public void Inspect()
    {
        Manager.instance.ShowMessage("O computador está desligado, e não há energia para ligá-lo.");
    }

    public void Interact(Item item)
    {
        
    }
    void Start()
    {
        Changed = Manager.instance.HasEnergy;
        center = GetComponent<BoxCollider>().center;
        size = GetComponent<BoxCollider>().size;
    }

    void Update()
    {
        if (Manager.instance.HasEnergy != Changed)
        {
            if (Manager.instance.HasEnergy)
            {
                EnergyOn();
            }
            else
            {
                EnergyOff();
            }
            Changed = Manager.instance.HasEnergy;
        }
    }
    void EnergyOn()
    {
        OffScreen.SetActive(false);
        if (GetComponent<BoxCollider>())
        {
            Destroy(GetComponent<BoxCollider>());
        }
        changeTo.SetActive(true);
    }
    void EnergyOff()
    {
        OffScreen.SetActive(true);
        BoxCollider temp = gameObject.AddComponent<BoxCollider>();
        temp.center = center;
        temp.size = size;
        changeTo.SetActive(false);
    }
    void ChangeNextScreen(GameObject next)
    {
        changeTo = next;
    }

    public void ChangeScreen(GameObject next, GameObject current)
    {
        ChangeNextScreen(next);
        EnergyOn();
        current.SetActive(false);

    }

}