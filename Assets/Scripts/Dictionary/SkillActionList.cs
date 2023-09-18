using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillAction
{
    //取り回しがしやすいように名前空間に定義
    public class SkillActionList
    {
        public void SkillAction(int SkillId)
        {
            //Dictionaryのvalueが流れて来る想定での構築
            switch(SkillId)
            {
                case 0:
                NotSkill();
                break;

                case 1:
                AttackSkill();
                break;

                case 2:
                HeelSkill();
                break;

                case 3:
                BlockSkill();
                break;

                default:
                NotSkill();
                break;
            }
        }

        //実際呼ばれる内容
        private void NotSkill()
        {
            Debug.Log("効果は何も無いようだ");
        }

        private void AttackSkill()
        {
            Debug.Log("攻撃スキル！");
        }

        private void HeelSkill()
        {
            Debug.Log("回復スキル！");
        }

        private void BlockSkill()
        {
            Debug.Log("防御スキル！");
        }
    }
}
