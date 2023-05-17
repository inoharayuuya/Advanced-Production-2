using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region  �v���C�x�[�g
    GameObject Timer;
    PanelAndCountDownController panelController;
    #endregion

    #region  �p�u���b�N

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
        if(panelController.CountTimer == 0.0F)
        {
            panelController.GameSet();
            Debug.Log("�I��");
        }

        if(panelController.GameSetTimer == 0.0F)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    #endregion
}
