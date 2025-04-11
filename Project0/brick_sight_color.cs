// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class brick_sight_color : MonoBehaviour
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

public class brick_sight_color : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void Highlight()
    {
        rend.material.color = highlightColor;
    }

    public void Unhighlight()
    {
        rend.material.color = originalColor;
    }
}
