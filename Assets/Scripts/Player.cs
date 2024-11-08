using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float fuerzaMovimiento = 1.5f;
    //[SerializeField] float direccion = 20f;
    //[SerializeField] Vector3 movimiento;
    [SerializeField] private float distanciaRaycast;
    private float h, v;
    Rigidbody rb;

    [SerializeField] private int puntos;
    [SerializeField] private int vida = 5;
    
    //OBJETO DA�INO
    private bool enObjetoDanino = false; // Si el jugador est� en el objeto da�ino
    private float tiempoSiguienteDano;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DetectaSuelo() == true)
            {
                rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            }

        }
        if (puntos > 5)
        {
            vida += 1;
            puntos -= 5; 
          // por cada 5 puntos ganas 1 de vida 
        }

        //OBJETO DA�INO
        if (enObjetoDanino && Time.time >= tiempoSiguienteDano)
        {
            vida -= 2;                             
            tiempoSiguienteDano = Time.time + 5f;   
            Debug.Log("Vida actual: " + vida);

            if (vida <= 0)
            {
                Debug.Log("Game Over");
               
            }
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(h, 0, v).normalized * fuerzaMovimiento, ForceMode.Force);
    
    }


    private bool DetectaSuelo()
    {
        bool resultado = Physics.Raycast(transform.position, Vector3.down, distanciaRaycast);
        Debug.DrawRay(transform.position, Vector3.down * distanciaRaycast, Color.red, 2f);
        return resultado;
    }
    
   
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Martillo"))
        {
            vida -= 1;
        }
        if (collision.gameObject.CompareTag("sierraKiller"))
        {
            Destroy(gameObject);
        }


        //OBJETO DA�INO
        if (collision.gameObject.CompareTag("Tablones"))
        {
            enObjetoDanino = true;
            tiempoSiguienteDano = Time.time + 5f; // Inicia el temporizador de da�o
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Moneda"))
        {
            puntos += 1;
        }

       
    }


    private void OnCollisionExit(Collision collision)
    {
        // Detiene el da�o continuo cuando el jugador sale del objeto da�ino
        if (collision.gameObject.CompareTag("Tablones"))
        {
            enObjetoDanino = false;
        }
    }
}




