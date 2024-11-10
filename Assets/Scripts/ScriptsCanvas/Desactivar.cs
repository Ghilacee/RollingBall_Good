using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivar : MonoBehaviour
{
   
    public GameObject canvasPerdiste;
    public void OcultarCanvas()
    {
       
        canvasPerdiste.SetActive(false);
    }
}
