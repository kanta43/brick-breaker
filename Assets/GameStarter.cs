using UnityEngine;
using TMPro; // TextMeshProを使うために必要
using System.Collections; // コルーチンを使うために必要

public class GameStarter : MonoBehaviour
{
    // 他のスクリプトからゲーム開始状態を参照するための静的変数
    public static bool isGameStarted = false; 

    // Unityエディタから設定できるようにpublicにする (TextMeshProUGUI型に修正)
    public TextMeshProUGUI countdownText; 
    public Ball gameBall; // Ballクラスへの参照
    public int countdownTime = 3; // カウントダウンの初期秒数

    void Start()
    {
        // シーン開始時はまだゲームを動かさない
        isGameStarted = false; 
        
        // カウントダウン処理を開始
        StartCoroutine(CountdownToStart()); 
    }

    IEnumerator CountdownToStart()
    {
        // 3から1までカウントダウン
        while (countdownTime > 0)
        {
            // UIに秒数を表示
            countdownText.text = countdownTime.ToString(); 
            
            // 1秒間待機
            yield return new WaitForSeconds(1f); 

            countdownTime--;
        }

        // カウントダウン終了
        countdownText.text = "START!"; 
        isGameStarted = true; //  ゲーム開始フラグを立てる

        // ボールを発射する
        if (gameBall != null)
        {
            gameBall.StartBall(); 
        }

        // 「START!」の表示後、少し待ってUIを非表示にする
        yield return new WaitForSeconds(0.5f); 
        countdownText.gameObject.SetActive(false); 
    }
}