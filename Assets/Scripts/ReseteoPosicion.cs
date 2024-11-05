using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReseteoPosicion : MonoBehaviour
{
    private Vector3 startPosition; // Guarda la posici�n inicial del jugador
    private Rigidbody rb;

    void Start()
    {
        // Almacena la posici�n inicial del jugador al comenzar el juego
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador colisiona con el suelo (o cualquier otro objeto)
        if (collision.gameObject.CompareTag("Suelo"))
        {
            // Restablece la posici�n del jugador a la posici�n inicial
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
