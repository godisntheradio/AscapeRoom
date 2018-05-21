using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocket : MonoBehaviour, IInteractive
{
    public static List<WireSocket> activeOutSockets = new List<WireSocket>();

    public enum Type { OUT, IN };
    public enum Colour { RED, GREEN, BLUE };

    public Type socketType;
    public Colour socketColour;

    public WireSocket connected = null;

    WireController wireController;

    void Awake()
    {
        if (socketType == Type.OUT)
            activeOutSockets.Add(this);
    }

	// Use this for initialization
	void Start ()
    {
        wireController = transform.parent.parent.GetComponentInChildren<WireController>();
        
	}
	
    public void DisconnectWire()
    {
        if(connected != null)
        {
            if (socketType == Type.OUT)
            {
                GetComponent<LineRenderer>().positionCount = 0;
            }
            else
            {
                connected.GetComponent<LineRenderer>().positionCount = 0;
            }
            connected.connected = null;
            connected = null;
        }
    }

	public void Interact (Item item)
    {
        Inspect();
	}

    public void Inspect()
    {
        if (Manager.instance.HasEnergy)
        {
            Manager.instance.ShowMessage("É perigoso mexer na fiação com a energia ligada.");
        }
        else
        {
            if (socketType == Type.OUT)
                wireController.SelectedWire = gameObject;
            else
            {
                if (connected != null)
                    DisconnectWire ();
				
                wireController.ConnectTo(gameObject);
            }
        }
    }
}
