using UnityEngine;
// 玉が何かにぶつかったら爆発して玉がその場からなくなる
public class BulletBehaviour : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    // 当たった時に呼ばれる関数 OnCollisionEnter
    void OnCollisionEnter(Collision collision)
    {
        // [玉が着弾したらAdd_Damageを送る、Add_Damageメソッドを持っているオブジェクトに着弾すると処理が動く]

        // （Unity側で）タグにCarがついてるGameObjectに着弾したらAdd_Damageを送る
        if (collision.gameObject.tag == "Car")
            // Add_Damageを送る、メソッドを持っているスクリプトが反応する
            // SendMessageには引数が１つしかつけられない、エラーを出力しないため注意が必要？
            collision.gameObject.SendMessage("Add_Damage");

        // 玉が何かにぶつかったら爆発する処理
        // Instantiateで爆破エフェクト表示、ExplosionPrefabを元に玉が爆発
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);

        // 玉がなくなる処理
        Destroy(gameObject);

    }
}