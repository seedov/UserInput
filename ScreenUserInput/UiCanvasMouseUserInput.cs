using System.Linq;
using UnityEngine.EventSystems;

public class UiCanvasMouseUserInput : UiCanvasUserInput, IScrollHandler, IDragHandler, IPointerDownHandler
{


    public void OnDrag(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                InvokeMoveEvent(eventData.delta);
                break;
            case PointerEventData.InputButton.Right:
                InvokeRotateEvent(eventData.delta);
                break;
        }
    }


    public void OnScroll(PointerEventData eventData)
    {
        InvokeScaleEvent(eventData.scrollDelta.y);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        InvokePointerDownEvent(eventData.position);
    }
}
