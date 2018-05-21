using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDesktop : MonoBehaviour, IInteractive
{
    public static List<ImagePart> imageParts;
    public List<GameObject> objectsReference;

    public Material desktop1;
    public Material desktop2;

    bool Changed;

    public void Inspect()
    {
        if (!Manager.instance.IsComOn)
        {
            // inspecionar 
            SetPuzzle(true);
        }
        else
        {
            Manager.instance.ShowMessage("Você conseguiu estabelecer comunicação com a central de segurança da Unisinos. A ajuda está a caminho.");
            Manager.instance.IsGameOver = true;
            //Fim de jogo
        }
    }

    public void Interact(Item item)
    {
        Inspect();
    }
    void Awake()
    {

        imageParts = new List<ImagePart>();
        ImagePart[] list =  GetComponentsInChildren<ImagePart>();
        for (int i = 0; i < list.Length; i++)
        {
            objectsReference.Add(list[i].gameObject);
            imageParts.Add(list[i]);
        }
        Changed = Manager.instance.IsComOn;
    }
    void Start ()
    {
        SetPuzzle(false);
	}
	
	void Update ()
    {
        if (Manager.instance.IsComOn != Changed)
        {
            if (Manager.instance.IsComOn)
            {
                TrocarParaFinal();
                SetPuzzle(!Manager.instance.IsComOn);
            }
            Changed = Manager.instance.IsComOn;
        }
    }
    public ImagePart GetClosest(Vector3 pos)
    {
        float closest = 1000;
        ImagePart toReturn = null;
        for (int i = 0; i < imageParts.Count; i++)
        {
            float distance = Vector3.Distance(imageParts[i].GetInicial(), pos);
            if ( distance < closest)
            {
                closest = distance;
                toReturn = imageParts[i];
            }
        }
        return toReturn;
    }
    public void TrocarParaFinal()
    {
        GetComponent<MeshRenderer>().material = desktop2;
    }
    public void SetPuzzle(bool state)
    {
        foreach (var item in objectsReference)
        {
            item.SetActive(state);
        }
    }
}
