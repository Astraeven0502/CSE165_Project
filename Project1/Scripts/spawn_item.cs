using System.Collections;
using System.Collections.Generic;
// using UnityEngine;

// public class spawn_item : MonoBehaviour
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

public class spawn_item : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    public void SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            Vector3 position = spawnPoint ? spawnPoint.position : Vector3.zero;
            Vector3 position_offset = new Vector3(0.0f, 0.0f, 0.75f);
            position = position + position_offset;
            Instantiate(prefabToSpawn, position, Quaternion.identity);
        }
    }
}
