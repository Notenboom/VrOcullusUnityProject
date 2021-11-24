using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager s_gameManager;
    private AudioManager s_AudioManager;

    [SerializeField] private Button buttontest;

    AsyncOperation asyncLoad;

    void Start()
    {
        s_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        s_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        asyncLoad = SceneManager.LoadSceneAsync("LoadingScene");
        asyncLoad.allowSceneActivation = false;
    }

    void Update()
    {
        
    }

    public void ButtonTest()
    {
        s_gameManager.setinMainMenuBool(false);
        s_AudioManager.Stop("introspeech");

        //SceneManager.LoadScene("LoadingScene");
        asyncLoad.allowSceneActivation = true;
        while (!asyncLoad.isDone)
        {
            Invoke("ButtonTest", 0.5f);
            return;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LoadingScene"));
    }

}
