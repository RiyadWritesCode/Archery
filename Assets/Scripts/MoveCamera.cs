using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform playerMesh;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerMesh.transform.position;
    }
}
