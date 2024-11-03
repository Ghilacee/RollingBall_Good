using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acha : MonoBehaviour
{
    float Velocidad = 80f;
    [SerializeField] Vector3 direccion;
    float Timer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccion.normalized * Velocidad * Time.deltaTime, Space.World);
        Timer += Time.deltaTime;
        if (Timer > 2.3f)
        {
            direccion = -direccion;
            Timer = 0;

        }
       

    }
}
