using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{
    private GUIStyle style;
    private GUIStyleState styleState;
    private int ButtonVaule;

    void Start()
    {
        style = new GUIStyle();
        styleState = new GUIStyleState();
        styleState.textColor = new Color(1f, 1f, 1f);;
        style.normal = styleState;
        style.fontSize = 50;
        ButtonVaule = 0;
    }

    #region GUI
    private void OnGUI()
    {
        //ここもっと効率化できるけど一旦雑な実装で
        
        string text = "歩く";
        Rect rect1 = new Rect(10, 10, 300, 200);
        Rect rect2 = new Rect(110, 90, 300, 200);
        if (GUI.Button(rect1,""))
        {
            Live2DPlayerControl.Instance.PlayerMove(1f);
        }
        GUI.Label(rect2, text,style);

        text = "止まる";
        rect1 = new Rect(10, 230, 300, 200);
        rect2 = new Rect(90, 300, 300, 200);
        if (GUI.Button(rect1,""))
        {
            Live2DPlayerControl.Instance.PlayerMove(0f);
        }
        GUI.Label(rect2, text,style);
    }

    #endregion
}
