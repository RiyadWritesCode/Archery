using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBow : MonoBehaviour
{
    public Transform bow;
    PlayerController PlayerController;

    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        bow.position = new Vector3(bow.position.x, PlayerController.playerMesh.transform.position.y, bow.position.z);
    }
}
