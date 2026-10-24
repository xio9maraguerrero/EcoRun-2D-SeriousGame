using System.Collections.Generic;
using UnityEngine;

public enum WasteType { Blanca, Verde, Negra, Roja }

public class WasteItem : MonoBehaviour
{
    public WasteType type;
    public static readonly List<WasteItem> Active = new List<WasteItem>();

    private void OnEnable()  { Active.Add(this); }
    private void OnDisable() { Active.Remove(this); }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (GameManager.Instance != null) GameManager.Instance.LoseLife();
        Destroy(gameObject);
    }
}