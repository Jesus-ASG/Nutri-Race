using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableControl : MonoBehaviour
{
    public static int pointsCount = 0;
    public static int lifeCount = 4;  // min life = 1

    public TextMeshProUGUI pointsCountDisplay;
    public TextMeshProUGUI pointsEndDisplay;

    void Start()
    {
        pointsCount = 0;
        lifeCount = 4;    
    }
    
    void Update()
    {
        pointsCountDisplay.GetComponent<TextMeshProUGUI>().text = pointsCount + "pts";
        pointsEndDisplay.GetComponent<TextMeshProUGUI>().text = pointsCount + "pts";
    }
}
