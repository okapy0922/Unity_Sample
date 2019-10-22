using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScirpt : MonoBehaviour
{
    // 変数の宣言
    GameObject obj;
    ParticleSystem ps;

    void Start()
    {
        /* Startオブジェクトで以下を呼び出しする
         * ①Findでヒエラルキー内のenergyBlastにアクセス
         * ②GetComponentInChildrenでenergyBlastと
         * ③その中にあるParticleSystemにアクセス
         * SetActive（false）でenergyBlastが発動しない状態
         */
        obj = GameObject.Find("energyBlast");//①
        ps = obj.GetComponentInChildren<ParticleSystem>();//②
        obj.SetActive(false);//③
    }

    /*ParticleSystemGoオブジェクトでボタン押下後の
     * 以下処理が実行される
     * ④SetActive(true)でenergyBlastが発動する状態
     * ⑤PlayでenergyBlastを実行
     */

    public void ParticleSystemGo()
    {
        obj.SetActive(true);//④
        ps.Play();//⑤
    }
}