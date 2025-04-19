using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    Canvas Principal, Instructions;
    AudioSource audioSource;
    public AudioClip buttonSoundEffect;
    public int StarIndex;
    public float FadingVel;
    float fadeOutCrono=0.6f;
    Text fadingText;

    public void backToMainMenu()
    {
        Principal.enabled = true;
        Instructions.enabled = false;
        audioSource.PlayOneShot(buttonSoundEffect);
    }

    public void instructionsButton()
    {
        Principal.enabled = false;
        Instructions.enabled = true;
        audioSource.PlayOneShot(buttonSoundEffect);
    }

    public void GoToLvl(string nameOfLvl)
    {audioSource.PlayOneShot(buttonSoundEffect);
     SceneManager.LoadScene(nameOfLvl);}

    void fadeOutText()
    {
            fadeOutCrono -= Time.deltaTime;
            if (fadeOutCrono > 0.3f)
            {
            fadingText.enabled = true;
            }
            else if (fadeOutCrono < 0.3f && fadeOutCrono > 0)
            {
            fadingText.enabled = false;
            }
            else if (fadeOutCrono < 0)
            { fadeOutCrono = 0.6f; }
    }


    private void Awake()
    {
        Principal=GameObject.Find("PrincipalCanvas").GetComponent<Canvas>();
        Instructions=GameObject.Find("InstructionsCanvas").GetComponent<Canvas>();
        audioSource=GetComponent<AudioSource>();
        fadingText=GameObject.Find("Collab").GetComponent<Text>();
    }

    private void Update()
    {
        fadeOutText();
    }

}
