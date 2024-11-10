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

    public GameObject perderPanel;

    

    [SerializeField] private int puntos = 0;
    [SerializeField] private int vida = 5;
    [SerializeField] TMP_Text textoVida;
    [SerializeField] TMP_Text textoPuntos;
    [SerializeField] private GameObject cartelVictoria;

    //OBJETO DAÑINO
    private bool enObjetoDanino = false; 
    private float tiempoSiguienteDano;


    void Start()
    {
       perderPanel.SetActive(false);
        cartelVictoria.SetActive(false);

        rb = GetComponent<Rigidbody>();
        ActualizarHUD();

       
    }

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
            tiempoSiguienteDano = Time.time + 3f;
            ActualizarHUD();

           
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
            ActualizarHUD();
        }
        if (collision.gameObject.CompareTag("PinchosKiller"))
        {
            vida -= 3;
            ActualizarHUD();
        }
        if (collision.gameObject.CompareTag("sierraKiller"))
        {
            vida -= 5;
            ActualizarHUD();


            Morir();
        }
        if (collision.gameObject.CompareTag("Sierrecillas"))
        {
            vida -= 1;
            ActualizarHUD();
        }
        if (collision.gameObject.CompareTag("Acha"))
        {
            vida -= 3;
            ActualizarHUD();
        }

        if (collision.gameObject.CompareTag("Barrera"))
        {
            vida -= 1;
            ActualizarHUD();
        }

        if (collision.gameObject.CompareTag("Tablones"))
        {
            enObjetoDanino = true;
            tiempoSiguienteDano = Time.time + 3f;
            ActualizarHUD();
        }
    }
  
    private void OnCollisionExit(Collision collision)
    {
        // Desactivar daño periódico al salir del objeto dañino
        if (collision.gameObject.CompareTag("Tablones"))
        {
            enObjetoDanino = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Moneda"))
        {
            puntos += 1;
            Destroy(other.gameObject);
            ActualizarHUD();
        }
        if (other.gameObject.CompareTag("Victoria"))
        {
            
            ActivarVictoria();
        }

    }


   
   
    private void ActualizarHUD()
    {
       
        textoVida.SetText("Vida: " + vida);
        textoPuntos.SetText("Puntos: " + puntos);
        VerificarMuerte();
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

        gameObject.SetActive(false);
        perderPanel.SetActive(true);
        Time.timeScale = 0f;
       
    }
    private void ActivarVictoria()
    {
        cartelVictoria.SetActive(true); // Muestra el cartel de victoria
        Time.timeScale = 0f; // Pausa el juego
    }

    public void ReiniciarPartida()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}




