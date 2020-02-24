using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// マウス左クリックで玉を発射するスクリプト

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject SparkPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 引数が1の場合右クリックで発射になる
        {
            Fire();
        }

        // 1秒間に60度の速度で縦軸に砲塔の角度を傾ける、Input.GetAxis関数,操作キーを離した後スッと止まる、シューティングゲーム向き
        // Unity側での操作設定 [Edit]-[Project Settings]-[Input]-[Vertical] , [GOD] P.224
        transform. Rotate(
            // Y軸とZ軸は回転させない
            new Vector3(Input.GetAxis("Vertical") * 60.0f * Time.deltaTime , 0f , 0f) , Space.Self
        );
        // 1秒間に60度の速度で砲塔の台座を縦軸に回転させる
        // Unity側での操作設定 [Edit]-[Project Settings]-[Input]-[Horizontal]
        Transform Base = transform.parent;
        // 砲台を左右に動かすスクリプトの作成（参照先のObjectBaseがnullのためエラー）
        // < https://docs.unity3d.com/ja/2018.4/Manual/NullReferenceException.html>
        Base. Rotate(
            // 台座の縦軸回転の動き、X軸とZ軸は回転させない
            new Vector3(0f , Input.GetAxis("Horizontal") * 60.0f * Time.deltaTime , 0f) , Space.World
        　　);

    }

    void Fire()
    {
        // 玉の発射と同時に火花が散るようにする
        Transform tar = transform.Find("SparkLoc");
        Instantiate(SparkPrefab, tar.position, transform.rotation);

        // 玉に砲身の位置と角度の情報を渡して親である大砲と同じ向きに複製していく
        GameObject bullet = Instantiate(
            BulletPrefab , transform.position , transform.rotation
        );
        // 玉は重力に影響される状態Rigidbody
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        // 砲口の方向に30度の角度で玉が飛んでいく
        rb.AddForce(transform.up * 30 , ForceMode.VelocityChange);
        // 飛んでいる玉をカメラが追いかける、"Camera"という名のGameObjectを探し"ShowBullet"の命令を送る
        GameObject.Find("Camera").SendMessage("ShowBullet" , bullet);
    }
}