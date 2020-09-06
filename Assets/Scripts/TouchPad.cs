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
    private void Awake()
    {
        direction = Vector2.zero;
    }
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
        direction = directionRaw.normalized;
        //Debug.Log(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset everything
        direction = Vector2.zero;
    }

    public Vector2 GetDirection()
    {
        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
        return smoothDirection;
    }
}
