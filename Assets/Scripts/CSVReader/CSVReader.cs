using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour {
    #region 何の機能が必要なのか
    //CSVファイルをResourcesから読み込んでそれをLogに流す
    //
    //【参考文献】 https://note.com/masataro5959/n/nc47728a63157
    #endregion

    TextAsset csvFile; // CSVファイル//TextAssetはUnityのテキスト読み込み用形式

    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;

    void Start()
    {
        csvFile = Resources.Load("testCSV") as TextAsset; // Resouces下のCSVをTextAssetの形式に変更して読み込み

        StringReader reader = new StringReader(csvFile.text); //Stringクラスの文字列をストリーム（連結したデータ）今回は.textとして読み込む

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み

            //どの文字で区切るかを設定できる（今回は,で区切る）
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }

        // csvDatas[行][列]を指定して値を自由に取り出せる
        Debug.Log("１列目／１行目【" + csvDatas[0][0]+"】"); 
        Debug.Log("１列目／２行目【" + csvDatas[0][1]+"】"); 
        Debug.Log("１列目／３行目【" + csvDatas[0][2]+"】");

        Debug.Log("２列目／１行目【" + csvDatas[1][0]+"】"); 
        Debug.Log("２列目／２行目【" + csvDatas[1][1]+"】");
        Debug.Log("２列目／３行目【" + csvDatas[1][2]+"】");

    }

}
