using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour 
{
    [Header("Configuración de Runner")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float speedMultiplier = 0.05f; // Aumento gradual de velocidad con el tiempo

    [Header("Detección de Suelo")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Header("Sistema de Vidas")]
    [SerializeField] private int maxLives = 3;
    private int currentLives;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isRunning = false; // El juego inicia en reposo (Idle)

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (animator == null) Debug.LogError("Falta el componente Animator en Player");
        currentLives = maxLives;
    }

    private void Update() {
        
        Keyboard keyboard = Keyboard.current;

        // Detección de suelo
        if (groundCheck != null) {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        // Iniciar el juego al presionar la tecla D o Flecha Derecha por primera vez
        if (!isRunning && keyboard != null) {
            if (keyboard.dKey.wasPressedThisFrame || keyboard.rightArrowKey.wasPressedThisFrame) {
                isRunning = true;
            }
        }

        // Aumento progresivo de velocidad con el tiempo estilo dinosaurio de Google
        if (isRunning) {
            moveSpeed += speedMultiplier * Time.deltaTime;
        }

        // Salto con Barra Espaciadora, W o Flecha Arriba
        bool jumpPressed = keyboard != null && (keyboard.spaceKey.wasPressedThisFrame || keyboard.wKey.wasPressedThisFrame || keyboard.upArrowKey.wasPressedThisFrame);

        if (jumpPressed && isGrounded && isRunning) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Control estricto de parámetros en el Animator para forzar la animación de correr
        if (animator != null) {
            float currentAnimSpeed = isRunning ? moveSpeed : 0f;
            animator.SetFloat("Speed", currentAnimSpeed);
            animator.SetBool("IsGrounded", isGrounded);
        }
    }

    private void FixedUpdate() {
        if (isRunning) {
            // Movimiento automático constante hacia la derecha con aceleración
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        } else {
            // Completamente quieto en Idle antes de iniciar
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }

    public void LoseLife() {
        currentLives--;
        Debug.Log("¡Cuidado! Vidas restantes: " + currentLives);
        if (currentLives <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("¡Juego Terminado por pérdida de vidas!");
    }

    private void OnDrawGizmosSelected() {
        if (groundCheck != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}