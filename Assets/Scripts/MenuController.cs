using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    LevelLoader LevelLoader;

    void Start()
    {
        LevelLoader = FindObjectOfType<LevelLoader>();
    }

    void Update()
    {
        
    }

    public void PlayTraining()
    {
        StartCoroutine(LevelLoader.LoadSceneByName("Training Arena"));
    }

    public void PlaySettings()
    {
        StartCoroutine(LevelLoader.LoadSceneByName("Settings Menu"));
    }

}
