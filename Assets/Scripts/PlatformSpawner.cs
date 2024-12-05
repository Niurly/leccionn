using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab de la plataforma.
    public GameObject obstaclePrefab; // Prefab del obstáculo.
    public int numberOfPlatforms = 10; // Número de plataformas a generar.
    public float platformSpacing = 5f; // Espacio entre plataformas.
    public float minHeight = -1f; // Altura mínima de la plataforma.
    public float maxHeight = 3f; // Altura máxima de la plataforma.

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        float lastPlatformX = player.position.x; // Empezamos desde la posición del jugador.

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            // Crear la plataforma con una posición aleatoria en el eje Y.
            float randomHeight = Random.Range(minHeight, maxHeight);
            Vector2 platformPosition = new Vector2(lastPlatformX + platformSpacing, randomHeight);

            // Generar la plataforma.
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            // Añadir un obstáculo sobre la plataforma.
            Instantiate(obstaclePrefab, platformPosition + new Vector2(0, 1), Quaternion.identity);

            // Actualizar la posición para la siguiente plataforma.
            lastPlatformX = platformPosition.x;
        }
    }
}
