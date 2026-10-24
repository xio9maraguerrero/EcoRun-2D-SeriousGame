using UnityEngine;
using UnityEngine.InputSystem;

public class Bin : MonoBehaviour
{
    public WasteType binType;
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        if (col == null) col = gameObject.AddComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse == null || !mouse.leftButton.wasPressedThisFrame) return;
        if (GameManager.Instance == null) return;

        Vector2 world = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
        if (col.OverlapPoint(world)) GameManager.Instance.Deposit(binType);
    }
}