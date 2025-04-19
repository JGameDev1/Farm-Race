using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{public float speed;
    private void Update()
    {
        transform.Translate(Vector2.right*Time.deltaTime*speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WinMark")
        {
            FindObjectOfType<UIManager>().win = false;
            FindObjectOfType<UIManager>().endCanvas.enabled = true;
            FindObjectOfType<UIManager>().onGameCanvas.enabled = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
