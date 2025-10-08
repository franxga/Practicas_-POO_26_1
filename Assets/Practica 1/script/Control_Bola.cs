using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
/// Controla el movimiento lateria y el lanzamiento de la bola.
/// Tambien se comunica con la cámara y el sistema de puntuacion.
/// </summary>
public class ControladorBola : MonoBehaviour
{
    // TODO: Fuerza con la que se lanza la bola
    public float fuerzaDeLanzamiento = 1000f;
    // TODO: Velocidad y límites para el apuntado
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2;
    public float limiteDerecho = 2;
    //TODO: Referencias Internas
    private Rigidbody rb;
    private bool haSidoLanzada = false;
    //TODO: Referencia a la camara y score
    public CameraFollow cameraFollow;
    public ScoreManager scoreManager;
    void Start()
    {
        // PISTA: Obtener el componente Rigidbody de esta bola
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!haSidoLanzada)
        {
            Apuntar();
            // PISTA: Si se presiona espacio, lanzar la bola
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LanzarBola();
            }
        }
    }
    void Apuntar()
    {
        // PISTA: Obtener el movimiento horizontal (-1 a 1)
        float inputHorizontal = Input.GetAxis("Horizontal");

        // PISTA: Mover la bola lateralmente

        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        // PISTA: Limitar el movimiento dentro de los bordes del carril
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }
    void LanzarBola()
    {
        haSidoLanzada = true;

        // ✅ EJEMPLO EXPLICADO: Comprobar si el Rigidbody existe antes de usarlo
        // Esta comprobación evita errores NullReferenceException.
        // Si olvidamos arrastrar el Rigidbody o el componente fue eliminado,
        // el sistema no debería intentar usarlo.
        if (rb != null)
        {
            rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);
        }
        else
        {
            Debug.LogWarning("El Rigidbody no está asignado en" + gameObject.name);
        }
        // PISTA: Iniciar seguimiento de la cámara (si existe)
        if (cameraFollow != null)
        {
            cameraFollow.IniciarSeguimiento();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // PISTA: Si colisiona con un pino
        if (collision.gameObject.CompareTag("Pin"))
        {
            // PISTA: Detener seguimiento de cámara (si no es null)
            if (cameraFollow != null)
            {
                cameraFollow.DetenerSeguimiento();
            }
            // Calcular puntaje tras un pequeño retraso
            if (scoreManager != null)
            {
                Invoke("CalcularPuntaje", 2f);
            }
        }
    }
    void CalcularPuntaje()
    {
        //Actualizar puntos
        scoreManager. CalcularPuntaje();
    }
} // Bienvenido al infierno