using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PigsUI : MonoBehaviour
{   int direction;
    public float speed;
    public float onCronoToChangeDirection;
    float cronoToChangeDirection;

    private void Awake()
    {direction=1;
    cronoToChangeDirection=onCronoToChangeDirection;}

    void Update()
    {   transform.rotation*=Quaternion.Euler(0,0,direction*Time.deltaTime*speed);
        cronoToChangeDirection -= Time.deltaTime;
        if(cronoToChangeDirection<=0)
        { direction = -direction; 
        cronoToChangeDirection=onCronoToChangeDirection;}
    }
}
