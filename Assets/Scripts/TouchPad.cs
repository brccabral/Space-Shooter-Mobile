using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 origin;
    public void OnPointerDown(PointerEventData eventData)
    {
        // Set our start finger point
        origin = eventData.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Get new finger position
        Vector2 currentPosition = eventData.position;
        Vector2 directionRaw = currentPosition - origin;
        Vector2 direction = directionRaw.normalized;
        Debug.Log(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset everything
    }
}
