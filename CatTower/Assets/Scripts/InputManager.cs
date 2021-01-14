using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    IInputProvider provider = null;

    // Start is called before the first frame update
    void Start()
    {
        provider = new StandaloneProvider();
    }

    // Update is called once per frame
    void Update()
    {
        InputState state = provider.GetInputState();
        if (state != InputState.None) Debug.Log(state.ToString());

        switch(state)
        {
            case InputState.TouchDown:
                var position = provider.GetPosition();
                Debug.Log(position.ToString("N3")); // 소수점 3자리까지 표시하겠단 의미
                //마우스를 딱 눌렀을 때 해당 마우스 위치에 카드가 있는지를 체크해야 함. 아니라면 무효임
                break;
            case InputState.TouchMoved:
                break;
            case InputState.TouchUp:
                break;
        }
    }

    void CheckCardSelected(Vector2 position)
    {
        Ray ray = Camera.main.ViewportPointToRay(position);
        RaycastHit hit;


        // 이하 생략. 어떤 카드가 선택되었는지를 체크해서 그 카드를 리턴하는 식으로..
    }
}
