using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public int ringNumber = 0;
    PointDisplay PointDisplay;

    PlaySounds PlaySounds;

    void Start()
    {
        PointDisplay = FindObjectOfType<PointDisplay>();
        PlaySounds = FindObjectOfType<PlaySounds>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullseye"))
        {
            float bullseyeLength = collision.gameObject.GetComponent<MeshFilter>().mesh.bounds.extents.x;
            float ringWidth = bullseyeLength / 4.5f;

            Vector3 contactPoint = collision.GetContact(0).point;
            Vector3 bullseyeCenter = collision.gameObject.transform.position;

            float contactDistanceX = Mathf.Abs(bullseyeCenter.x - contactPoint.x);
            float contactDistanceY = Mathf.Abs(bullseyeCenter.y - contactPoint.y);

            if (contactDistanceX < ringWidth / 2 && contactDistanceY < ringWidth / 2)
            {
                ringNumber = 1;
            }
            else if (contactDistanceX < ringWidth * 1.5 && contactDistanceY < ringWidth * 1.5)
            {
                ringNumber = 2;
            }
            else if (contactDistanceX < ringWidth * 2.5 && contactDistanceY < ringWidth * 2.5)
            {
                ringNumber = 3;
            }
            else if (contactDistanceX < ringWidth * 3.5 && contactDistanceY < ringWidth * 3.5)
            {
                ringNumber = 4;
            }
            else if (contactDistanceX < ringWidth * 4.5 && contactDistanceY < ringWidth * 4.5)
            {
                ringNumber = 5;
            }

            PointDisplay.DisplayPoints(ringNumber);
            PlaySounds.playTargetDing(PointDisplay.pointNumber);
        }
    }
}
