using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamEne : MonoBehaviour
{
    public GameObject[] enemies; // Lista de enemigos a spawnear
    public Transform spawnPoint;  // Punto donde aparecerá el enemigo
    public float speed = 5f; // Velocidad del NPC
    public Transform[] waypoints; // Puntos de control para que el NPC siga

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        // Selecciona un enemigo al azar de la lista
        int randomIndex = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[randomIndex], spawnPoint.position, spawnPoint.rotation);
        // Añade el comportamiento para que el enemigo siga los waypoints
        NPC npcComponent = enemy.AddComponent<NPC>(); // Añadimos el componente NPC al enemigo spawneado
        npcComponent.speed = speed; // Asignar la velocidad
        npcComponent.waypoints = waypoints; // Asignar los puntos de control
    }
}

public class NPC : MonoBehaviour
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
