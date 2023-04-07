using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenMenu : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject fadeOut;
    
    public void resetLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void backToMainMenu()
    {
        StartCoroutine(backToMenuAnim());
    }

    IEnumerator backToMenuAnim()
    {
        endScreen.SetActive(false);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
