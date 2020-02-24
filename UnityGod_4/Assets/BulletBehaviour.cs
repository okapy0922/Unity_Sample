using UnityEngine;
// 玉が何かにぶつかったら爆発して玉がその場からなくなる
public class BulletBehaviour : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    // 当たった時に呼ばれる関数 OnCollisionEnter
    void OnCollisionEnter(Collision collision)
    {
        // 玉が何かにぶつかったら爆発する処理
        // Instantiateで生成する、ExplosionPrefabを元に玉が爆発
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        // 玉がなくなる処理
        Destroy(gameObject);

    }
}