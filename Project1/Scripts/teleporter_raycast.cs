// using UnityEngine;
// using UnityEngine.XR;
// using System.Collections.Generic;

// public class teleporter_raycast : MonoBehaviour
// {
//     public LayerMask groundLayer;
//     public Transform playerRoot; // XR Rig 或主相机的上层 GameObject
//     public float heightOffset = 1.0f; // 防止穿地

//     private InputDevice rightController;
//     private bool buttonPressed = false;
//     private Vector3? targetPoint = null;

//     void Start()
//     {
//         List<InputDevice> devices = new List<InputDevice>();
//         InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
   
//         if (devices.Count > 0)
//         {
//             rightController = devices[0];
//             Debug.Log("Right controller initialized: " + rightController.name);
//         }
//         else
//         {
//             Debug.LogError("No right-hand controller found!");
//         }
//     }

//     void Update()
//     {
//         //---------------------------
//         // List<InputDevice> devices = new List<InputDevice>();
//         // // InputDevice righthand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
//         // InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
//         // // Debug.Log("Right hand device: " + righthand.name);
//         // if (devices.Count > 0)
//         // {
//         //     rightController = devices[0];
//         //     Debug.Log("Right controller initialized: " + rightController.name);
//         // }
//         // else
//         // {
//         //     Debug.LogError("No right-hand controller found!");
//         // }
//         //-------------------------
//         Ray ray = new Ray(transform.position, transform.forward);
//         RaycastHit hit;

//         // 可视化射线
//         Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

//         if (Physics.Raycast(ray, out hit, 100, groundLayer))
//         {
//             targetPoint = hit.point;

//             // 检测按钮（使用 A 键，通常是 primary button）
//             if (rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
//             {
//                 if (isPressed && !buttonPressed)
//                 {
//                     buttonPressed = true;
//                     Debug.Log("Button Pressed!!");
//                     TeleportToPoint(hit.point);
//                 }
//                 else if (!isPressed)
//                 {
//                     buttonPressed = false;
//                 }
//                 Debug.Log(targetPoint);
//             }

//         }
//     }

//     void TeleportToPoint(Vector3 point)
//     {
//         if (playerRoot != null)
//         {
//             Vector3 offset = new Vector3(0, heightOffset, 0);
//             playerRoot.position = point + offset;
//             // 可选：调整方向
//             // playerRoot.forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
//         }
//     }
// }


using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class TeleportRaycaster : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform playerRoot; // XR Rig 或主相机的上层 GameObject
    public float heightOffset = 1.0f; // 防止穿地

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

        // 可视化射线
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

        if (Physics.Raycast(ray, out hit, 100, groundLayer))
        {
            targetPoint = hit.point;

            // 检测按钮（使用 A 键，通常是 primary button）
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
            Vector3 offset = new Vector3(0, heightOffset, 0);
            playerRoot.position = point + offset;
            // 可选：调整方向
            // playerRoot.forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        }
    }
}
