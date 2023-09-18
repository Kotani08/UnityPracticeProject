using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//using PlayerSaveData;

namespace PlayerSaveData
{
    //PlayerDataを可視化して作ってる最中にデバッグをしやすくする目的でScriptable化

    [CreateAssetMenu(menuName = "MyScriptable/PlayerData")]

    [System.Serializable]
    public class PlayerData : ScriptableObject
    {
        //可視化したい保持データ
        public string Name;
        public int[] SetSkillId = new int[3];
        public bool Toggle = false;

    }

    public class SaveDataEditor
    {
        //jsonでの書き込み読み込みを行う
        [SerializeField]
        private PlayerData _save;
        string json;

        private void OnApplicationQuit()
        {
            SaveGameData();
            Debug.Log(" OnApplicationQuit");
        }
        private void OnDisable()
        {
            SaveGameData();
            Debug.Log(" OnDisable");
        }


        public void SaveGameData()
        {
            //書き込み
            //string getFilePath() { return Application.persistentDataPath + "/PaintData" + ".json"; }
            string getFilePath = Directory.GetCurrentDirectory();
            getFilePath += ("/" + "save.json");

            json = JsonUtility.ToJson(_save);
            using (var sw = new StreamWriter(getFilePath, false))
            {
                try
                {
                    sw.Write(json);
                    //Debug.Log(json);
                }
                catch (Exception e) //エラーキャッチ
                {
                    Debug.Log(e);
                }
            }
        }

        public void LoadGameData()
        {
            //Jsonで書き出したデータの読み込み
            JsonUtility.FromJsonOverwrite(json, _save);
        }
    }
}