using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputProvider
{
    InputState GetInputState();
    Vector2 GetPosition();
}

public enum InputState
{
    TouchUp,
    TouchMoved,
    TouchDown,
    None,
}


///https://prosto.tistory.com/96 참고