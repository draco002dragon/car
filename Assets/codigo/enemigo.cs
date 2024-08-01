using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public float speed = 5f; 
    public Transform[] waypoints; 
    private int currentWaypointIndex = 0;
    public GameObject[] enemies; // Lista de enemigos a spawnear
    public Transform spawnPoint;  // Punto donde aparecerá el enemigo

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
       
        int randomIndex = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[randomIndex], spawnPoint.position, spawnPoint.rotation);
        // Aquí puedes agregar lógica adicional si es necesario, como configurar el enemigo


          if (waypoints.Length == 0) return;

       
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

       
        if (direction.magnitude < 0.1f)
        {
            currentWaypointIndex++;

            
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; 
            }
        }
       

    }

    private void Update()
   {
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
       
        if (waypoints.Length == 0) return;

       
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

       
        if (direction.magnitude < 0.1f)
        {
            currentWaypointIndex++;

            
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("El NPC ha alcanzado al jugador!");
        }
    }
}
