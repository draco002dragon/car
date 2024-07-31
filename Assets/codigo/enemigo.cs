using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public float speed = 5f; // Velocidad del NPC
    public Transform[] waypoints; // Puntos de control para que el NPC siga
    private int currentWaypointIndex = 0; // Índice del punto de control actual

    private void Update()
    {
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        // Verifica si hay puntos de control asignados
        if (waypoints.Length == 0) return;

        // Determina la dirección hacia el siguiente punto de control
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        // Comprueba si el NPC ha llegado al punto de control
        if (direction.magnitude < 0.1f)
        {
            currentWaypointIndex++;

            // Si se han alcanzado todos los puntos de control, reinicia
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Reiniciar al primer punto
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Aquí podrías añadir lógica para que el NPC reaccione con el jugador o con otros objetos
        if (other.CompareTag("Player"))
        {
            Debug.Log("El NPC ha alcanzado al jugador!");
        }
    }
}
