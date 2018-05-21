using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePart : MonoBehaviour
{
    Vector3 inicial;
    Camera cameraRef;

    float distance;

    bool isDraging;

    void Start ()
    {
        inicial = transform.position;
        cameraRef = Camera.main;
        distance = 5;
        isDraging = false;
    }
	
	void Update ()
    {
        if (!isDraging)
        {
            transform.position = Vector3.Slerp(transform.position, inicial, 20 * Time.deltaTime);
        }
    }
    private void OnMouseDown()
    {
        //distance = Vector3.Distance(cameraRef.transform.position, inicial);
        isDraging = true;
    }
    private void OnMouseUp()
    {
        isDraging = false;
        ImagePart closestSlot = GetComponentInParent<PCDesktop>().GetClosest(transform.position);
        ChangeInicial(closestSlot);

    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = cameraRef.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,distance));
        Vector3 offset = mousePos - transform.position;
        transform.position = Vector3.Slerp(transform.position, mousePos + offset, 20 * Time.deltaTime);
    }
    public void SetInicial(Vector3 nInicial)
    {
        inicial = nInicial;
    }
    public Vector3 GetInicial()
    {
        return inicial;
    }
    void ChangeInicial(ImagePart other)
    {
        Vector3 thisBuffer = inicial;
        SetInicial(other.GetInicial());
        other.SetInicial(thisBuffer);
    }
}
