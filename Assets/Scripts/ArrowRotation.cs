using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    Rigidbody rb;
    MeshCollider ms;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ms = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        realisticArrowRotation();
    }

    void realisticArrowRotation()
    {
        if(rb.velocity != new Vector3(0,0,0))
        {
            transform.up = -rb.velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "arrow")
        {
            gameObject.transform.parent = collision.transform;
            ms.enabled = false;
            rb.isKinematic = true;
        }

        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
