using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//参考：https://taidanahibi.com/unity/delegate-event-unityaction-unityevent/

public class UnityEventPractice : MonoBehaviour
{
    //UnityEvent型で宣言
    [SerializeField]
    public UnityEvent unityEvent = new UnityEvent();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TextDisp();
        }
    }

    public void TextDisp()
    {
        //Invokeは
        unityEvent.Invoke();
    }
}
