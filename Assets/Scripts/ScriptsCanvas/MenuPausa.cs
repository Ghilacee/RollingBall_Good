using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa; 
    private bool juegoPausado = false;

    void Start()
    {
       
        panelPausa.SetActive(false);
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

   
    public void PausarJuego()
    {
        panelPausa.SetActive(true);    
        Time.timeScale = 0f;           
        juegoPausado = true;
    }

   
    public void ReanudarJuego()
    {
        panelPausa.SetActive(false);    
        Time.timeScale = 1f;            
        juegoPausado = false;
    }

}
