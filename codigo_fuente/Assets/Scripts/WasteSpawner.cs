using UnityEngine;

public class WasteSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] wastePrefabs;
    [SerializeField] private float spawnAhead = 16f;
    [SerializeField] private float minInterval = 2f;
    [SerializeField] private float maxInterval = 4f;
    [SerializeField] private float groundY = -5.07f;   // altura del suelo

    private float timer;
    private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        timer = Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        if (playerRb.linearVelocity.x < 0.1f || wastePrefabs.Length == 0) return;

        timer -= Time.deltaTime;
        if (timer > 0f) return;
        timer = Random.Range(minInterval, maxInterval);

        GameObject prefab = wastePrefabs[Random.Range(0, wastePrefabs.Length)];
        Vector3 pos = new Vector3(player.position.x + spawnAhead, groundY, 0f);
        Destroy(Instantiate(prefab, pos, Quaternion.identity), 15f);
    }
}