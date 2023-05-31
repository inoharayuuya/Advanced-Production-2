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
            int rand = Random.Range(1, 4);

            switch(rand)
            {
                case 1:
                    SceneManager.LoadScene("Stage1");
                    break;

                case 2:
                    SceneManager.LoadScene("Stage2");
                    break;

                case 3:
                    SceneManager.LoadScene("Stage3");
                    break;
            }
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
