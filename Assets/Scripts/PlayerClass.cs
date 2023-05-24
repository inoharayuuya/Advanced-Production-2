using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    #region  プライベート

    #endregion

    #region  パブリック
    // プレイヤー1
    [SerializeField] public int p1_attack = 10;  // プレイヤー1の攻撃力
    [SerializeField] public int p1_hp = 100;     // プレイヤー1のHP
    public int g_p1_hp;

    // プレイヤー2
    [SerializeField] public int p2_attack = 10;  // プレイヤー2の攻撃力
    [SerializeField] public int p2_hp = 100;     // プレイヤー2のHP
    public int g_p2_hp;
    #endregion

    private void Start()
    {
        g_p1_hp     = p1_hp;
        g_p2_hp     = p2_hp;
    }
}
