using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra : MonoBehaviour
{
   
    [SerializeField] private Vector3 direccionR = new Vector3(0, 1, 0); // Eje de rotaci�n
    [SerializeField] private float fuerzaR = 2f; // Incrementa el valor si la rotaci�n es muy d�bil

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(direccionR * fuerzaR, ForceMode.Force); // Aplica el torque continuamente
    }
}

