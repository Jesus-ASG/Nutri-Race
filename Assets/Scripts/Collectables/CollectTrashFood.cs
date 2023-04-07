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
        //Renderer r = this.gameObject.GetComponent<Renderer>();
        //if (r != null)
        //    r.enabled = false;
        

        if (CollectableControl.lifeCount <= 0)
        {
            
            
            //StartCoroutine(showGameOverAnimation());

            GOM.instance.levelControl.GetComponent<EndRunSequence>().enabled = true;

            this.gameObject.SetActive(false);
        }

        if (CollectableControl.lifeCount >= 0)
        {
            int diff = GOM.instance.lifes.Length - CollectableControl.lifeCount;
            GOM.instance.lifes[diff - 1].gameObject.SetActive(false);

            this.gameObject.SetActive(false);
        }

    }

    IEnumerator showGameOverAnimation()
    {

        Animator animator = GOM.instance.characterModel.GetComponent<Animator>();
        animator.CrossFade("Defeat", 1f);

        yield return new WaitForSeconds(2f);
        animator.CrossFade("Neutral Idle", 1f);

        //this.gameObject.SetActive(false);

    }

}
