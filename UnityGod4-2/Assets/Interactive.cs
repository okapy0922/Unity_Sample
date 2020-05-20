using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gameObjectにカーソルが接触していたらRaycastで触れ、開閉を行う

public class Interactive : MonoBehaviour{
    // Float型 Rayの有効範囲を値で入力
    [SerializeField] private float interactRange;

    //InteractiveObject.csを呼び出すため
    private InteractiveObject interactiveObject;

    /* カメラ型の変数cam 
    (FPSコントローラのインスペクター内を確認する、
    メインカメラとしてタグ付けされたCameraコンポーネントがある場合にRaycastが機能するようにしている)
    メインカメラがタグ付けされているオブジェクトはシーン内で1つだけにすること*/
    private Camera cam;

    // Raycast型の変数hit
    private RaycastHit hit;

    void Start(){
        // シーン開始時にメインカメラのCameraコンポーネントを変数camに取得する
        cam = Camera.main;
    }

    // Eキーを押した瞬間にRaycastを実行する
    void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            /* Raycastの判定
             レーザービームが伸びた先までに何かにぶつかるものがあるかどうか、
             Rayの有効距離はメインカメラ(Player)の座標位置からinteractRangeに格納されている位置情報の値まで*/ 
            Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange);
            // Raycastがゲームオブジェクトにhitしたら
            if (hit.transform) {
                // InteractiveObject.cs内の開閉処理をよびだす
                interactiveObject = hit.transform.GetComponent<InteractiveObject>();
            }else{
            // Raycastで触れていないときは開閉処理しない、nullを指定する
            //（これがないと引き出しに触れ開閉した後、触れてない状態でも引き出しの開閉ができてしまう）
                interactiveObject = null;
            }
            // nullであるかどうか判定処理(NullRefarenceExeptionを回避)
            if (interactiveObject) {
            // InteractiveObject.csのPerformAtionメソッドを呼び出す
            interactiveObject.PerformAction();
            }
        }
    }
}