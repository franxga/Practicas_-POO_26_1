using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el seguimiento de la cámara a la bola.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 offset = new Vector3(0f, 3f, 6f);
    private bool seguir = false;


 void LateUpdate()
    {
        if (seguir && objetivo != null)
        {
            transform.position = objetivo.position + offset;
        }
    }
    public void IniciarSeguimiento()
    {
        seguir = true;
    }
    public void DetenerSeguimiento()
    {
        seguir=false;
    }
}