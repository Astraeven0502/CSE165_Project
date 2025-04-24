using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class TeleportRaycaster : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform playerRoot;
    //public float heightOffset = 0.1f;

    private InputDevice rightController;
    private bool buttonPressed = false;
    private Vector3? targetPoint = null;

    void Start()
    {
        // List<InputDevice> devices = new List<InputDevice>();
        // InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        // if (devices.Count > 0)
        //     rightController = devices[0];
    }

    void Update()
    {
        //----------------------------
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        if (devices.Count > 0)
            rightController = devices[0];
        //----------------------------
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

        if (Physics.Raycast(ray, out hit, 100, groundLayer))
        {
            targetPoint = hit.point;

            // check A button, usually primary button
            if (rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
            {
                if (isPressed && !buttonPressed)
                {
                    buttonPressed = true;
                    TeleportToPoint(hit.point);
                }
                else if (!isPressed)
                {
                    buttonPressed = false;
                }
            }
        }
    }

    void TeleportToPoint(Vector3 point)
    {
        if (playerRoot != null)
        {
            //Vector3 offset = new Vector3(0, heightOffset, 0);
            //playerRoot.position = point + offset;
            playerRoot.position = point;
        }
    }
}
