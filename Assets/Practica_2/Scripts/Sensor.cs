using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    public GameObject[] luces;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("arcade"))
        {
            // luz.SetActive(true); individual
            foreach (var luz in luces) {
                luz.SetActive(true); //grupo de objetos
            }
            Debug.Log("hecha una ficha");
        }

        if (other.CompareTag("item"))
        {
            score.CalcularPuntaje();
            other.gameObject.SetActive(false);
            Debug.Log("Obtiviste un pejeDolar");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("arcade"))
        {
            // luz.SetActive(false)
            foreach (var luz in luces) {
                luz.SetActive(false);
            }
            Debug.Log("Game Over: regresa cuando quieras");
        }
    }


} // Puertas del infierno

