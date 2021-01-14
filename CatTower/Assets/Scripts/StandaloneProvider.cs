using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandaloneProvider : IInputProvider
{
    bool isClicked = false;
    public InputState GetInputState()
    {
        if (Input.GetMouseButtonDown(0) && !isClicked)
        {
            isClicked = true;
            return InputState.TouchDown;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            return InputState.TouchUp;
        }
        else if (isClicked)
        {
            return InputState.TouchMoved;
        }
        return InputState.None;
    }

    public Vector2 GetPosition()
    {
        Vector2 position = Input.mousePosition;
        Debug.Log(position);
        return Camera.main.ScreenToViewportPoint(position);
    }
}
//https://hyunity3d.tistory.com/368