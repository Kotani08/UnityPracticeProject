using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live2DPlayerControl : SingletonMonoBehaviour<Live2DPlayerControl>
{
    [SerializeField]
    private GameObject player;
    //座標の変数定義
    private Vector3 pos;
    private Animator playerAnimator;

    void Start()
    {
        pos = player.transform.position;
        playerAnimator = player.GetComponent<Animator>();
    }

    #region 共通処理クラス

    public void PlayerMove(float Value)
    {
        playerAnimator.SetFloat("WalkSpeed", Value);
    }

    #endregion
}
