using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject[] hideElements;

    void Start()
    {
        for (int i = 0; i < hideElements.Length; i++)
        {
            hideElements[i].SetActive(false);
        }
        GOM.instance.player.GetComponent<PlayerMove>().enabled = false;
        GOM.instance.levelControl.GetComponent<GenerateLevel>().enabled = false;
        GOM.instance.levelControl.GetComponent<LevelDistance>().enabled = false;

        StartCoroutine(endSequence());
    }

    IEnumerator endSequence()
    {
        Animator animator = GOM.instance.characterModel.GetComponent<Animator>();
        animator.CrossFade("Defeat", 1f);
        endScreen.SetActive(true);

        yield return new WaitForSeconds(2f);
        animator.CrossFade("Neutral Idle", 1f);

    }

}
