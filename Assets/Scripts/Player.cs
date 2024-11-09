using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float fuerzaMovimiento = 1.5f;
    [SerializeField] private float distanciaRaycast;
    private float h, v;
    Rigidbody rb;

    [SerializeField] private int puntos;
    [SerializeField] private int vida = 5;
    [SerializeField] TMP_Text textoVida;
    [SerializeField] TMP_Text textoPuntos;

    //OBJETO DAÑINO
    private bool enObjetoDanino = false; 
    private float tiempoSiguienteDano;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ActualizarHUD();
    }

    // Update is called once per frame
    void Update()
    {
        VerificarMuerte();
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
            
            ActualizarHUD();
        }

        
        if (enObjetoDanino && Time.time >= tiempoSiguienteDano)
        {
            vida -= 2;                             
            tiempoSiguienteDano = Time.time + 5f;
            ActualizarHUD();

            if (vida >= 0)
            {
                Morir();
               
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
        if (collision.gameObject.CompareTag("PinchosKiller"))
        {
            vida -= 3;
        }
        if (collision.gameObject.CompareTag("sierraKiller"))
        {
            vida -= 5;
            textoVida.SetText("Vida: " + vida);
           
            Morir();
        }



        
        if (collision.gameObject.CompareTag("Tablones"))
        {
            enObjetoDanino = true;
            tiempoSiguienteDano = Time.time + 5f; 
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Moneda"))
        {
            puntos += 1;
            Destroy(other.gameObject);        
        }

       
    }


    //private void OnCollisionExit(Collision collision)
    //{
        
    ////    if (collision.gameObject.CompareTag("Tablones"))
    //    {
    //        enObjetoDanino = false;
    //    }
    //}
   
   
    private void ActualizarHUD()
    {
       
        textoVida.SetText("Vida: " + vida);
        textoPuntos.SetText("Vida: " + puntos);
    }
    private void VerificarMuerte()
    {
        
        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {

        Destroy(gameObject);
        ReiniciarPartida();  
    }
    
    private void ReiniciarPartida()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




