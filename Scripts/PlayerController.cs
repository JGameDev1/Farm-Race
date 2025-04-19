using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float actualSpeed;
    float onFadeOutCrono=0.4f;
    float fadeOutCrono;
    public bool fading;
    public bool jumping;
    public float onCronoJump;
    public float cronoJump;
    public float jumpForce;
    public GameObject body;
    int numberOfFades;
    int maxFades=7;
    public List<SpriteRenderer>spritesRenderers;

    private void Awake()
    {
        cronoJump=onCronoJump;
    }

    void movement()
    {
        transform.Translate(new Vector2(1,Input.GetAxisRaw("Vertical"))*actualSpeed*Time.deltaTime);
        if(fading){actualSpeed=speed/2;}
        else{actualSpeed=speed;}
        if(this.transform.position.y>=-1){transform.position=new Vector2(transform.position.x,-1);}
        else if(this.transform.position.y<=-4){transform.position=new Vector2(transform.position.x,-4);}
        if(Input.GetButton("Horizontal")||Input.GetButton("Fire1")||Input.GetButton("Fire2"))
        {actualSpeed+=0.5f;}
    }

    void fadingMoment()
    {
        if (fading)
        {
            fadeOutCrono-=Time.deltaTime;
            if(fadeOutCrono>0.2)
            {
                foreach (SpriteRenderer sp in spritesRenderers)
                {
                    sp.color = new Color(1, 1, 1, 0.2f);
                }
            }
            else if (fadeOutCrono < 0.2 && fadeOutCrono > 0)
            {
                foreach (SpriteRenderer sp in spritesRenderers)
                {
                    sp.color = new Color(1, 1, 1, 1f);
                }
            }
            else if (fadeOutCrono <= 0)
            {
                fadeOutCrono = onFadeOutCrono;
                numberOfFades += 1;
            }
            if (numberOfFades >= maxFades)
            {
                numberOfFades = 0;
                fading = false;
            }
        }
        else
        {
            fadeOutCrono = onFadeOutCrono;
            numberOfFades = 0;
            foreach (SpriteRenderer sp in spritesRenderers)
            {
                sp.color = new Color(1, 1, 1, 1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WinMark")
        {
            FindObjectOfType<UIManager>().win = true;
            FindObjectOfType<UIManager>().endCanvas.enabled = true;
            FindObjectOfType<UIManager>().onGameCanvas.enabled = false;
            GetComponent<AudioSource>().Play();
        }
    }

    void Update()
    {
        movement();
        fadingMoment();
    }
}
