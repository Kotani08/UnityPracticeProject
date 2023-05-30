using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //
        //PointerEventData =(x,y)
        Debug.Log(pointerEventData.button);

        Debug.Log("押された１");
    }
    //クリックを離したところ
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        //Debug.Log(pointerEventData);
        Debug.Log("離された１");
    }
}
