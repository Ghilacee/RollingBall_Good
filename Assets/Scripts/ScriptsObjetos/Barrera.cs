using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{
    float Velocidad = 60f;
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
        if (Timer > 1.5f)
        {
            direccion = -direccion;
            Timer = 0;

        }


    }
}
