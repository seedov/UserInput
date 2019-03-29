using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Reads user input from Ui image.
/// </summary>
[RequireComponent(typeof(Image))]
public class UiCanvasUserInput : MonoBehaviour, IUserInput, IPointerDownHandler, IPointerUpHandler, IDragHandler, IScrollHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        PointerUpInputReceived?.Invoke(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        print(eventData.pointerId + " "+eventData.button);

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Middle:
                InputMoveReceived?.Invoke(eventData.delta);
                break;
            case PointerEventData.InputButton.Right:
                InputRotateReceived?.Invoke(Vector2.Dot(eventData.delta, Vector2.right), Vector2.Dot(eventData.delta, Vector2.up));
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerDownInputReceived?.Invoke(eventData.position);
    }
    public void OnScroll(PointerEventData eventData)
    {
        print(eventData.scrollDelta);
        InputScaleReceived?.Invoke(eventData.scrollDelta.y);
    }

    public event Action<Vector2> PointerDownInputReceived;
    public event Action<Vector2> PointerUpInputReceived;
    public event Action<Vector2> InputMoveReceived;
    public event Action<float> InputScaleReceived;
    public event Action<float, float> InputRotateReceived;
}
