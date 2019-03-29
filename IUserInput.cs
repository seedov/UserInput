using System;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IUserInput 
{
    event Action<Vector2> PointerDownInputReceived;
    event Action<Vector2> PointerUpInputReceived;
    event Action<Vector2> InputMoveReceived;
    event Action<float> InputScaleReceived;

}
