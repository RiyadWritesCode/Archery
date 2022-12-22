using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimator : MonoBehaviour
{
    Animator bowAnimator;
    public Animator playerAnimator;
    public bool readyToShoot = false;
    ArrowShooter ArrowShooter;
    PlaySounds PlaySounds;

    void Start()
    {
        bowAnimator = GetComponent<Animator>();
        ArrowShooter = FindObjectOfType<ArrowShooter>();
        PlaySounds = FindObjectOfType<PlaySounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ArrowShooter.shootInput.WasPressedThisFrame() && ArrowShooter.readyToDraw)
        {
            ArrowShooter.bowArrow.GetComponent<MeshRenderer>().enabled = true;
            bowAnimator.SetBool("isDrawing", true);
            readyToShoot = true;
            PlaySounds.playBowDraw();
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAiming"))
            {
                playerAnimator.SetBool("aiming", true);
            }

        }

        else if (ArrowShooter.shootInput.WasReleasedThisFrame() && readyToShoot)
        {
            bowAnimator.SetBool("isDrawing", false);
            ArrowShooter.percentageDraw = bowAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime / 1f;
            ArrowShooter.ShootArrow();
            ArrowShooter.bowArrow.GetComponent<MeshRenderer>().enabled = false;
            readyToShoot = false;
            PlaySounds.stopBowDraw();
            PlaySounds.playArrowShoot(ArrowShooter.percentageDraw);
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAiming"))
            {
                playerAnimator.SetBool("aiming", false);
            }
        }

    }
}
