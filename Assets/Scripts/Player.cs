using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float fuerzaMovimiento = 1f;
    //[SerializeField] float direccion = 20f;
    //[SerializeField] Vector3 movimiento;
    [SerializeField] private float distanciaRaycast;
    private float h, v;
    Rigidbody rb; 

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
                rb.AddForce(Vector3.up * 8, ForceMode.Impulse);
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
            Destroy(gameObject);
        }
    }

    
  
}




