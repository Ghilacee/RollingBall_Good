using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTrigger : MonoBehaviour
{
    [SerializeField] GameObject camaraPlayer;  
    [SerializeField] GameObject camaraCenital;  

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            camaraPlayer.SetActive(false);  
            camaraCenital.SetActive(true); 
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            camaraPlayer.SetActive(true);   
            camaraCenital.SetActive(false);   
        }
    }
}
