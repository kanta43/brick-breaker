using UnityEngine;

public class 障害物の制御 : MonoBehaviour
{
    // インスペクターで設定する移動パラメータ
    [Header("移動設定")]
    [Tooltip("移動の振幅 (どれだけ動くか)")]
    public float amplitude = 3.0f; 

    [Tooltip("移動の速さ")]
    public float speed = 1.0f; 

    [Tooltip("移動の方向 (例: X軸なら Vector3.right)")]
    public Vector3 direction = Vector3.right; 

    private Vector3 startPosition;

    void Start()
    {
        // 障害物の初期位置を保存
        startPosition = transform.position;

        // directionを正規化して、振幅設定をより直感的に
        direction.Normalize();
    }

    void Update()
    {
        // 時間に応じた移動の進行度を計算
        // Mathf.Sin() は -1 から 1 の間で変化し、往復移動に適しています
        float progress = Mathf.Sin(Time.time * speed);

        // 進行度と振幅、方向を使って新しい位置を計算
        // progress * amplitude で振幅内の移動距離を決定
        Vector3 offset = direction * amplitude * progress;

        // 新しい位置をオブジェクトに適用
        transform.position = startPosition + offset;
    }
}