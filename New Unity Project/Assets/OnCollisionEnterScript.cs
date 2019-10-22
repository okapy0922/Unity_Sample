using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}