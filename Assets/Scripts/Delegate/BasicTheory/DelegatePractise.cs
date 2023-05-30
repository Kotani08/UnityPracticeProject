using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events; // <-UnityEventを使うために必要

public class DelegatePractise : MonoBehaviour
{
    //delegateって？
    //関数を変数として取り扱えるやつ
    //参考：https://nn-hokuson.hatenablog.com/entry/2021/09/02/114100
    //参考：https://taidanahibi.com/unity/delegate-event-unityaction-unityevent/

    //
    public delegate void  DelegateType();//delegateの型名を宣言
    public DelegateType onComplete;//delegate名(変数名)を宣言

    void Awake()
    {
        //宣言したdelgateに関数を入れる
        //onCompleteはvoid型で作ったので入れる関数も同じじゃないとエラーになる
        onComplete = TextDispA;
        onComplete();

        //当たり前だけど型が違うと入らない
        //NG例：onComplete(void型) = TextDispB(int型);
    }

    public void TextDispA()
    {
        //ここに本来の処理を書く
        Debug.Log("表示したよ");
    }
}
