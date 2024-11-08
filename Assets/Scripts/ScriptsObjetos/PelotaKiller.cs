using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaKiller : MonoBehaviour
{
    float Velocidad = 0.1f;
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
        if (Timer > 3f)
        {
            direccion = -direccion;

            Timer = 0;


        }


    }
}
