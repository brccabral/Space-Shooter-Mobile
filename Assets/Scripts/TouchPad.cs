using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public float smoothing;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;
    private void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // Set our start finger point
        if (!touched)
        {
            touched = true;
            pointerID = eventData.pointerId;
            origin = eventData.position;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Get new finger position
        if (eventData.pointerId == pointerID)
        {
            Vector2 currentPosition = eventData.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
            //Debug.Log(direction);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset everything
        if (eventData.pointerId == pointerID)
        {
            direction = Vector2.zero;
            touched = false;
        }
    }

    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
