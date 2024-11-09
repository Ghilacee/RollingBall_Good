using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasMov : MonoBehaviour
{
    float Velocidad = 0.3f;
    [SerializeField] Vector3 direccion;
    float Timer = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion.normalized * Velocidad * Time.deltaTime);
        Timer += Time.deltaTime;
        if (Timer > 2f)
        {
            direccion = -direccion;

            Timer = 0;


        }


    }
}
