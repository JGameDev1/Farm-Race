using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text endTxt;
    public Canvas onGameCanvas;
    public Canvas endCanvas;
    public bool win;
    float fadeOutCrono=0.6f;
    Text fadingText;
    Image Button;

    private void Awake()
    {endTxt=GameObject.Find("EndTxt").GetComponent<Text>();
    onGameCanvas=GameObject.Find("OnGameCanvas").GetComponent<Canvas>();
    endCanvas=GameObject.Find("EndGameCanvas").GetComponent<Canvas>();
    fadingText=GameObject.Find("fadingTxt").GetComponent<Text>();
    Button=GameObject.Find("ButtonImg").GetComponent<Image>();    }
    
    private void Start()
    {onGameCanvas.enabled=true;
    endCanvas.enabled=false;}

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

    void ColoredButton()
    {
        fadeOutCrono -= Time.deltaTime;
        if (fadeOutCrono > 0.3f)
        {
            Button.color = new Color(1f, 1f, 1f, 1);
        }
        else if (fadeOutCrono < 0.3f && fadeOutCrono > 0)
        {
            Button.color = new Color(0.7f, 0.7f, 0.7f, 1);
        }
        else if (fadeOutCrono < 0)
        { fadeOutCrono = 0.6f; }
    }

    private void Update()
    {
    if(win)
    {endTxt.text="Oink Oink, well done new King!";}
    else
    {endTxt.text="It´s a shame, oink oink muajaja";}
    
    if(endCanvas.enabled)
    {FindObjectOfType<PlayerController>().speed=0;
     FindObjectOfType<EnemyBehaviour>().speed=0;}
    
    fadeOutText();
    ColoredButton();}

    public void goToLvl(string nameOfLvl)
    {SceneManager.LoadScene(nameOfLvl);}
}
