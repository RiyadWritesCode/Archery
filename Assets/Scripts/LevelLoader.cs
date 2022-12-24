using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator curtainAnimator;
    public float transitionTime = 1.02f;

    void Start()
    {

    }

    void LoadNextLevel()
    {
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public IEnumerator LoadSceneByIndex(int sceneIndex)
    {
        curtainAnimator.SetTrigger("transitionToNextScene");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator LoadSceneByName(string sceneName)
    {
        curtainAnimator.SetTrigger("transitionToNextScene");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu" && SceneManager.GetActiveScene().name != "Settings Menu")
        {
            GameObject MusicPlayer = FindObjectOfType<PlayMusic>().gameObject;
            Destroy(MusicPlayer);
        }
    }

    
}
