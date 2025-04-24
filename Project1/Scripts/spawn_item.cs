using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class spawn_item : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    // Add these in the Inspector
    public XRBaseInteractor leftHandInteractor;
    public XRBaseInteractor rightHandInteractor;

    public void SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            Vector3 position = spawnPoint ? spawnPoint.position : Vector3.zero;
            Vector3 position_offset = new Vector3(0.0f, 1.0f, 1.0f);
            position += position_offset;

            GameObject spawnedObject = Instantiate(prefabToSpawn, position, Quaternion.identity);

            // Ensure a MeshCollider is added
            MeshCollider meshCollider = spawnedObject.GetComponent<MeshCollider>();
            if (meshCollider == null)
            {
                meshCollider = spawnedObject.AddComponent<MeshCollider>();
                meshCollider.convex = true;
            }

            // Ensure a Rigidbody is added
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = spawnedObject.AddComponent<Rigidbody>();
            }

            // Ensure XR Grab Interactable is added
            XRGrabInteractable grabInteractable = spawnedObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable == null)
            {
                grabInteractable = spawnedObject.AddComponent<XRGrabInteractable>();
                // grabInteractable.selectMode = XRBaseInteractable.SelectMode.Multiple;
                grabInteractable.selectMode = InteractableSelectMode.Multiple;
                grabInteractable.smoothPosition = true;
                grabInteractable.smoothRotation = true;
            }

            XRRayColorChange colorChanger = spawnedObject.AddComponent<XRRayColorChange>();

            TwoHandScaler scaler = spawnedObject.AddComponent<TwoHandScaler>();
            scaler.leftHand = leftHandInteractor;
            scaler.rightHand = rightHandInteractor;
        }
    }
}

public class XRRayColorChange : MonoBehaviour
{
    private XRBaseInteractable interactable;
    private Renderer objectRenderer;
    private Color originalColor;
    public Color activeColor = new Color(0.7f, 0.96f, 0.6f);

    private bool isHovered = false;
    private bool isSelected = false;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }

        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectExit);
    }

    private void UpdateColor()
    {
        if (objectRenderer == null) return;

        if (isHovered || isSelected)
        {
            objectRenderer.material.color = activeColor;
        }
        else
        {
            objectRenderer.material.color = originalColor;
        }
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        isHovered = true;
        UpdateColor();
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        isHovered = false;
        UpdateColor();
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        isSelected = true;
        UpdateColor();
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        isSelected = false;
        UpdateColor();
    }
}
