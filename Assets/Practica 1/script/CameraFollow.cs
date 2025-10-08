using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el seguimiento de la cámara a la bola.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    //Referencia al objetivo
    public Transform objetivo;
    // Offset o separacion entre la cámara y el objetivo
    //Retoma el componenete transform position x    y   z
    public Vector3 offset = new Vector3(0f, 3f, 6f);
    private bool seguir = false;


 void LateUpdate()
    {
        // Solo segior si esta activado y el objetivo esta correctamente referenciado
        if (seguir && objetivo != null)
        {
            // PISTA: Posicionar cámara con offset
            transform.position = objetivo.position + offset;
        }
    }
    // PISTA: Método para iniciar seguimiento
    public void IniciarSeguimiento()
    {
        seguir = true;
    }
    // PISTA: Método para detener seguimiento
    public void DetenerSeguimiento()
    {
        seguir=false;
    }
}