﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//P.228 玉がボログルマに着弾するとボログルマがだんだん壊れていくスクリプト

public class Destruction : MonoBehaviour
{
    // 玉がぶつかった回数を記憶する int hitCount
    int hitCount = 0;

    // Start後にオブジェクト自身のRigidbodyを参照して情報を格納するためのrb
    public Rigidbody rb;

    // GameObject型のDamageLevels、GameObjectのもののみ配列に入れる
    public GameObject[] DamageLevels;

    // 煙エフェクト Unity側でSmokeをドロップする
    public GameObject SmokePt;

    // ビルトイン配列を定義 配列数を指定して子オブジェクトをtransform.Findで探す、damage_levelのGameObject
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DamageLevels = new GameObject[3];
        DamageLevels[0] = transform.Find("damage_level1").gameObject;
        DamageLevels[1] = transform.Find("damage_level2").gameObject;
        DamageLevels[2] = transform.Find("damage_level3").gameObject;
    }

    /*
    // For文を使うともう少しすっきりする
    // (子オブジェクトの参照先がみつからない、原因分からず)NullReferenceException: Object reference not set to an instance of an object
       Destruction.Start () (at Assets/Destruction.cs:47)
    void Start()
    {
        // 自分のRigidbodyを格納して参照する
        rb = GetComponent<Rigidbody>();
        // 3段階で壊れるボログルマを配列で用意
        DamageLevels = new GameObject[3];

        // ダメージレベルが上がったら各ダメージレベルのオブジェクトを呼ぶくりかえし
        for(var n = 0; n < 3; n++)
        {
            // 1段階壊れたオブジェクトから後+1ずつ呼び出す、3段階目まで
            // 非アクティブ(ディアクティベート)状態の子オブジェクトも取得できるtransform.Find
            DamageLevels[n] = transform.Find("damage_level1" + (n + 1)).gameObject;
        }
    }
    */

    // BulletBehaviour.csから送られてきたら反応するAdd_Damageメソッド
    void Add_Damage()
    {
        // 玉がぶつかるたびに煙のsmをinstantiate(インスタンス化する、シーン中に表示させる)
        GameObject sm = Instantiate(SmokePt, transform.position, transform.rotation);
        // smoke出現後はボログルマを親とする
        sm.transform.parent = transform;
        // hitcount2以上はreturn、玉からAdd_Damageが呼ばれるとメソッドの処理は終わり
        if (hitCount > 2)
            return;
        // ボログルマのダメージが0の状態はSmokeを非表示
        DamageLevels[hitCount].SetActive(false);

        // インクリメント hitCountという整数の値に１を足すこと
        hitCount++;

        // ボログルマのダメージ1以上の状態はSmokeを表示
        DamageLevels[hitCount].SetActive(true);
    }

}
