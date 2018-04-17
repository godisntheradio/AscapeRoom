using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOpen : MonoBehaviour
{
    private enum State { OPENING, CLOSING, OPENED, CLOSED }
    State state = State.CLOSED;

    bool opened = false;

    public float speed = 100f;

    float endPoint;
    float startPoint;

    Transform openButton;    

	RectTransform rt;

	// Use this for initialization
	void Start ()
    {
		rt = GetComponent<RectTransform> ();
        startPoint = rt.position.x;
		endPoint = (rt.rect.width * rt.localScale.x) / 2f;
        openButton = rt.Find("InventoryArrow");
        openButton.GetComponent<Button>().onClick.AddListener(Toggle);
	}

    public void Toggle()
    {
        switch(state)
        {
            case State.OPENED:
            case State.OPENING:
                state = State.CLOSING;
                break;
            case State.CLOSED:
            case State.CLOSING:
                state = State.OPENING;
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (ScaleUI.Resized) 
		{
			startPoint = rt.position.x;
			endPoint = (rt.rect.width * rt.localScale.x) / 2f;
			if (state == State.OPENED)
				state = State.OPENING;
			else if (state == State.CLOSED)
				state = State.CLOSING;
		}

        if (state == State.OPENING)
        {
            Vector3 pos = rt.position;
            pos.x = Mathf.Lerp(pos.x, endPoint, speed * Time.deltaTime);

            Vector3 rot = openButton.eulerAngles;
            rot.z = Mathf.Lerp(rot.z, 180f, speed * Time.deltaTime);

            if (Mathf.Abs(Mathf.Abs(pos.x) - Mathf.Abs(endPoint)) < 1)
            {
                pos.x = endPoint;
                rot.z = 180f;
                state = State.OPENED;
            }

            rt.position = pos;
            openButton.eulerAngles = rot;
        }
        else if (state == State.CLOSING)
        {
            Vector3 pos = rt.position;
            pos.x = Mathf.Lerp(rt.position.x, startPoint, speed * Time.deltaTime);

            Vector3 rot = openButton.eulerAngles;
            rot.z = Mathf.Lerp(rot.z, 0f, speed * Time.deltaTime);

            if (Mathf.Abs(Mathf.Abs(pos.x) - Mathf.Abs(startPoint)) < 1)
            {
                pos.x = startPoint;
                rot.z = 0;
                state = State.CLOSED;
            }

            rt.position = pos;
            openButton.eulerAngles = rot;
        }
	}
}
