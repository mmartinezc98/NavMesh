using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaObstaculo : MonoBehaviour
{
    public float amplitud = 5f; // Distancia del movimiento
    public float velocidad = 2f;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento de vaivén matemático simple
        float nuevoZ = posicionInicial.z + Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = new Vector3(transform.position.x, transform.position.y, nuevoZ);
    }
}
