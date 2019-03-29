using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiCanvaseTouchUserInput : UiCanvasUserInput, IDragHandler,IPointerDownHandler, IPointerUpHandler
{
    protected Dictionary<int, Vector2> Pointers = new Dictionary<int, Vector2>();
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Pointers.Add(eventData.pointerId, eventData.position);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Pointers.Remove(eventData.pointerId);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Pointers[eventData.pointerId] = eventData.position;
        if (Pointers.Count > 1)
        {
            var averageX = 0f;
            var averageY = 0f;
            
            foreach (var pointer in Pointers.Keys)
            {
                averageX += Pointers[pointer].x;
                averageY += Pointers[pointer].y;
            }
            var averagePos = new Vector2(averageX/Pointers.Count, averageY/Pointers.Count);
        }
    }
}