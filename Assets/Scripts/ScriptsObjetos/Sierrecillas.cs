using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierrecillas : MonoBehaviour
{
    [SerializeField] private Vector3 direccionR = new Vector3(0, 1, 0);  // Dirección de rotación sobre el eje Y
  
    [SerializeField] private float fuerzaR = 0.001f;  // Aumenta la fuerza de rotación
   
    private float timer = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Obtén el Rigidbody
    }

    void FixedUpdate()
    {
        // Aplica torque para girar el objeto (rotación sobre el eje Y)
        rb.AddTorque(direccionR * fuerzaR, ForceMode.Force);

     
       
        timer += Time.fixedDeltaTime;

        // Cambia la dirección D cada 3 segundos
        if (timer > 5f)
        {

             fuerzaR = 0.0001f;

        }

    }
   
}
