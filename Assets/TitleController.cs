using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要

public class TitleController : MonoBehaviour
{
    // Unityエディタから設定する、ゲーム本編のシーン名
    public string gameScene = "Game Scene"; 
    
    // Unityエディタから設定する、操作説明のシーン名
    public string controlsScene = "ControlsScene";

    // スタートボタンが押されたときに呼び出すメソッド
    public void StartGame()
    {
        // 指定した名前のシーンをロードして切り替える
        SceneManager.LoadScene(gameScene);
    }

    // 操作説明ボタンが押されたときに呼び出すメソッド
    public void LoadControls()
    {
        // 操作説明シーンをロードする
        SceneManager.LoadScene(controlsScene);
    }
    
    // タイトルに戻るボタンが押されたときに呼び出すメソッド
    public void LoadTitle()
    {
        // タイトルシーンをロードする
        SceneManager.LoadScene("Title Scene");
    }
}