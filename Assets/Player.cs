using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 左矢印キーが押されたら
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //  x座標が‐4より大きい場合
            if (this.transform.position.x > -4)
            {
                // 左に移動
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        
        // 右矢印キーが押されたら
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //  x座標が4より小さい場合
            if (this.transform.position.x < 4)
            {
                // 右に移動
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
