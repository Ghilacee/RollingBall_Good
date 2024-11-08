using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
   
    float Velocidad = 0.01f;
    [SerializeField] Vector3 direccion;
    float Timer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion.normalized * Velocidad * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer > 0.9f)
        {
            direccion = -direccion;

            Timer = 0;


        }


    }
}
