using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyUI : MonoBehaviour
{
    bool Changed;
    [SerializeField]
    Texture On;
    [SerializeField]
    Texture Off;

    UnityEngine.UI.RawImage imageRef;
    void Start ()
    {
        Changed = Manager.instance.HasEnergy;
        imageRef = GetComponent<UnityEngine.UI.RawImage>();
	}
	
	void Update ()
    {
        if (Manager.instance.HasEnergy != Changed)
        {
            if(Manager.instance.HasEnergy)
            {
                imageRef.texture = On;
            }
            else
            {
                imageRef.texture = Off;
            }
            Changed = Manager.instance.HasEnergy;
        }
	}
}
