using System.Linq;
using UnityEngine.EventSystems;

public class UiCanvasMouseUserInput : UiCanvasUserInput, IScrollHandler, IDragHandler
{


    public void OnDrag(PointerEventData eventData)
    {
        print(eventData.pointerId + " "+eventData.button);

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Middle:
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


}
