using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextReader : MonoBehaviour
{
    #region 何の機能が必要なのか
    //CSVファイルをResourcesから読み込む
    //
    //
    //【参考文献】 https://note.com/masataro5959/n/nc47728a63157
    #endregion

    TextAsset csvFile; // CSVファイル//TextAssetはUnityのテキスト読み込み用形式
    
    List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト;
    
    //表示するテキストを格納
    [SerializeField]
    private Text TextObj;

    //テキストのスピードを変更
    [SerializeField]
    private float TextDispSpeed;
    private float TextSpeed = 0;
    float StandardTextSpeed = 0.07f;

    
    //Textを最後まで表示するためのFlag
    private bool skipFlag=false;

    void Start()
    {
        TextSpeed = StandardTextSpeed;

        //Resouces下のCSVをTextAssetの形式に変更して読み込み
        csvFile = Resources.Load("testCSV") as TextAsset;

        //Stringクラスの文字列をストリーム（連結したデータ）今回は.textとして読み込む
        StringReader reader = new StringReader(csvFile.text);
        //Debug.Log(reader.ReadLine());

        // , で分割しつつ一行ずつ読み込み、リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで（使用可能な文字が全部読み込れる）
        {
            // 一行ずつ読み込み
            string line = reader.ReadLine();
            line = line.Replace("\r\n", "\n").Replace("\r", "\n");
            
            //どの文字で区切るかを設定できる（今回は,で区切る）
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
            Debug.Log(line);
        }
        
        StartCoroutine(TextLettering(csvDatas[0][0]));
    }

    private IEnumerator TextLettering(string ReadText)//ReadTextをtextに入れる
    {
        for(int DispTextValue = 0;ReadText.Length >= DispTextValue;++DispTextValue)
        {
            // csvDatas[列][行]を指定して値を自由に取り出せる
                //１列目は名前　２列目から表示文章本文
                //空白の場合は改行して文章を続けて表示
            TextObj.text = ReadText.Substring(0,DispTextValue);
            
            //if(DispTextValue >= 3){TextObj.text+="\n";}
            
            if(skipFlag == true)
            {
                //スキップする場合は０からLengthまでの長さを入れる
                TextObj.text = ReadText.Substring(0,ReadText.Length);
                DispTextValue = ReadText.Length;
                skipFlag=false;
            }
            //Substring(a,b)は先頭から数えて文字a番目からb番目の文字まで取得するもの
            yield return new WaitForSeconds(TextSpeed);
        }
    }

    //ここから先はButtonの機能だから外部に持たせたほうがいい
    public void SkipButton()
    {
        skipFlag=true;
    }

    public void TextSpeedChangeButton()
    {
        if(TextSpeed == StandardTextSpeed)
        {
            TextSpeed = StandardTextSpeed/TextDispSpeed;
        }
        else
        {
            TextSpeed = StandardTextSpeed;
        }
    }

    public void NextTextRead()
    {
        //最初に全部読み込んでリスト化したい

        //組み合わせを列挙したメモを用意しておいて
        //それを検索してその次をコルーチンに渡す
        //indexof等で中身を検索してその次をコルーチンに渡す
        //int a = Array.IndexOf(csvDatas,TextObj.text);
        //csvDatasの中から読み込んだ文字列を探して、その次の文字列を取得したい
        StartCoroutine(TextLettering(csvDatas[1][0]));
    }
}
