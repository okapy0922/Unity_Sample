using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    // しばらく残る火の粉を消し去るためのスクリプト
    void Start()
    {
        // 10秒後に消える
        Invoke("Death", 10f);
    }

    void Death()
    {
        Destroy(gameObject);
    }
}