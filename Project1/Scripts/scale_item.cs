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



