using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    // Vector3型 引き出しが開いた時(openPositon)と閉じたとき(closePosition)の座標位置をインスペクタ表示、数値入力で設定
    [SerializeField] private Vector3 openPositon, closedPosition;

    // Float型 引き出しの開閉スピードをインスペクタ表示、数値入力で設定
    [SerializeField] private float animationTime;

    /* ブーリアン型 開いているか閉じているかを「isOpen」(真偽)の値で調べている
     (これがないとEキーで開いたとき、引き出しが閉まらなくなる)
     ブール値はデフォルトの状態でfalseにする*/
    [SerializeField] private bool isOpen = false;

    // God_P.234 ハッシュテーブル：キーと値の組み合わせの情報で、
    // キーにより値を出し入れすることができる連想配列と呼ばれる配列の一種のこと
    // (これがないと引き出しを開けたとき空間に飛び出たままになった)
    private Hashtable iTweenArgs;

    void Start(){
        /* P.234 ハッシュテーブル作成_渡す引数（arguments）は2個ペア
        Property NameとTypeをカンマ区切りで追加する*/
        iTweenArgs = iTween.Hash();
        // GameObjectがアニメーション化する空間内のポイント。
        iTweenArgs.Add("position", openPositon);
        // アニメーションが完了するまでの秒数
        iTweenArgs.Add("time", animationTime);
        // 「islocal」ワールド空間でアニメ化するか、親(引き出し)を基準にしてアニメ化するか。
        // （デフォルト値はfalseでtrueにすることで親オブジェクトを基準としている）
        iTweenArgs.Add("islocal", true);
    }

    void Update(){
        // Eキーが押下されたら
        if (Input.GetKeyDown(KeyCode.E)){
            // （isOpenの値が開いているか閉じているかの状態を保持している）
            if (isOpen){
                // 引き出しが開いていたら閉じる
                iTweenArgs["position"] = closedPosition;
            }else{
                // 引き出しが閉じていたら開く
                iTweenArgs["position"] = openPositon;
            }
            //  (真偽を交互に置き換えする、ここにこれがないとEボタン連打したときに引き出しの開け閉めがうまく動作しなかった)
            isOpen = !isOpen;
            // インスペクタで設定した座標位置にアニメーション移動（引き出し開閉）
            iTween.MoveTo(gameObject, iTweenArgs);
        }
    }
}