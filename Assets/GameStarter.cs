// GameStarter.cs の修正案 (抜粋)
using UnityEngine;
using TMPro; 
using System.Collections; 

public class GameStarter : MonoBehaviour
{
    // 他のスクリプトからゲーム開始状態を参照するための静的変数
    public static bool isGameStarted = false; 

    public TextMeshProUGUI countdownText; 
    public Ball gameBall; // Ballクラスへの参照
    public int countdownTime = 3; // カウントダウンの初期秒数
    
    // --- 再スタート用の変数 ---
    private readonly int initialCountdownTime = 3; // カウントダウンの初期値

    void Start()
    {
        // シーン開始時はまだゲームを動かさない
        isGameStarted = false; 
        
        // カウントダウン処理を開始
        StartCoroutine(CountdownToStart()); 
    }
    
    // ライフ減少時にGameManagerから呼び出される再スタート処理
    public IEnumerator ResetAndRestartBall()
    {
        isGameStarted = false; // ボールの再発射までプレイヤー操作を止める
        
        // ボールを初期位置に戻す
        gameBall.ResetBallPosition();
        
        // カウントダウンテキストを表示
        countdownText.gameObject.SetActive(true);
        
        // カウントダウンコルーチンを実行
        yield return StartCoroutine(CountdownToStart());
    }


    IEnumerator CountdownToStart()
    {
        // カウントダウンタイマーを初期値に戻す
        int count = initialCountdownTime; 

        // 3から1までカウントダウン
        while (count > 0)
        {
            // UIに秒数を表示
            countdownText.text = count.ToString(); 
            
            // 1秒間待機
            yield return new WaitForSeconds(1f); 

            count--;
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