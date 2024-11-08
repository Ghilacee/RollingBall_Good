using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchis_Izq : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (Timer > 0.8f)
        {
            direccion = -direccion;

            Timer = 0;


        }


    }
}
