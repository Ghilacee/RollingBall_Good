using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartilloGiratorio : MonoBehaviour
{
    float Velocidad = 80f;
    [SerializeField] Vector3 direccion;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direccion.normalized * Velocidad * Time.deltaTime , Space.World);
       


    }

}
