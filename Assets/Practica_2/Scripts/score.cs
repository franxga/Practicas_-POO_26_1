using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    // TODO: Texto UI
    public TextMeshProUGUI textoPuntaje;
    // TODO: Variables internas
    private int puntajeActual = 0;
    
    void Start()
    {
        textoPuntaje.text = "Puntos: "+ puntajeActual;
      
    }
    public void CalcularPuntaje()
    {
        int puntaje = 0;

        puntaje++;

        puntajeActual = puntaje;
        // PISTA: Actualizar texto del puntaje (validar si textoPuntaje != null)
        if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + puntajeActual;
    }
}