using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullseye"))
        {
            float bullseyeLength = collision.gameObject.GetComponent<MeshFilter>().mesh.bounds.extents.x;
            float ringWidth = bullseyeLength / 4.5f;

            Vector3 contactPoint = collision.GetContact(0).point;
            Vector3 bullseyeCenter = collision.gameObject.transform.position;

            float contactDistanceX = Mathf.Abs(bullseyeCenter.x - contactPoint.x);
            float contactDistanceY = Mathf.Abs(bullseyeCenter.y - contactPoint.y);
            float ringNumber = 0;

            if (contactDistanceX < ringWidth / 2 && contactDistanceY < ringWidth / 2)
            {
                ringNumber = 1;
                Debug.Log("You have hit the YELLOW ring! - 5 Points");
            }
            else if (contactDistanceX < ringWidth * 1.5 && contactDistanceY < ringWidth * 1.5)
            {
                ringNumber = 2;
                Debug.Log("You have hit the RED ring! - 4 Points");
            }
            else if (contactDistanceX < ringWidth * 2.5 && contactDistanceY < ringWidth * 2.5)
            {
                ringNumber = 3;
                Debug.Log("You have hit the BLUE ring! - 3 Points");
            }
            else if (contactDistanceX < ringWidth * 3.5 && contactDistanceY < ringWidth * 3.5)
            {
                ringNumber = 4;
                Debug.Log("You have hit the BLACK ring! - 2 Points");
            }
            else if (contactDistanceX < ringWidth * 4.5 && contactDistanceY < ringWidth * 4.5)
            {
                ringNumber = 5;
                Debug.Log("You have hit the WHITE ring! - 1 Point");
            }


        }
    }
}
