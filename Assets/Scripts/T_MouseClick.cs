using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T_MouseClick : MonoBehaviour
{
    #region  �N���b�N�֐�
    /// <summary>
    /// �N���b�N�֐�
    /// �}�E�X�ŃN���b�N���ꂽ�Ƃ��ɌĂяo�����
    /// </summary>
    public void MouseClick()
    {
        // �}�E�X�̍��N���b�N�������ꂽ�Ƃ��̏���
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("HpBarTestScene");
        }
    }
    #endregion

    #region  �A�b�v�f�[�g�֐�
    /// <summary>
    /// �A�b�v�f�[�g�֐�
    /// �t���[�����ƂɌĂ΂��
    /// </summary>
    private void Update()
    {
        MouseClick();
    }
    #endregion
}
