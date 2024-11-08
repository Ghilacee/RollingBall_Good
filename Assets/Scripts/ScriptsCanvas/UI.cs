using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject canvasInicio; // Arrastra aquí tu Canvas de inicio desde el inspector

    public void OcultarCanvas()
    {
        canvasInicio.SetActive(false); // Oculta el Canvas
    }
}
