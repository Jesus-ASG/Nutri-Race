using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOM : MonoBehaviour
{
    public static GOM instance;

    public GameObject[] lifes;
    public GameObject player;
    public GameObject levelControl;
    public GameObject characterModel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
