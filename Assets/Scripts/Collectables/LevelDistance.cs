using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDistance : MonoBehaviour
{
    public TextMeshProUGUI disDisplay;
    public TextMeshProUGUI disEndDisplay;
    public static int disRun = 0;
    public bool addingDis = false;
    public float disDelay = 0.35f;

    void Start()
    {
        disRun = 0;
    }

    void Update()
    {
        if (!addingDis)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<TextMeshProUGUI>().text = disRun + "Kcal";
        disEndDisplay.GetComponent<TextMeshProUGUI>().text = disRun + "Kcal";
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}
