using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//dictionaryの取得用
using SkillAction;

public class SkillManager : MonoBehaviour
{
    //スキルの辞書を使うためのもの
    [SerializeField]
    private SkillDictionary _skillDictionary;

    //ButtonにID確認とスキルの絵を入れるために使う
    [SerializeField]
    private List<GameObject> _skillButton = new List<GameObject>();

    ///Q.なんでここにスキルのIDと名前をリストで持つの？///
    //A.ここにどのスキルがセットされているかを持っておけば
    //いちいちボタンにスキルを確認しくてよくなるから
    ////////////////////////////////////////////////////

    //スキルのIDを保持する
    [SerializeField]
    private List<int> _setSkillIdValue = new List<int>();
    //スキルの名前を保持する
    [SerializeField]
    private List<string> _setSkillName = new List<string>();
    //スキルのクールタイムを保持する
    [SerializeField]
    private List<int> _setSkillCoolTime = new List<int>();

    #region namespaseの宣言
    private SkillActionList SkillActionList= new SkillAction.SkillActionList();
    #endregion

    void Awake()
    {
        for(int i = 0;_skillButton.Count-1 >= i;i++)
        {
            SetSkillValue(i);
            SetSkillEffect(i);
        }

    }

    private void SetSkillValue(int Value)
    {
        //セットされてるidとスキル名前を保持するための文
        _setSkillIdValue.Add(_skillButton[Value].GetComponent<SkillButton>().GetSkillId());

        //タプルと呼ばれるデータ型になっているので一回保持
        (string skillName, int coolTime) skill_tuple = _skillDictionary.SkillIdDictionary[_setSkillIdValue[Value]];
        
        //その後string部分だけSkillNameに追加
        _setSkillName.Add(skill_tuple.skillName);

        _setSkillCoolTime.Add(skill_tuple.coolTime);

        #region dictionaryが完全一致じゃないとダメだと思ってた時の試行錯誤 今後のために残している
        /*int skillIdDigit = Digit(_setSkillIdValue[Value]);
        string skillIdString = null;
        //IDは000から999までの想定なので
        //Digit(int)で帰ってくる値が3以下なら4桁になるように文頭に0を追加する
        switch(skillIdDigit)
        {
            case 1:
            //IDを一度文字列に変換
            //文頭に必要個数分の0を追加
            //0追加した文字列を数字に戻して格納
            /*skillIdString = _setSkillIdValue[Value].ToString();
            skillIdString ="00"+skillIdString;
            //_setSkillIdValue[Value] = int.Parse(skillIdString);
            _setSkillName.Add(_skillDictionary.SkillIdDic[_setSkillIdValue[Value]]);
            //intに直すと前の0が消える問題はint.Parse()で解決？したっぽい
            /*Debug.Log(int.Parse(skillIdString));
            Debug.Log(_setSkillIdValue[Value]);

            break;
            case 2:
            break;
            default:
            Debug.Log(skillIdDigit);
            break;
        }*/
        #endregion
        
    }

    private void SetSkillEffect(int Value)
    {
        //GetComponentの回数を減らしたいので値を格納
        _skillButton[Value].GetComponent<SkillButton>().SetSkillName(_setSkillName[Value]);
        _skillButton[Value].GetComponent<SkillButton>().SetSkillCoolTime(_setSkillCoolTime[Value]);
        _skillButton[Value].GetComponent<Image>().sprite = _skillDictionary.SkillSprite[_setSkillIdValue[Value]];
    }

    //intの桁数を数えるやつ
    //Digit(int); で数えた数値が返ってくる
    
    public int Digit(int num)
    {
    // Mathf.Log10(0)はNegativeInfinityを返すため、別途処理する。
    return (num == 0) ? 1 : ((int)Mathf.Log10(num) + 1);
    }
}
