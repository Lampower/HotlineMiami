using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Entities;
    public GameObject World;
    private void Start()
    {
        if (Instance == null) Instance = this;
    }
}
