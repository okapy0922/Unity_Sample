using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KohakuTargetScript : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ナビメッシュエージェントが設定されているネコがtargetの後をつけていく
        agent.destination = target.transform.position;
    }
}