using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems ;

public class FireTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool touched;
    private int pointerID;
    private bool canFire;

    private void Awake()
    {
        touched = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Set our start finger point
        if (!touched)
        {
            touched = true;
            pointerID = eventData.pointerId;
            canFire = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset everything
        if (eventData.pointerId == pointerID)
        {
            touched = false;
            canFire = false;
        }
    }

    public bool GetCanFire()
    {
        return canFire;
    }
}
