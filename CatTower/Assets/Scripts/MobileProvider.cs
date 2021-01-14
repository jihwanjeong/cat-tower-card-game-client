using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileProvider : MonoBehaviour
{
    public InputState GetInputState()
    {
        //모바일의 경우에는
        // Input.GetTouch(0).phase 같은걸로 체크해야됨
        return InputState.None;
    }

    public Vector3 GetPosition()
    {
        throw new System.NotImplementedException();
    }
}
