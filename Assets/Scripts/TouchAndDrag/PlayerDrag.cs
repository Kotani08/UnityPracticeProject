using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler//, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //ドラッグ中の指とタップする指を分けて考えてくれる 偉い
    #region PointerDown/Up
    //クリックした所
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        Debug.Log("押された");
    }
    //クリックを離したところ
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        //Debug.Log(pointerEventData);
        Debug.Log("離された");
    }
    #endregion

    #region Drag/DragEnd
    //ドラッグ始め
    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        //positionとdeltaが取得可能
        //positionは場所の座標(vec)
        //deltaはXY軸どっちに動いたか上なら＋右なら＋
        Debug.Log(pointerEventData.delta);
        //Debug.Log("押された");
    }
    //ドラッグ中
    public void OnDrag(PointerEventData pointerEventData)
    {
        //Debug.Log(pointerEventData);
        //Debug.Log("移動中...");
    }
    //ドラッグ終わり
    public void OnEndDrag(PointerEventData pointerEventData)
    {
        //Debug.Log(pointerEventData.delta);
        //Debug.Log("離された");
    }
    #endregion

    
}
