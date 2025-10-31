using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要

public class TitleController : MonoBehaviour
{
    // Unityエディタから設定する、ゲーム本編のシーン名
    public string gameScene = "Game Scene"; 

    // スタートボタンが押されたときに呼び出すメソッド
    public void StartGame()
    {
        // 指定した名前のシーンをロードして切り替える
        SceneManager.LoadScene(gameScene);
    }
}