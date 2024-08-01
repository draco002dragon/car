//que esta mal este codigo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class span : MonoBehaviour
{
  
    public GameObject[] enemies; // Lista de enemigos a spawnear
    public Transform spawnPoint;  // Punto donde aparecerá el enemigo

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        // Selecciona un enemigo al azar de la lista
        int randomIndex = Random.Range(0, enemies.Length);
        GameObject enemy = Instantiate(enemies[randomIndex], spawnPoint.position, spawnPoint.rotation);
        // Aquí puedes agregar lógica adicional si es necesario, como configurar el enemigo
    }
}