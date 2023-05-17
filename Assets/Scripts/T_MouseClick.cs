using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T_MouseClick : MonoBehaviour
{
    #region  クリック関数
    /// <summary>
    /// クリック関数
    /// マウスでクリックされたときに呼び出される
    /// </summary>
    public void MouseClick()
    {
        // マウスの左クリックが押されたときの処理
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("HpBarTestScene");
        }
    }
    #endregion

    #region  アップデート関数
    /// <summary>
    /// アップデート関数
    /// フレームごとに呼ばれる
    /// </summary>
    private void Update()
    {
        MouseClick();
    }
    #endregion
}
