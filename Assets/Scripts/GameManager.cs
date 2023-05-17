using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region  プライベート
    GameObject Timer;
    PanelAndCountDownController panelController;
    #endregion

    #region  パブリック

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
        if(panelController.CountTimer == 0.0F)
        {
            panelController.GameSet();
            Debug.Log("終了");
        }

        if(panelController.GameSetTimer == 0.0F)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    #endregion
}
