using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealToGauge : MonoBehaviour
{
    public GameObject[] objectToActive;
    private int objectCount = 0;

    private float timer = 0f;
    private float waitingTime = 0.4f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            objectToActive[objectCount].SetActive(true);
            objectCount++;
            timer = 0f;
        }
    }

}
