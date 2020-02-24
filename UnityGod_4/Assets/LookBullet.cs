using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LookBullet : MonoBehaviour
{
    // 玉の位置情報を取得
    Transform TargetBullet;
    void Update()
    {
        if (TargetBullet)
        {
            // 玉が発射されたら自分の向いている向きを常に玉の飛んでる方向にする
            transform.LookAt(TargetBullet);
        }
    }
    // 玉の位置情報からcameraが玉を追尾していく定義
    public void ShowBullet(GameObject Target)
    {
        TargetBullet = Target.transform;
    }
}