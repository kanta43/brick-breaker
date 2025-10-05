using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody myRigid;
    public GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        // このゲームオブジェクトについているRigidbodyコンポーネントを取得し、それをmyRigidという変数に入れる
        myRigid = this .GetComponent<Rigidbody>();
        // このゲームオブジェクトのRigidbodyコンポーネントに対して、そのゲームオブジェクトの前方と右方向へ、speedで指定された強さの力を、瞬時に速度を変更するモードで加える
        myRigid.AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 物が当たった時
    private void OnCollisionEnter(Collision Collision)
    {
        // 衝突したゲームオブジェクトのタグが"Finish"ならば
        if( Collision.gameObject.tag == "Finish")
        {
             // このオブジェクトを壊す
             Destroy(this.gameObject);
             // ゲームオーバー処理を実行する関数を呼び出す
             myManager.GameOver();
        }
    }

}
