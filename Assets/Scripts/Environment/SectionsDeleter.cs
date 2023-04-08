using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionsDeleter : MonoBehaviour
{
    public GameObject player;
    public float deleteDistance = 120f;

    private float zPos;

    void Start()
    {
        zPos = transform.position.z;
        StartCoroutine(DeleteObjects());
    }

    
    IEnumerator DeleteObjects()
    {
        string name = this.gameObject.name;
        if (name.EndsWith("(Clone)"))
            while (true)
            {
                if (player.transform.position.z > zPos)
                {
                    float zDiff = player.transform.position.z - zPos;
                    if (zDiff > deleteDistance)
                        Destroy(gameObject);
                }
                yield return new WaitForSeconds(1f);
            }
    }
}
