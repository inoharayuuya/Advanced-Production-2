using SoftGear.Strix.Unity.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region  プライベート
    GameObject Timer;
    PanelAndCountDownController panelController;
    GameObject playerClass;
    PlayerClass player;
    #endregion

    #region  パブリック
    bool GameEndFlg;
    #endregion

    #region  Init関数
    /// <summary>
    /// Init関数
    /// 変数の初期化や、最初にしたい処理を書く
    /// </summary>
    void Init()
    {
        Timer = GameObject.Find("PanelAndCountDownManager");
        panelController = Timer.GetComponent<PanelAndCountDownController>();
        playerClass = GameObject.Find("PlayerClass");
        player = playerClass.GetComponent<PlayerClass>();
        GameEndFlg = false;
    }
    #endregion

    #region  スタート関数
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    #endregion

    #region  アップデート関数
    // Update is called once per frame
    void Update()
    {
        // タイマーが0になるか、プレイヤー1,2のHPが0になったら終了
        if(panelController.CountTimer == 0.0F || player.g_p1_hp <= 0 || player.g_p2_hp <= 0)
        {
            GameEndFlg = true;
        }

        if(GameEndFlg == true)
        {
            panelController.GameSet();
            Debug.Log("終了");
        }

        if(panelController.GameSetFlg == true)
        {
            StrixNetwork.instance.roomSession.Disconnect();

            SceneManager.LoadScene("StrixSettingsScene");
        }

        var uid = StrixNetwork.instance.selfRoomMember;

        Debug.Log("uid: " + uid.GetUid());
    }
    #endregion
}
