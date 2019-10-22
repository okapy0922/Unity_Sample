using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMoveScript : MonoBehaviour
{
    void Update()
    {
        //hump_back_whaleは後ろに進むから-0.01、負の値を設定すると前に進む
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * -0.01f;
        }
        if(Input.GetKey("right"))
        {
            transform.Rotate(0, 2, 0);
        }
        if(Input.GetKey("left"))
        {
            transform.Rotate(0, -2, 0);
        }

    }
}