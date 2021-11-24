using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private AudioManager s_AudioManager;

    [SerializeField] private bool inMainMenu = true;
    [SerializeField] private bool audiobool = true;

    

    // Start is called before the first frame update
    void Start()
    {
        
        #region DO NOT DESTROY ON LOAD
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        #endregion   
        s_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        //Invoke("BackgroundAudio", 20f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (audiobool)
        {
            s_AudioManager.Play("introspeech");
            audiobool = false;
        }
    }

    public bool getinMainMenuBool()
    {
        return inMainMenu;
    }
    public void setinMainMenuBool(bool value)
    {
        inMainMenu = value;
    }

    public void BackgroundAudio()
    {
        s_AudioManager.Play("background");
    }

}
