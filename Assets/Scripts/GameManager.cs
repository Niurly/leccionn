using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para recargar la escena.

public class GameManager : MonoBehaviour
{
    public void PlayerDied()
    {
        // Mostrar mensaje de Game Over o reiniciar la escena.
        Debug.Log("Game Over! El jugador ha muerto.");

        // Puedes mostrar un menú de Game Over o reiniciar la escena:
        RestartGame();
    }

    void RestartGame()
    {
        // Recargar la escena actual para reiniciar el juego.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

