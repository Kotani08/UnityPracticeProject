using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;//<-UnityAction,UnityEventに必要
using System;

//callback処理とは?
//返り値に関数を入れることで
//処理Aが終わったら処理Bを開始することが出来る物

//左クリックで１つだけ処理をコールバックに登録して動かす
//右クリックで３つ処理をコールバックに登録して動かす


public class CallBackPractice : MonoBehaviour
{
    void Update()
    {
        //フェードの開始と終わりを出力する
        if(Input.GetMouseButtonDown(0))
        {
        DebugLogCall("Fade開始");
        //コールバックとしてクラスを渡す
        StartCoroutine(FadeCallBack.Instance.FadeIn(DebugLogCall));
        }
        if(Input.GetMouseButtonDown(1))
        {
        //クラスを取得してそのクラスの中の関数を呼ぶ
        Test3 test3 = new Test3();
        test3.Method();
        }
    }

    private void DebugLogCall(string str){
        Debug.Log(str);
    }
}

#region 基本的な書き方

public class Test1 {
    //Test2を作成しメソッドを実行する
	public void Method(){
        //関数を呼ぶためにクラスを登録
		Test2 test2 = new Test2();
        
		//待機させたい処理の引数として処理を渡すことでCallBack処理になる
		test2.Method(CallBack);
	}

	//Test2の処理が終わったら呼ばれる
	public void CallBack(){
		Debug.Log("処理終わり");
	}
}

public class Test2 {
	//引数及び返り値のないデリゲート
	public delegate void Delegate();

	//何らかの処理をした後、入力されたデリゲートを実行する
	public void Method(Action delegateMethod){

		Debug.Log("処理中");
		
        delegateMethod();
	}

}
#endregion


public class Test3 {
    public void Method(){
        Test2 test2 = new Test2();

        //クラスを変数として登録して
        Action delegateMethod = CallBack1;

        //その変数の処理後に動かしたい処理を追加する
        delegateMethod += CallBack2;
        delegateMethod += CallBack3;

        //その変数をMethodに登録する
        test2.Method(delegateMethod);
    }

    private void CallBack1(){
        Debug.Log("処理終わり1");
    }
    private void CallBack2(){
        Debug.Log("処理終わり2");
    }
    private void CallBack3(){
        Debug.Log("処理終わり3");
    }
}

