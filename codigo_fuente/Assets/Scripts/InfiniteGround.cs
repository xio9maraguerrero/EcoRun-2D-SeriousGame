using UnityEngine;

public class InfiniteGround : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float groundLength = 20f; // Longitud estimada de tu bloque de suelo

    private void Update() {
        if (player == null) return;

        // Si el personaje se acerca al final del bloque actual, lo adelantamos para crear el bucle infinito
        if (player.position.x > transform.position.x + groundLength) {
            transform.position = new Vector3(transform.position.x + (groundLength * 2f), transform.position.y, transform.position.z);
        }
    }
}