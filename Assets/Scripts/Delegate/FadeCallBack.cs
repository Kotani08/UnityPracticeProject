using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;//<-UnityAction,UnityEventに必要
using System;

//フェード関連の処理

public class FadeCallBack : SingletonMonoBehaviour<FadeCallBack>
{
    [SerializeField]
    private Image img;

    #region fade
    public IEnumerator FadeIn(UnityAction< string > callback)
    {
    img.gameObject.SetActive(true); // 画像をアクティブにする
 
    Color c = img.color;
    c.a = 1f; 
    img.color = c; // 画像の不透明度を1にする
 
    while (true)
    {
        yield return null; // 1フレーム待つ
        c.a -= 0.002f;//<-マジックナンバー注意 仮で数値を直接入れてます
        img.color = c; // 画像の不透明度を下げる
 
        if (c.a <= 0f) // 不透明度が0以下のとき
        {
            c.a = 0f;
            img.color = c; // 不透明度を0
            break; // 繰り返し終了
        }
    }
        
    img.gameObject.SetActive(false); // 画像を非アクティブにする

    callback("fade終了");
    }

    public IEnumerator FadeOut(UnityAction< string > callback)
    {
    img.gameObject.SetActive(true); // 画像をアクティブにする
 
    Color c = img.color;
    c.a = 1f; 
    img.color = c; // 画像の不透明度を1にする
 
    while (true)
    {
        yield return null; // 1フレーム待つ
        c.a -= 0.002f;
        img.color = c; // 画像の不透明度を下げる
 
        if (c.a <= 0f) // 不透明度が0以下のとき
        {
            c.a = 0f;
            img.color = c; // 不透明度を0
            break; // 繰り返し終了
        }
    }
        
    img.gameObject.SetActive(false); // 画像を非アクティブにする

    callback("fade終了");
    }


    #endregion
}
