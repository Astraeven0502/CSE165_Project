using UnityEngine;

public class HeadGazeRaycaster : MonoBehaviour
{
    public float maxRayDistance = 10.0f;
    private Renderer currentRenderer;
    private Color originalColor;

    public Color gazeColor = Color.cyan;

    void Update()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRayDistance))
        {
            Renderer hitRenderer = hit.collider.GetComponent<Renderer>();

            if (hitRenderer != null)
            {
                if (currentRenderer != hitRenderer)
                {
                    ResetPreviousRendererColor();

                    currentRenderer = hitRenderer;
                    originalColor = currentRenderer.material.color;
                    currentRenderer.material.color = gazeColor;
                }
            }
        }
        else
        {
            ResetPreviousRendererColor();
        }
    }

    void ResetPreviousRendererColor()
    {
        if (currentRenderer != null)
        {
            currentRenderer.material.color = originalColor;
            currentRenderer = null;
        }
    }
}
