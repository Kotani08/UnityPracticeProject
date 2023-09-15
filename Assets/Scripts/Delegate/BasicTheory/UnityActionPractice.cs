using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;//<-UnityAction,UnityEventに必要

public class UnityActionPractice : MonoBehaviour
{
    //UnityActionって？

    //delegateを省略して書く書き方
    //public delegate void  DelegateType();//delegateの型名を宣言
    //public DelegateType onComplete;//delegate名(変数名)を宣言
    //本来、二行必要な所を
    //【 public UnityAction del; 】この一行に出来る
    public UnityAction del;

    void Start()
    {
        //delgateに関数を登録
        del = TextDisp;
        //delgateを呼ぶ＝登録している関数が呼ばれる
        del();
    }

    public void TextDisp()
    {
        //ここに本来の処理を書く
        Debug.Log("表示したよ");
    }
}
