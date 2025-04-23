//// using System.Collections;
//// using System.Collections.Generic;
//// // using UnityEngine;

//// // public class spawn_item : MonoBehaviour
//// // {
//// //     // Start is called before the first frame update
//// //     void Start()
//// //     {

//// //     }

//// //     // Update is called once per frame
//// //     void Update()
//// //     {

//// //     }
//// // }

//// using UnityEngine;

//// public class spawn_item : MonoBehaviour
//// {
////     public GameObject prefabToSpawn;
////     public Transform spawnPoint;

////     public void SpawnObject()
////     {
////         if (prefabToSpawn != null)
////         {
////             Vector3 position = spawnPoint ? spawnPoint.position : Vector3.zero;
////             Vector3 position_offset = new Vector3(0.0f, 0.0f, 0.75f);
////             position = position + position_offset;
////             Instantiate(prefabToSpawn, position, Quaternion.identity);
////         }
////     }
//// }

//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR;
//using UnityEngine.XR.Interaction.Toolkit;

//public class spawn_item : MonoBehaviour
//{
//    public GameObject prefabToSpawn;

//    public Transform spawnPoint;

//     // Add these in the Inspector
//    public XRBaseInteractor leftHandInteractor;
//    public XRBaseInteractor rightHandInteractor;

//    private GameObject spawnedObject;
//    private InputDevice rightController;
//    Rigidbody rb;
//    //private Renderer objectRenderer;

//    //private Color placementColor = new Color(1f, 1f, 1f);
//    //private Color originalColor;

//    public void SpawnObject()
//    {
//        //// Get the object
//        //objectRenderer = GetComponent<Renderer>();
//        //// Store original color
//        //if (objectRenderer != null)
//        //{
//        //    originalColor = objectRenderer.material.color;
//        //}


//        if (prefabToSpawn != null)
//        {
//            Vector3 position = spawnPoint ? spawnPoint.position : Vector3.zero;
//            Vector3 position_offset = new Vector3(0.0f, 0.0f, 0.75f);
//            position += position_offset;

//            spawnedObject = Instantiate(prefabToSpawn, position, Quaternion.identity);

//            // Ensure a MeshCollider is added
//            MeshCollider meshCollider = spawnedObject.GetComponent<MeshCollider>();
//            if (meshCollider == null)
//            {
//                meshCollider = spawnedObject.AddComponent<MeshCollider>();
//                meshCollider.convex = true;
//            }

//            // Ensure a Rigidbody is added
//            rb = spawnedObject.GetComponent<Rigidbody>();
//            if (rb == null)
//            {
//                rb = spawnedObject.AddComponent<Rigidbody>();
//            }

//            // Placement Mode
//            EnablePlacementMode();
//        }
//    }

//    public void Update() {
//        //----------------------------
//        List<InputDevice> devices = new List<InputDevice>();
//        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
//        if (devices.Count > 0)
//            rightController = devices[0];
//        //----------------------------

//        if (rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
//        {
//            if (isPressed)
//            {
//                DisablePlacementMode();
//            }
//        }
//    }

//    private void EnablePlacementMode()
//    {
//        rb.useGravity = false;
//        rb.isKinematic = true;
//        //objectRenderer.material.color = placementColor;
//    }
//    private void DisablePlacementMode()
//    {
//        rb.useGravity = true;
//        rb.isKinematic = false;
//        //objectRenderer.material.color = originalColor;

//        // Ensure XR Grab Interactable is added
//        XRGrabInteractable grabInteractable = spawnedObject.GetComponent<XRGrabInteractable>();
//        if (grabInteractable == null)
//        {
//            grabInteractable = spawnedObject.AddComponent<XRGrabInteractable>();
//            // grabInteractable.selectMode = XRBaseInteractable.SelectMode.Multiple;
//            grabInteractable.selectMode = InteractableSelectMode.Multiple;
//            grabInteractable.smoothPosition = true;
//            grabInteractable.smoothRotation = true;
//        }

//        XRRayColorChange colorChanger = spawnedObject.AddComponent<XRRayColorChange>();

//        TwoHandScaler scaler = spawnedObject.AddComponent<TwoHandScaler>();
//        scaler.leftHand = leftHandInteractor;
//        scaler.rightHand = rightHandInteractor;
//    }
//}

//// public class XRGrabColorChange : MonoBehaviour
//// {
////     private XRGrabInteractable grabInteractable;
////     private Renderer objectRenderer;
////     private Color originalColor;
////     public Color selectColor = Color.yellow;

////     void Awake()
////     {
////         grabInteractable = GetComponent<XRGrabInteractable>();
////         objectRenderer = GetComponent<Renderer>();
////         if (objectRenderer != null)
////         {
////             originalColor = objectRenderer.material.color;
////         }

////         grabInteractable.hoverEntered.AddListener(ChangeColorOnGrab);
////         grabInteractable.hoverExited.AddListener(RevertColorOnRelease);
////         grabInteractable.selectEntered.AddListener(ChangeColorOnGrab_s);
////         grabInteractable.selectExited.AddListener(RevertColorOnRelease_s);
////     }

////     private void ChangeColorOnGrab(HoverEnterEventArgs args)
////     {
////         if (objectRenderer != null)
////         {
////             objectRenderer.material.color = selectColor;
////         }
////     }

////     private void RevertColorOnRelease(HoverExitEventArgs args)
////     {
////         if (objectRenderer != null)
////         {
////             objectRenderer.material.color = originalColor;
////         }
////     }

////     private void ChangeColorOnGrab_s(SelectEnterEventArgs args)
////     {
////         if (objectRenderer != null)
////         {
////             objectRenderer.material.color = selectColor;
////         }
////     }

////     private void RevertColorOnRelease_s(SelectExitEventArgs args)
////     {
////         if (objectRenderer != null)
////         {
////             objectRenderer.material.color = originalColor;
////         }
////     }
//// }

//public class XRRayColorChange : MonoBehaviour
//{
//    private XRBaseInteractable interactable;
//    private Renderer objectRenderer;
//    private Color originalColor;
//    public Color activeColor = new Color(0.7f, 0.96f, 0.6f);

//    private bool isHovered = false;
//    private bool isSelected = false;

//    void Awake()
//    {
//        interactable = GetComponent<XRBaseInteractable>();
//        objectRenderer = GetComponent<Renderer>();
//        if (objectRenderer != null)
//        {
//            originalColor = objectRenderer.material.color;
//        }

//        interactable.hoverEntered.AddListener(OnHoverEnter);
//        interactable.hoverExited.AddListener(OnHoverExit);
//        interactable.selectEntered.AddListener(OnSelectEnter);
//        interactable.selectExited.AddListener(OnSelectExit);
//    }

//    private void UpdateColor()
//    {
//        if (objectRenderer == null) return;

//        if (isHovered || isSelected)
//        {
//            objectRenderer.material.color = activeColor;
//        }
//        else
//        {
//            objectRenderer.material.color = originalColor;
//        }
//    }

//    private void OnHoverEnter(HoverEnterEventArgs args)
//    {
//        isHovered = true;
//        UpdateColor();
//    }

//    private void OnHoverExit(HoverExitEventArgs args)
//    {
//        isHovered = false;
//        UpdateColor();
//    }

//    private void OnSelectEnter(SelectEnterEventArgs args)
//    {
//        isSelected = true;
//        UpdateColor();
//    }

//    private void OnSelectExit(SelectExitEventArgs args)
//    {
//        isSelected = false;
//        UpdateColor();
//    }
//}



// using System.Collections;
// using System.Collections.Generic;
// // using UnityEngine;

// // public class spawn_item : MonoBehaviour
// // {
// //     // Start is called before the first frame update
// //     void Start()
// //     {

// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {

// //     }
// // }

// using UnityEngine;

// public class spawn_item : MonoBehaviour
// {
//     public GameObject prefabToSpawn;
//     public Transform spawnPoint;

//     public void SpawnObject()
//     {
//         if (prefabToSpawn != null)
//         {
//             Vector3 position = spawnPoint ? spawnPoint.position : Vector3.zero;
//             Vector3 position_offset = new Vector3(0.0f, 0.0f, 0.75f);
//             position = position + position_offset;
//             Instantiate(prefabToSpawn, position, Quaternion.identity);
//         }
//     }
// }

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
            Vector3 position_offset = new Vector3(0.0f, 0.0f, 0.75f);
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

// public class XRGrabColorChange : MonoBehaviour
// {
//     private XRGrabInteractable grabInteractable;
//     private Renderer objectRenderer;
//     private Color originalColor;
//     public Color selectColor = Color.yellow;

//     void Awake()
//     {
//         grabInteractable = GetComponent<XRGrabInteractable>();
//         objectRenderer = GetComponent<Renderer>();
//         if (objectRenderer != null)
//         {
//             originalColor = objectRenderer.material.color;
//         }

//         grabInteractable.hoverEntered.AddListener(ChangeColorOnGrab);
//         grabInteractable.hoverExited.AddListener(RevertColorOnRelease);
//         grabInteractable.selectEntered.AddListener(ChangeColorOnGrab_s);
//         grabInteractable.selectExited.AddListener(RevertColorOnRelease_s);
//     }

//     private void ChangeColorOnGrab(HoverEnterEventArgs args)
//     {
//         if (objectRenderer != null)
//         {
//             objectRenderer.material.color = selectColor;
//         }
//     }

//     private void RevertColorOnRelease(HoverExitEventArgs args)
//     {
//         if (objectRenderer != null)
//         {
//             objectRenderer.material.color = originalColor;
//         }
//     }

//     private void ChangeColorOnGrab_s(SelectEnterEventArgs args)
//     {
//         if (objectRenderer != null)
//         {
//             objectRenderer.material.color = selectColor;
//         }
//     }

//     private void RevertColorOnRelease_s(SelectExitEventArgs args)
//     {
//         if (objectRenderer != null)
//         {
//             objectRenderer.material.color = originalColor;
//         }
//     }
// }

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
