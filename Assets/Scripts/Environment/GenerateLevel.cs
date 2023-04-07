using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject player;
    public float generateDistance = 400f;

    public GameObject[] section;
    public GameObject[] healthy;
    public GameObject[] unhealthy;

    public int probability = 20;

    public int zPos = 80;
    public bool creatingSection = false;
    public int secNum;

    void Start()
    {
        StartCoroutine(generateSection());
    }


    IEnumerator generateSection()
    {
        while (true)
        {
            float zDiff = zPos - Mathf.Abs(player.transform.position.z);

            if (zDiff <= generateDistance)
            {
                secNum = Random.Range(0, section.Length - 1);
                Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
                GenerateFood();
                zPos += 80;
            }
            
            yield return new WaitForSeconds(1);
        }
    }

    void GenerateFood()
    {
        
        for (float i=1f; i<=80; i=i+2.5f)
        {
            for (int j=-1; j <= 1; j++)
            {
                int r = Random.Range(0, 100);
                if (probability >= r)
                {
                    int r2 = Random.Range(0, 2);
                    if (r2 == 0) // instantiate healthy food
                    {
                        int randomFood = Random.Range(0, healthy.Length);
                        Instantiate(healthy[randomFood], new Vector3(j * 1.5f, 1.5f, zPos - 40f + i), Quaternion.identity);
                    }
                    else
                    {
                        int randomFood = Random.Range(0, unhealthy.Length);
                        Instantiate(unhealthy[randomFood], new Vector3(j * 1.5f, 1.5f, zPos - 40f + i), Quaternion.identity);
                    }
                    
                }
                
            }
        }

    }

}
