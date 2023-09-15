using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.modis.co.jp/candidate/insight/column_136
//https://www.sejuku.net/blog/41326

public class SkillDictionary : MonoBehaviour
{
    //スキルのDictionaryとSpriteを管理する場所
    //Dictionary<スキルID,スキル名,クールタイム>
    private Dictionary<int,(string,int)> _skillIdDictionary = new Dictionary<int,(string,int)>();

    public Dictionary<int,(string,int)> SkillIdDictionary
    {
        get{ return _skillIdDictionary;}
    }
    
    #region スキルボタンのSpriteを保管する場所

    //スキルボタンのイメージを格納する
    [SerializeField]
    private List<Sprite> SkillImage = new List<Sprite>();

    public List<Sprite> SkillSprite
    {
        get{return SkillImage;}
    }
    #endregion

    void Awake()
    {
        //Dictionaryの中身を登録する
        SkillId();
    }

    public void SkillId()
    {
        // 変数 = new Dictionary<Keyの型名,Valueの型名>();
        // keyは被りがあった場合はエラーを吐かれる
        _skillIdDictionary.Add(0,("スキル無し",0));
        _skillIdDictionary.Add(1,("アタック",5));
        _skillIdDictionary.Add(2,("ヒール",10));
        _skillIdDictionary.Add(3,("ブロック",15));
        _skillIdDictionary.Add(4,("逃げる",20));//Valueは被っても大丈夫
        //_skillIdDictionary.Add(4,("逃げる2",25));//Keyの値が被った場合はエラーを起こす
    }
}
