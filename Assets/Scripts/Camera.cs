using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // Referencia al jugador.
    public float smoothSpeed = 0.125f; // Velocidad de suavizado.
    public Vector3 offset; // Desplazamiento de la cámara respecto al jugador.

    void LateUpdate()
    {
        if (player != null)
        {
            // Posición deseada de la cámara.
            Vector3 desiredPosition = player.position + offset;
            // Interpolación para un movimiento suave.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
