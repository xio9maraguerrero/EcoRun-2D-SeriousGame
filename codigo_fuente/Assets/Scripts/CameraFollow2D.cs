using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Objetivo a Seguir")]
    [SerializeField] private Transform target;

    [Header("Posición del personaje en pantalla")]
    [Tooltip("Más alto = el personaje queda más a la izquierda")]
    [SerializeField] private float offsetX = 5f;
    [SerializeField] private float offsetZ = -10f;

    private void LateUpdate()
    {
        if (target == null) return;

        // Sigue en X sin suavizado, así el personaje siempre queda en el mismo lugar de la pantalla
        transform.position = new Vector3(target.position.x + offsetX, transform.position.y, offsetZ);
    }
}