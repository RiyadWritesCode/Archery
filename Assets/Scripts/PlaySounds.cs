using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySounds : MonoBehaviour
{
    ArrowShooter ArrowShooter;

    public AudioSource bowDraw;
    public AudioSource arrowShoot;
    public AudioSource jump;
    public AudioSource run;
    //public AudioSource targetDing;

    public AudioMixerGroup soundMixerGroup;

    public int whichBowDraw;

    void Start()
    {
        ArrowShooter = FindObjectOfType<ArrowShooter>();

        bowDraw.outputAudioMixerGroup = soundMixerGroup;
        arrowShoot.outputAudioMixerGroup = soundMixerGroup;
        jump.outputAudioMixerGroup = soundMixerGroup;
        run.outputAudioMixerGroup = soundMixerGroup;
        //targetDing.outputAudioMixerGroup = soundMixerGroup;
    }

    void Update()
    {
    }

    public void playTargetDing(float pitch)
    {
        ArrowShooter.launchedArrows[ArrowShooter.arrowNumber - 1].GetComponent<AudioSource>().outputAudioMixerGroup = soundMixerGroup;
        ArrowShooter.launchedArrows[ArrowShooter.arrowNumber - 1].GetComponent<AudioSource>().pitch = 0.95f + pitch / 12;
        ArrowShooter.launchedArrows[ArrowShooter.arrowNumber - 1].GetComponent<AudioSource>().Play();
    }

    public void playBowDraw()
    {
        bowDraw.Play();

    }

    public void stopBowDraw()
    {
        bowDraw.Stop();

    }

    public void playArrowShoot(float percentDraw)
    {
        if (percentDraw > 0.3f)
        {
            arrowShoot.volume = percentDraw / 2;
            arrowShoot.pitch = Random.Range(0.95f, 1.05f);
            arrowShoot.Play();
        }
        
    }

    public void playJump()
    {
        jump.Play();
    }

    public void playRun()
    {
        run.Play();
    }

    public void stopRun()
    {
        run.Stop();
    }

    

    

}
