using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{
    public AudioSource foodFX;

    void OnTriggerEnter(Collider other)
    {
        foodFX.Play();
        CollectableControl.pointsCount += 200;
        this.gameObject.SetActive(false);
    }
}
