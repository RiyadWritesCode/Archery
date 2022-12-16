using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimator : MonoBehaviour
{
    Animator animator;
    public bool readyToShoot = false;
    ArrowShooter ArrowShooter;

    void Start()
    {
        animator = GetComponent<Animator>();
        ArrowShooter = FindObjectOfType<ArrowShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ArrowShooter.shootInput.WasPressedThisFrame() && ArrowShooter.readyToDraw)
        {
            ArrowShooter.bowArrow.GetComponent<MeshRenderer>().enabled = true;
            animator.SetBool("isDrawing", true);
            Debug.Log("Pressed!");
            readyToShoot = true;
        }

        else if (ArrowShooter.shootInput.WasReleasedThisFrame() && readyToShoot)
        {
            animator.SetBool("isDrawing", false);
            ArrowShooter.percentageDraw = animator.GetCurrentAnimatorStateInfo(0).normalizedTime / 1f;
            ArrowShooter.ShootArrow();
            ArrowShooter.bowArrow.GetComponent<MeshRenderer>().enabled = false;
            readyToShoot = false;
        }

    }
}
