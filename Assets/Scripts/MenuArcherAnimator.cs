using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuArcherAnimator : MonoBehaviour
{

    public GameObject headContainer;
    Vector3 mousePos;
    Vector3 actualMousePos;

    public Animator menuArcherAnimator;
    void Start()
    {
        menuArcherAnimator.SetTrigger("waveSequence");
    }

    void Update()
    {
        if (menuArcherAnimator.GetCurrentAnimatorStateInfo(0).IsName("Final Idle"))
        {
            mousePos = Input.mousePosition;
            actualMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 5));

            headContainer.transform.LookAt(actualMousePos);
        }  
    }
}
