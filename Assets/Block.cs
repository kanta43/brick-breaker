using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 物が当たった時
    private void OnCollisionEnter(Collision Collision)
    {
        // このオブジェクトを壊す
        Destroy(this.gameObject);
    }
}
