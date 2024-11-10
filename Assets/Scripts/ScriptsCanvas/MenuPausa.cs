using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa; // Panel de pausa
    [SerializeField] private Button botonPausa;
    [SerializeField] private Button botonContinuar; // Bot�n de pausa en la UI
    private bool juegoPausado = false;

    void Start()
    {
        // Aseg�rate de que el panel de pausa est� oculto al principio
        panelPausa.SetActive(false);

        // Asocia el evento del bot�n con el m�todo PausarJuego
        botonPausa.onClick.AddListener(TogglePausa);
        botonContinuar.onClick.AddListener(ReanudarJuego);
    }

    // Esta funci�n alterna entre pausar o reanudar el juego
    private void TogglePausa()
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

    // Pausa el juego
    public void PausarJuego()
    {
        Time.timeScale = 0f;  // Pausa el juego
        juegoPausado = true;
        panelPausa.SetActive(true); // Muestra el panel de pausa
    }

    // Reanuda el juego
    public void ReanudarJuego()
    {
        Time.timeScale = 1f;  // Reanuda el juego
        juegoPausado = false;
        panelPausa.SetActive(false); // Oculta el panel de pausa
    }

}
