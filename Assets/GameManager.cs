using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // 制限時間とライフUIのために追加

public class GameManager : MonoBehaviour
{
    // ゲームが実行中かどうかを示す静的フラグ
    public static bool isGameActive = true; 

    public Block[] blocks;
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    // ゲームクリア状態のフラグを用意し、最初はfalseである
    private bool isGameClear = false;

    // --- 制限時間関連の変数 ---
    public float timeLimit = 60.0f; // 制限時間 (秒)
    private float currentTime; // 現在の時間
    public TextMeshProUGUI timeText; // 時間を表示するTextMeshProUGUI

    // --- ライフ関連の変数 ---
    public int maxLives = 3; // 初期ライフ数
    private int currentLives; // 現在のライフ
    public TextMeshProUGUI livesText; // ライフを表示するTextMeshProUGUI
    
    // GameStarterへの参照 (ボールの再発射のために必要)
    public GameStarter gameStarter; 

    // Start is called before the first frame update
    void Start()
    {
        // シーン開始時はゲームをアクティブにする
        isGameActive = true;
        
        // 制限時間の設定
        currentTime = timeLimit;
        UpdateTimeUI(); 
        
        // ライフの初期設定
        currentLives = maxLives;
        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームがアクティブで、かつまだクリアしていない場合のみ処理を実行
        if (isGameActive && !isGameClear)
        {
            // ゲームがスタートしている（ボールが発射された後）場合のみ、時間を減らす
            if (GameStarter.isGameStarted) 
            {
                // 時間のカウントダウン
                currentTime -= Time.deltaTime;
                UpdateTimeUI();
                
                // 時間切れチェック
                if (currentTime <= 0)
                {
                    currentTime = 0;
                    GameOver("Time Over");
                    return; 
                }
            }
            
            // 既存のゲームクリアチェックロジック
            if( DestroyALLBlocks())
            {
                Debug.Log("ゲームクリア");
                gameClearUI.SetActive(true);
                isGameClear = true;
                isGameActive = false; 
            }
        }
    }

    // 時間表示を更新するメソッド
    private void UpdateTimeUI()
    {
        // 整数に丸めて表示
        timeText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
    }
    
    // ライフ表示を更新するメソッド
    private void UpdateLivesUI()
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }

    // ライフを減らす処理
    public void LoseLife()
    {
        // ゲームが既に終了している場合は何もしない
        if (!isGameActive || isGameClear) return;

        currentLives--;
        UpdateLivesUI();
        
        // ライフがゼロになったかチェック
        if (currentLives <= 0)
        {
            // ライフが尽きたらゲームオーバー
            GameOver("Lives Lost");
        }
        else
        {
            // ライフが残っているなら、ボールの再発射をGameStarterに依頼する
            if (gameStarter != null)
            {
                // GameStarterにコルーチンを開始してもらい、再発射準備を行う
                gameStarter.StartCoroutine(gameStarter.ResetAndRestartBall());
            }
        }
    }

    // ブロックが全部消えたのか確認
    private bool DestroyALLBlocks()
    {
        // blocks配列内のすべてのBlockオブジェクトを一つずつループ処理
        foreach( Block b in blocks)
        {
            // ループ中のBlockがまだ存在する場合(ブロックが一つでも残っている場合)
            if( b != null)
            {
                // falseを返す
                return false;
            }
        }
        // trueを返す
        return true;
    }

    // ゲームオーバー時に
    // 引数でゲームオーバーの理由を受け取れるように修正
    public void GameOver(string reason = "Unknown")
    {
        // ゲームが既に終了している場合は重ねて実行しない
        if (!isGameActive) return;
        
        Debug.Log("ゲームオーバー: " + reason);
        // ゲームオーバーUIを表示
        gameOverUI.SetActive(true);
        // ゲームオーバー時にフラグをfalseにする
        isGameActive = false; 
    }

    // リトライボタンが押されたとき
    public void GameRetry()
    {
        // "Game Scene"をリロードする
        SceneManager.LoadScene("Game Scene");
    }
}