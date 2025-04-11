// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class camera_sight : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

using UnityEngine;

public class BrickGazeSelector : MonoBehaviour
{
    public float rayDistance = 10f;
    private brick_sight_color currentTarget;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            brick_sight_color brick = hit.collider.GetComponent<brick_sight_color>();

            if (brick != null)
            {
                if (brick != currentTarget)
                {
                    if (currentTarget != null) currentTarget.Unhighlight();
                    currentTarget = brick;
                    currentTarget.Highlight();
                }
            }
            else
            {
                ClearCurrentTarget();
            }
        }
        else
        {
            ClearCurrentTarget();
        }
    }

    void ClearCurrentTarget()
    {
        if (currentTarget != null)
        {
            currentTarget.Unhighlight();
            currentTarget = null;
        }
    }
}
