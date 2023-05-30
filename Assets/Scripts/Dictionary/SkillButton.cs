using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//独自のnamespace
using SkillAction;

public class SkillButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    #region 型宣言
    [SerializeField]
    private int _skillId;
    public int GetSkillId(){return _skillId;}

    [SerializeField]
    private string _skillName;
    public string GetSkillName(){return _skillName;}
    public void SetSkillName(string Name)
    {
        _skillName = Name;
    }

    [SerializeField]
    private int _skillCoolTime;
    public int GetSkillCoolTime(){return _skillCoolTime;}
    public void SetSkillCoolTime(int CoolTime)
    {
        _skillCoolTime = CoolTime;
    }

    private SkillTimer _skillTimer;

    #region namespaseの宣言
    private SkillActionList SkillActionList= new SkillAction.SkillActionList();
    #endregion
    [SerializeField]
    private Text SkillText;
    #endregion

    void Start()
    {
        _skillTimer=this.GetComponent<SkillTimer>();
    }
    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //押されたとき
    }

    //離されたときの処理
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        //保持しているスキル名をSkillActionListに流して効果を使う
        //SkillActionList.SkillActionList SkillActionList = new SkillActionList.SkillActionList();
        SkillActionList.SkillAction(_skillId);
        _skillTimer.SkillTimerStart();
        SkillActionDisp();
    }

    private void SkillActionDisp()
    {
        SkillText.text = _skillName+"ボタンが押された";
    }
}