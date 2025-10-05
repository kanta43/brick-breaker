using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Block[] blocks;
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    // ゲームクリア状態のフラグを用意し、最初はfalseである
    private bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームクリアのフラグがtrueでない時
        if( isGameClear != true)
        {
            // 全てのブロックが壊されたら
            if( DestroyALLBlocks())
            {
                // コンソールに"ゲームクリア"を表示
                Debug.Log("ゲームクリア");
                // ゲームクリアUIを表示する
                gameClearUI.SetActive(true);
                // ゲームクリアのフラグをtrueにする
                isGameClear = true;
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
    public void GameOver()
    {
        // コンソールに"ゲームオーバー"を表示
        Debug.Log("ゲームオーバー");
        // ゲームオーバーUIを表示
        gameOverUI.SetActive(true);
    }

    // リトライボタンが押されたとき
    public void GameRetry()
    {
        // "game"をリロードする
        SceneManager.LoadScene("game");
    }
}
