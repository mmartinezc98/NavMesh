using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    public Transform routeFather;
    public int index = 0;

    private Vector3 _destination;

    //aleatoria delimitada
    Vector3 min, max;



    void Start()
    {
        //vamos al primer punto de la ruta
        _destination = routeFather.GetChild(index).position; //cogemos el primer punto 
        GetComponent<NavMeshAgent>().SetDestination(_destination); //hacemos que vaya al destino
    }


    void Update()
    {

        #region PUNTOS DE CONTROL DE RUTA
        //comprobamos si ha llegado a distancia del punto de ruta (en este caso 2.5), si es asi cogemos el siguiente puntos
        if (Vector3.Distance(transform.position, _destination) < 2.5f)
        {

            //cogemos el siguiente aleatoriamente (punto de ruta aleatorios)
            //index=Random.Range(0, routeFather.childCount);


            //cogemos el siguiente
            index++;


            //si el indice es mayor al numero de puntos de ruta, hacemos que vuelva a empezar
            if (index > routeFather.childCount)
            {
                index = 0;
            }

            //cambiamos el destino
            _destination = routeFather.GetChild(index).position;
            GetComponent<NavMeshAgent>().SetDestination(_destination); //hacemos que vaya al destino
        }
        #endregion

        #region MOVIMIENTO ALEATORIA DELIMITADO (ENTRE DOS PUNTOS)

        /* if (Vector3.Distance(transform.position, _destination) < 2.5f)
         {
             _destination= RandomDestination();
             GetComponent<NavMeshAgent>().SetDestination(_destination); //hacemos que vaya al destino
         }*/
        #endregion


        #region AMOVIMIENTO ALEATORIO EN EL NAVEMESH

        //cogemos puntos aleatorios alrededor del enemigo (en una esfera)
        if (Vector3.Distance(transform.position, _destination) < 2.5f)
        {
            Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * 50; //punto aleatorio en una esfera de rango 50
            NavMeshHit hit;
            NavMesh.SamplePosition(randomPoint, out hit, 50, 1); //pasmos esa direccion(punto) al Navmesh --> 1 significa que es Walkable
            _destination=hit.position;

            GetComponent<NavMeshAgent>().SetDestination(_destination); //hacemos que vaya al destino
        }




        #endregion

    }

    private Vector3 RandomDestination()
    {
        return new Vector3(UnityEngine.Random.Range(min.x, max.x), 0, UnityEngine.Random.Range(min.z, max.z));
    }

}
