// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class scale_item : MonoBehaviour
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
// using UnityEngine.XR.Interaction.Toolkit;
// using System.Collections.Generic;

// public class scale_item : MonoBehaviour
// {
//     public XRBaseInteractable interactable;

//     private List<IXRSelectInteractor> selectingInteractors = new List<IXRSelectInteractor>();
//     private float initialDistance;
//     private Vector3 initialScale;

//     void OnEnable()
//     {
//         interactable.selectEntered.AddListener(OnSelectEnter);
//         interactable.selectExited.AddListener(OnSelectExit);
//     }

//     void OnDisable()
//     {
//         interactable.selectEntered.RemoveListener(OnSelectEnter);
//         interactable.selectExited.RemoveListener(OnSelectExit);
//     }

//     private void OnSelectEnter(SelectEnterEventArgs args)
//     {
//         selectingInteractors.Add(args.interactorObject);
//         if (selectingInteractors.Count == 2)
//         {
//             initialDistance = Vector3.Distance(
//                 selectingInteractors[0].transform.position,
//                 selectingInteractors[1].transform.position);
//             initialScale = transform.localScale;
//         }
//     }

//     private void OnSelectExit(SelectExitEventArgs args)
//     {
//         selectingInteractors.Remove(args.interactorObject);
//     }

//     void Update()
//     {
//         if (selectingInteractors.Count == 2)
//         {
//             float currentDistance = Vector3.Distance(
//                 selectingInteractors[0].transform.position,
//                 selectingInteractors[1].transform.position);

//             float scaleRatio = currentDistance / initialDistance;
//             transform.localScale = initialScale * scaleRatio;
//         }
//     }
// }
//----------------------------------------------------------------
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class TwoHandScaler : MonoBehaviour
// {
//     public XRBaseInteractor leftHand;
//     public XRBaseInteractor rightHand;

//     private XRGrabInteractable grabInteractable;
//     private bool leftGrabbing = false;
//     private bool rightGrabbing = false;

//     private float initialDistance;
//     private Vector3 initialScale;

//     private Transform targetObject;

//     void Awake()
//     {
//         grabInteractable = GetComponent<XRGrabInteractable>();
        
//         // 注册事件
//         grabInteractable.selectEntered.AddListener(OnSelectEnter);
//         grabInteractable.selectExited.AddListener(OnSelectExit);
//     }

//     void OnDestroy()
//     {
//         // 注销事件（防止内存泄漏）
//         grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
//         grabInteractable.selectExited.RemoveListener(OnSelectExit);
//     }

//     void OnSelectEnter(SelectEnterEventArgs args)
//     {
//         if (args.interactorObject == leftHand)
//             leftGrabbing = true;
//         if (args.interactorObject == rightHand)
//             rightGrabbing = true;

//         if (leftGrabbing && rightGrabbing)
//         {
//             initialDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
//             initialScale = transform.localScale;
//         }
//     }

//     void OnSelectExit(SelectExitEventArgs args)
//     {
//         if (args.interactorObject == leftHand)
//             leftGrabbing = false;
//         if (args.interactorObject == rightHand)
//             rightGrabbing = false;
//     }

//     void Update()
//     {
//         RaycastHit hit;
//         bool isHit = Physics.Raycast(leftHand.transform.position, leftHand.transform.forward, out hit);

//         if (leftGrabbing && rightGrabbing)
//         {
//             targetObject = hit.transform;
//             Debug.Log("Scaling object with two hands.");
//             float currentDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
//             Debug.Log("Two hand distance: " + currentDistance);
//             float scaleFactor = currentDistance / initialDistance;
//             Debug.Log("scaleFactor: " + scaleFactor);
//             targetObject.localScale = initialScale * scaleFactor;
//             Debug.Log("Transform: " + transform.localScale);
//         }
//     }
// }
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class TwoHandScaler : MonoBehaviour
// {
//     public XRBaseInteractor leftHand;
//     public XRBaseInteractor rightHand;

//     private XRGrabInteractable grabInteractable;
//     private bool leftGrabbing = false;
//     private bool rightGrabbing = false;

//     private float initialDistance;
//     private Vector3 initialScale;

//     void Awake()
//     {
//         grabInteractable = GetComponent<XRGrabInteractable>();
        
//         // 注册事件
//         grabInteractable.selectEntered.AddListener(OnSelectEnter);
//         grabInteractable.selectExited.AddListener(OnSelectExit);
//     }

//     void OnDestroy()
//     {
//         // 注销事件（防止内存泄漏）
//         grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
//         grabInteractable.selectExited.RemoveListener(OnSelectExit);
//     }

//     void OnSelectEnter(SelectEnterEventArgs args)
//     {
//         if (args.interactorObject == leftHand)
//             leftGrabbing = true;
//         if (args.interactorObject == rightHand)
//             rightGrabbing = true;

//         if (leftGrabbing && rightGrabbing)
//         {
//             initialDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
//             initialScale = transform.localScale;
//         }
//     }

//     void OnSelectExit(SelectExitEventArgs args)
//     {
//         if (args.interactorObject == leftHand)
//             leftGrabbing = false;
//         if (args.interactorObject == rightHand)
//             rightGrabbing = false;
//     }

//     void Update()
//     {
//         if (leftGrabbing && rightGrabbing)
//         {
//             float currentDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
//             float scaleFactor = currentDistance / initialDistance;
//             transform.localScale = initialScale * scaleFactor;
//         }
//     }
// }
//-------------------------------------------------------------------
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// [RequireComponent(typeof(XRGrabInteractable))]
// public class TwoHandGrabScaler : MonoBehaviour
// {
//     private XRGrabInteractable grabInteractable;

//     private IXRSelectInteractor firstInteractor = null;
//     private IXRSelectInteractor secondInteractor = null;

//     private float initialDistance;
//     private Vector3 initialScale;

//     void Awake()
//     {
//         grabInteractable = GetComponent<XRGrabInteractable>();
//         grabInteractable.selectEntered.AddListener(OnGrab);
//         grabInteractable.selectExited.AddListener(OnRelease);
//     }

//     private void OnDestroy()
//     {
//         grabInteractable.selectEntered.RemoveListener(OnGrab);
//         grabInteractable.selectExited.RemoveListener(OnRelease);
//     }

//     private void OnGrab(SelectEnterEventArgs args)
//     {
//         if (firstInteractor == null)
//         {
//             firstInteractor = args.interactorObject;
//         }
//         else if (secondInteractor == null)
//         {
//             secondInteractor = args.interactorObject;

//             // Store initial values when second grab starts
//             initialDistance = GetInteractorsDistance();
//             initialScale = transform.localScale;
//         }
//     }

//     private void OnRelease(SelectExitEventArgs args)
//     {
//         if (args.interactorObject == secondInteractor)
//         {
//             secondInteractor = null;
//         }
//         else if (args.interactorObject == firstInteractor)
//         {
//             // Promote second to first if it exists
//             firstInteractor = secondInteractor;
//             secondInteractor = null;
//         }
//     }

//     void Update()
//     {
//         if (firstInteractor != null && secondInteractor != null)
//         {
//             float currentDistance = GetInteractorsDistance();
//             float scaleRatio = currentDistance / initialDistance;
//             this.transform.localScale = initialScale * scaleRatio;
//             // this.grabInteractable.m_TargetLocalScale = initialScale * scaleRatio;
//         }
//     }

//     private float GetInteractorsDistance()
//     {
//         return Vector3.Distance(firstInteractor.transform.position, secondInteractor.transform.position);
//     }
// }

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandScaler : MonoBehaviour
{
    public XRBaseInteractor leftHand;
    public XRBaseInteractor rightHand;

    private XRGrabInteractable grabInteractable;

    private bool leftGrabbing = false;
    private bool rightGrabbing = false;

    private float initialDistance;
    private Vector3 initialScale;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject as XRBaseInteractor;
        if (interactor == leftHand)
            leftGrabbing = true;
        else if (interactor == rightHand)
            rightGrabbing = true;

        if (leftGrabbing && rightGrabbing)
        {
            initialDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
            initialScale = transform.localScale;
        }
    }

    void OnRelease(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject as XRBaseInteractor;
        if (interactor == leftHand)
            leftGrabbing = false;
        else if (interactor == rightHand)
            rightGrabbing = false;
    }

    void Update()
    {
        if (leftGrabbing && rightGrabbing)
        {
            float currentDistance = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
            float scaleRatio = currentDistance / initialDistance;
            // transform.localScale = initialScale * scaleRatio;
            // transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime;
            grabInteractable.SetTargetLocalScale(initialScale * scaleRatio);
        }
    }
}



