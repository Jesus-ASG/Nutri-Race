using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrashFood : MonoBehaviour
{
    public AudioSource foodFX;
    

    void OnTriggerEnter(Collider other)
    {
        foodFX.Play();
        CollectableControl.lifeCount -= 1;
        if (CollectableControl.lifeCount <= 0)
        {
            GOM.instance.levelControl.GetComponent<EndRunSequence>().enabled = true;
        }

        if (CollectableControl.lifeCount >= 0)
        {
            int diff = GOM.instance.lifes.Length - CollectableControl.lifeCount;
            GOM.instance.lifes[diff - 1].gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);

    }


}
