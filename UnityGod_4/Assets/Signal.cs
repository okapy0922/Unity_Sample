using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public GameObject RedCube;
    public GameObject BlueCube;

    public Material MRed;
    public Material MRedDark;
    public Material MBlue;
    public Material MBlueDark;

    public int ChangeCount = 0;

    // 信号機の最初の状態から3秒経ったら5秒間隔でChangesignalを呼び出す
    void Start()
    {
        RedCube.GetComponent<Renderer>().material = MRed;
        BlueCube.GetComponent<Renderer>().material = MBlueDark;
        // InvokeRepeatingでChangeSignalを繰り返す
        InvokeRepeating("ChangeSignal", 3f, 5f);
    }

    void ChangeSignal()
    {
        ChangeCount++;
        if(ChangeCount % 2 == 0)
        {
            RedCube.GetComponent<Renderer>().material = MRedDark;
            BlueCube.GetComponent<Renderer>().material = MBlue;

        }else{
            RedCube.GetComponent<Renderer>().material = MRed;
            BlueCube.GetComponent<Renderer>().material = MBlueDark;
        }

    }
}