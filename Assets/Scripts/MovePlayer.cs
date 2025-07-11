using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MovePlayer : MonoBehaviour
{
    public Transform playerMesh;
    public float playerHeight;

    void Update()
    {
        // Makes player move with its mesh
        transform.position = new Vector3(playerMesh.transform.position.x, playerHeight + playerMesh.transform.position.y, playerMesh.transform.position.z);
    }
}
