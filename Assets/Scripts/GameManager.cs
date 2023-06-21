using SoftGear.Strix.Unity.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region  �v���C�x�[�g
    GameObject Timer;
    PanelAndCountDownController panelController;
    GameObject playerClass;
    PlayerClass player;
    #endregion

    #region  �p�u���b�N
    bool GameEndFlg;
    #endregion

    #region  Init�֐�
    /// <summary>
    /// Init�֐�
    /// �ϐ��̏�������A�ŏ��ɂ���������������
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

    #region  �X�^�[�g�֐�
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    #endregion

    #region  �A�b�v�f�[�g�֐�
    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[��0�ɂȂ邩�A�v���C���[1,2��HP��0�ɂȂ�����I��
        if(panelController.CountTimer == 0.0F || player.g_p1_hp <= 0 || player.g_p2_hp <= 0)
        {
            GameEndFlg = true;
        }

        if(GameEndFlg == true)
        {
            panelController.GameSet();
            Debug.Log("�I��");
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
