using UnityEngine;

public class DropTofu : MonoBehaviour
{
    [SerializeField] GameObject tofu;
    // 補足:[SerializeField] シリアライゼーション、Unity上で編集できるようにする
    // https://qiita.com/makopo/items/8ef280b00f1cc18aec91

    int TofuCount = 0;

    void Start()
    {
        InvokeRepeating("DropOne", 2f, 1f);
        // 2秒経ったらDropOneメソッドを呼び出す、以降1秒ごとに呼び出す
    }

    void DropOne()
    // DropOneが呼ばれたら以下を実行する
    {
        TofuCount++;
        // TofuCountの値を一つ追加
        Instantiate(tofu , new Vector3(2.5f , 5.0f , 0.0f) , Quaternion.identity);
        // 変数tofuに設定されているGameObject(tofu)をY軸5Mの高さに生成して囲いの中に入るようにする
        // https://qiita.com/Teach/items/c28b4fe5ca8dc4c83e26
        if (TofuCount == 100)
        {
            CancelInvoke();
            // tofuが100個生成されたら繰り返し呼び出しを中止する
        }
    }
}