using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    public int pointNumber;
    public float min, max;

    private bool correctLast = false;

    private bool changed = false;

    public Material wireMaterial;

    public AudioSource source;
    public AudioClip correctSound;

    private GameObject selectedWire;
    public GameObject SelectedWire
    {
        get { return selectedWire; }
        set
        {
            if (value == null || selectedWire == value)
            {
                selectedWire.transform.GetChild(0).gameObject.SetActive(false);
                selectedWire = null;
            }
            else
            {
                if (selectedWire != null)
                {
                    selectedWire.transform.GetChild(0).gameObject.SetActive(false);
                }
                selectedWire = value;
                selectedWire.GetComponent<WireSocket>().DisconnectWire();
                value.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = correctSound;
        source.playOnAwake = false;
        source.loop = false;
    }

    public void SetChanged()
    {
        changed = true;
    }

    public void ConnectTo(GameObject socket)
    {
        if (selectedWire != null)
        {
            ConnectWires(selectedWire, socket);
            SelectedWire = null;
        }
    }

    void ConnectWires(GameObject wireBegin, GameObject wireEnd)
    {
        Vector3[] points;

        points = new Vector3[pointNumber];

        points[0] = wireBegin.transform.position;
        points[pointNumber - 1] = wireEnd.transform.position;
        for (int i = 1; i < pointNumber - 1; ++i)
        {
            points[i] = points[0] + ((points[pointNumber - 1] - points[0]) / pointNumber * i);
            points[i].x += Random.Range(min, max);
            points[i].y += Random.Range(min, max);
        }

        LineRenderer lr = wireBegin.GetComponent<LineRenderer>();
        lr.positionCount = pointNumber;
        lr.SetPositions(points);


        WireSocket wbs = wireBegin.GetComponent<WireSocket>();
        WireSocket wes = wireEnd.GetComponent<WireSocket>();
        wbs.connected = wes;
        wes.connected = wbs;

        changed = true;
        if (AllCorrect())
        {
            Manager.instance.IsComOn = true;
            source.Play();
        }
        else
        {
            Manager.instance.IsComOn = false;
        }
    }

    public bool AllCorrect()
    {
        if (changed)
        {
            bool res = true;
            foreach (WireSocket ws in WireSocket.activeOutSockets)
            {
                if (ws.connected == null || ws.socketColour != ws.connected.socketColour)
                {
                    res = false;
                    break;
                }
            }

            correctLast = res;
            changed = false;
            return res;
        }
        else
        {
            return correctLast;
        }
    }
}
