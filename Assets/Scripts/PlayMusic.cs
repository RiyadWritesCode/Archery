using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    public AudioSource menuMusic;
    public AudioMixerGroup musicMixerGroup;

    void Start()
    {
        menuMusic.outputAudioMixerGroup = musicMixerGroup;
    }

    void Update()
    {
        playMenuMusic();
    }

    private void Awake()
    {
        int num = FindObjectsOfType<PlayMusic>().Length;
        if (num > 1)
        {
            Destroy(gameObject);
        }
        
        else if (SceneManager.GetActiveScene().name == "Main Menu" || SceneManager.GetActiveScene().name == "Settings Menu")
        {
            DontDestroyOnLoad(gameObject);
        }

        

    }

    public void playMenuMusic()
    {
        if (!menuMusic.isPlaying)
        {
            menuMusic.Play();

        }
    }
}
