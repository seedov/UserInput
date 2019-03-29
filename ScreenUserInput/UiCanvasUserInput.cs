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
        InputMoveReceived?.Invoke(eventData.delta);
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
}
