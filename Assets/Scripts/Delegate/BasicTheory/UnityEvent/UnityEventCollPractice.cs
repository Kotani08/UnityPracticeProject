using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventCollPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //EventPracticeで作ったイベントに登録
        //UnityEventPractice.unityEvent.AddListener(dispText);
    }

    // Update is called once per frame
    public void dispText()
    {
        //ここで処理を書く
        Debug.Log("Event");
    }
}
