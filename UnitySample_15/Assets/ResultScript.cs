using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 名前空間を定義_ゲームオーバー後、シーン画面をスタートから読み込む

public class ResultScript : MonoBehaviour
{
    /*
     * ■変数宣言
     * Text型の変数text
     * GameObject型の変数obj
     * GameObject型の変数zombie1～8
     * bool型の変数flag(gameoverかclearの判別で使用)
     */
    Text text;
    GameObject obj;
    GameObject zombie1;
    GameObject zombie2;
    GameObject zombie3;
    GameObject zombie4;
    GameObject zombie5;
    GameObject zombie6;
    GameObject zombie7;
    GameObject zombie8;
    bool flag;

    /* FindメソッドHierarchy内にある
     * MessageTextにアクセスして変数textを参照する
     * Zombie1からZombie8も同じく参照
     */
    private void Start()
    {
        flag = false;
        obj = GameObject.Find("MessageText");
        text = obj.GetComponent<Text>();
        zombie1 = GameObject.Find("Zombie1");
        zombie2 = GameObject.Find("Zombie2");
        zombie3 = GameObject.Find("Zombie3");
        zombie4 = GameObject.Find("Zombie4");
        zombie5 = GameObject.Find("Zombie5");
        zombie6 = GameObject.Find("Zombie6");
        zombie7 = GameObject.Find("Zombie7");
        zombie8 = GameObject.Find("Zombie8");
    }

    // 8体のゾンビのうちいずれかに接触したらゲームオーバー（Infected!!!!表示）となる
    // StartCoroutineメソッド実行でスタートにもどる
    // ゴールできたらGetaway success!を表示
    // StrartCorroutinで同じくスタートにもどる

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Zombie1" || hit.gameObject.name == "Zombie2" || hit.gameObject.name == "Zombie3" || hit.gameObject.name == "Zombie4"
            || hit.gameObject.name == "Zombie5" || hit.gameObject.name == "Zombie6" || hit.gameObject.name == "Zombie7" || hit.gameObject.name == "Zombie8")
           {
               text.text = "Infected!!!!";
               // Coroutine実行
               StartCoroutine("BeginFirstScene");
           }

        if(hit.gameObject.name == "Goal")
        {
            text.text = "Getaway success!";
            flag = true;
            // Coroutine実行
            StartCoroutine("BeginFirstScene");
        }
    }

    // Coroutineから実行された処理をIEnumeratorが返す(2秒後にスタートに戻る)
    public IEnumerator BeginFirstScene()
    {
        if(flag)
        {
            zombie1.SetActive(false);
            zombie2.SetActive(false);
            zombie3.SetActive(false);
            zombie4.SetActive(false);
            zombie5.SetActive(false);
            zombie6.SetActive(false);
            zombie7.SetActive(false);
            zombie8.SetActive(false);
        }

        // yield return(処理を待つ時間)で処理を2秒間中断させる
        yield return new WaitForSeconds(2.0f);
        // シーンを再度読み込む
        SceneManager.LoadScene("UnitySample15-1");
    }
}