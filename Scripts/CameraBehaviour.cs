using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    GameObject target;
    public float offSet;

    private void Awake()
    {target=GameObject.FindObjectOfType<PlayerController>().gameObject;}
    // Update is called once per frame
    void Update()
    {this.transform.position=new Vector3(target.transform.position.x+offSet,this.transform.position.y,this.transform.position.z);}
}
