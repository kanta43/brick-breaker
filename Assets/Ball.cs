// Ball.cs の修正案
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody myRigid;
    public GameManager myManager;
    
    // --- 【追加】初期位置を保持する変数 ---
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // このゲームオブジェクトについているRigidbodyコンポーネントを取得し、それをmyRigidという変数に入れる
        myRigid = this .GetComponent<Rigidbody>();
        // 初期位置を保存
        initialPosition = transform.position;
    }
    
    // ボールを初期位置に戻すメソッド
    public void ResetBallPosition()
    {
        // 速度をリセット
        myRigid.linearVelocity = Vector3.zero;
        myRigid.angularVelocity = Vector3.zero;
        
        // 位置を初期位置に戻す
        transform.position = initialPosition;
        
        // ボールが見えるように再アクティブ化
        this.gameObject.SetActive(true);
    }

    // GameStarterから呼び出され、ボールを発射するメソッド
    public void StartBall()
    {
        // このゲームオブジェクトのRigidbodyコンポーネントに対して、そのゲームオブジェクトの前方と右方向へ、speedで指定された強さの力を、瞬時に速度を変更するモードで加える
        myRigid.AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        // ゲーム非アクティブならボールの動きを止める
        if (!GameManager.isGameActive) 
        {
            // 速度をゼロにして動きを完全に止める
            if (myRigid.linearVelocity != Vector3.zero)
            {
                myRigid.linearVelocity = Vector3.zero;
            }
            return;
        }
    }

    // 物が当たった時
    private void OnCollisionEnter(Collision Collision)
    {
        // 衝突したゲームオブジェクトのタグが"Finish"ならば
        if( Collision.gameObject.tag == "Finish")
        {
             // ボールを非アクティブにする（破壊すると再生成が面倒なため）
             this.gameObject.SetActive(false);
             
             // ゲームマネージャーにライフを減らすよう伝える
             myManager.LoseLife();
             
             // 元々あったDestroy(this.gameObject)とmyManager.GameOver()は削除
        }
    }
}