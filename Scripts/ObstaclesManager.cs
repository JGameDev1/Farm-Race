using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{public List<GameObject>bombsPath;

    private void Awake()
    {
        bombsPath[Random.Range(0,bombsPath.Count)].SetActive(true);
    }
}
