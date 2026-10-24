using UnityEngine;

public class DecorationLooper : MonoBehaviour
{
    [SerializeField] private Transform[] segments;
    [SerializeField] private float segmentWidth = 0f; // 0 = ancho de la cámara

    private Camera mainCam;
    private float width;
    private float[] centerOffset;

    private void Start()
    {
        mainCam = Camera.main;
        float camWidth = 2f * mainCam.orthographicSize * mainCam.aspect;
        width = segmentWidth > 0f ? segmentWidth : camWidth;

        // Guarda dónde está el centro real del contenido respecto al pivote de cada copia
        centerOffset = new float[segments.Length];
        for (int i = 0; i < segments.Length; i++)
            centerOffset[i] = MeasureCenterX(segments[i]) - segments[i].position.x;

        // Coloca las copias una al lado de la otra, usando el centro del contenido
        float c0 = segments[0].position.x + centerOffset[0];
        for (int i = 1; i < segments.Length; i++)
        {
            float wantedCenter = c0 + i * width;
            float currentCenter = segments[i].position.x + centerOffset[i];
            segments[i].position += new Vector3(wantedCenter - currentCenter, 0f, 0f);
        }

        Debug.Log("Looper -> ancho usado: " + width + " | ancho cámara: " + camWidth +
                  " | desfase centro seg0: " + centerOffset[0]);
    }

    private void LateUpdate()
    {
        float camX = mainCam.transform.position.x;
        float period = width * segments.Length;

        for (int i = 0; i < segments.Length; i++)
        {
            float center = segments[i].position.x + centerOffset[i];
            // Si quedó muy atrás de la cámara, salta al final de la fila
            if (center < camX - period / 2f)
                segments[i].position += new Vector3(period, 0f, 0f);
        }
    }

    private float MeasureCenterX(Transform t)
    {
        Renderer[] rs = t.GetComponentsInChildren<Renderer>();
        if (rs.Length == 0) return t.position.x;
        Bounds b = rs[0].bounds;
        foreach (Renderer r in rs) b.Encapsulate(r.bounds);
        return b.center.x;
    }
}