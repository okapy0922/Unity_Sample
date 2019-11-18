using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // AIに含まれているナビゲーションを使用、UnityEngine.AIを読み込こんでおく

public class ZombieSpeedScript : MonoBehaviour
{
    /*
     * ゾンビの歩行速度を3.0fから6.0fとするスクリプト
     * 変数宣言
     * 1. float型の変数speedRandom
     * 2. NavMeshAgent型の変数Agent
     */

    float speedRandom;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        // RandomRangeで「3.0fから6.0f」までの乱数を指定、変数speedRandomに格納する
        speedRandom = UnityEngine.Random.Range(3.0f, 6.0f);
        // 各ゾンビの歩行スピードをランダムに設定する
        agent.speed = speedRandom;
        
    }
}