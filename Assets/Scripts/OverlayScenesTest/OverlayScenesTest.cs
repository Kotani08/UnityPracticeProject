using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class OverlayScenesTest : MonoBehaviour
{
    ///結論
    ///////////////基本は使わなくていい！
    ///////////////シーンのオーバーライドをする利点が無いので使わない
    void Start()
    {
        //初期でシーンで使いそうなシーンをまとめてロードしておく
        SceneManager.LoadScene("OverlayTestScene_1", LoadSceneMode.Additive);
        SceneManager.LoadScene("OverlayTestScene_2", LoadSceneMode.Additive);
        //その後、今すぐ使わない物は非表示にしておく
        //ロードしたシーンのobjectを非表示にする
    }
    // Update is called once per frame                                                                                                                                                                                                      
    void Update()
    {
    try {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("OverlayTestScene_1");
            Debug.Log("シーンの切り替え");
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("OverlayTestScene_2", LoadSceneMode.Additive);
            Debug.Log("シーンのオーバーライド");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(CoUnload());
            Debug.Log("シーンのアンロード");
        }
    }catch(Exception e){Debug.Log(e+"\nシーンのロード/アンロード時にエラーが発生しました");}

    }

    public void OnUnloadScene()
    {
        StartCoroutine(CoUnload());
    }
 
    IEnumerator CoUnload()
    {
        //Stringで指定したシーン名をアンロード
        var op = SceneManager.UnloadSceneAsync("OverlayTestScene_1");
        yield return op;
        //解放後の処理を書く

        //必要に応じて不使用アセットをアンロードしてメモリを解放する
        yield return Resources.UnloadUnusedAssets();
     }
}
