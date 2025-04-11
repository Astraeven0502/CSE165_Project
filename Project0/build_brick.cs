using System.Collections;
using System.Collections.Generic;
// using UnityEngine;

// // public class build_brick : MonoBehaviour
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

// public class build_brick : MonoBehaviour
// {
//     public GameObject brickPrefab;

//     [Header("Wall Dimensions")]
//     public int rows = 10;
//     public int bricksPerRow = 30;
//     public float radius = 2f;
//     public float verticalGap = 0.01f;

//     [Header("Brick Dimensions")]
//     public float brickWidth = 0.3f;
//     public float brickHeight = 0.15f;

//     void Start()
//     {
//         GenerateWall();
//     }

//     void GenerateWall()
//     {
//         float angleStep = 360f / bricksPerRow;

//         for (int row = 0; row < rows; row++)
//         {
//             float y = row * (brickHeight + verticalGap);
//             float rowOffset = (row % 2 == 0) ? 0f : angleStep / 2f;

//             for (int i = 0; i < bricksPerRow; i++)
//             {
//                 float angleDeg = i * angleStep + rowOffset;
//                 float angleRad = angleDeg * Mathf.Deg2Rad;

//                 float x = Mathf.Cos(angleRad) * radius;
//                 float z = Mathf.Sin(angleRad) * radius;

//                 Vector3 position = new Vector3(x, y, z);
//                 Quaternion rotation = Quaternion.LookRotation(new Vector3(x, 0, z));

//                 GameObject brick = Instantiate(brickPrefab, position, rotation, transform);
//                 brick.transform.localScale = new Vector3(brickWidth, brickHeight, 0.15f);
//             }
//         }
//     }
// }

using UnityEngine;

public class build_brick : MonoBehaviour
{
    public GameObject brickPrefab;
    public PhysicMaterial inelasticMaterial;  // 🆕 Reference to assign from Inspector


    [Header("Wall Dimensions")]
    public int rows = 20;
    public int bricksPerRow = 60;
    public float radius = 2f;
    public float verticalGap = 0.005f;
    public Vector3 centerPosition = Vector3.zero;

    [Header("Brick Settings")]
    public float brickHeight = 0.1f;
    public float brickDepth = 0.15f;
    public float widthPaddingFactor = 0.95f;

    void Start()
    {
        GenerateWall();
    }

    void GenerateWall()
    {
        float angleStep = 360f / bricksPerRow;
        float arcLength = 2 * Mathf.PI * radius * (angleStep / 360f);
        float brickWidth = arcLength * widthPaddingFactor;

        for (int row = 0; row < rows; row++)
        {
            float y = row * (brickHeight + verticalGap);
            float rowOffsetAngle = (row % 2 == 0) ? 0f : angleStep / 2f;

            for (int i = 0; i < bricksPerRow; i++)
            {
                float angleDeg = i * angleStep + rowOffsetAngle;
                float angleRad = angleDeg * Mathf.Deg2Rad;

                float x = Mathf.Cos(angleRad) * radius;
                float z = Mathf.Sin(angleRad) * radius;

                Vector3 localDirection = new Vector3(x, 0, z).normalized;
                Vector3 position = new Vector3(x, y, z) + centerPosition;
                Quaternion rotation = Quaternion.LookRotation(localDirection);
                // Debug.Log("123: " + position);

                GameObject brick = Instantiate(brickPrefab, position, rotation, transform);
                brick.transform.localScale = new Vector3(brickWidth, brickHeight, brickDepth);

                Collider col = brick.GetComponent<Collider>();
                if (col != null && inelasticMaterial != null)
                {
                    col.material = inelasticMaterial;
                }
                
                if(row == 0){
                    brick.GetComponent<Rigidbody>().mass = 0f;
                    brick.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}
