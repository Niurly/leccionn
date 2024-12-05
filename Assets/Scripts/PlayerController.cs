using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador.
    public float jumpForce = 10f; // Fuerza del salto.
    private Rigidbody2D rb; // Referencia al Rigidbody2D.
    private bool isGrounded = true; // Verifica si el jugador está en el suelo.
    public GameManager gameManager; // Referencia al GameManager para manejar la muerte.

    void Start()
    {
        // Obtener el componente Rigidbody2D.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento hacia la derecha.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        // Saltar al presionar la barra espaciadora.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Desactiva el estado de "en el suelo".
        }
    }

    // Detectar si el jugador toca el suelo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f) // Asegurarse de que es una superficie plana.
        {
            isGrounded = true; // Vuelve a estar en el suelo.
        }

        // Si el jugador colisiona con un obstáculo, lo matamos.
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.PlayerDied(); // Llamar a la función de muerte en el GameManager.
        }
    }
}
