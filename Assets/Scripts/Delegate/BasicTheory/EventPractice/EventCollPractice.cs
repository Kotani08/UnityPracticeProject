using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //EventPracticeのdelegateに登録
        EventPractice.OnDelEvent += dispText;
    }

    // Update is called once per frame
    public void dispText()
    {
        //ここで処理を書く
        Debug.Log("Event");
    }
}
