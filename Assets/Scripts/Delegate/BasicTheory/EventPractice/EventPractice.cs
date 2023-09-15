using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//参考：https://taidanahibi.com/unity/delegate-event-unityaction-unityevent/

public class EventPractice : MonoBehaviour
{
    public delegate void OnDelegateEvent();
    public static event OnDelegateEvent OnDelEvent;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TextDisp();
        }
    }

    public void TextDisp()
    {
        OnDelEvent.Invoke();
        if (OnDelEvent != null)
        {
            OnDelEvent.Invoke();
        }
        //ラムダ式の書き方【OnDelEvent?.Invoke();】
    }
}
