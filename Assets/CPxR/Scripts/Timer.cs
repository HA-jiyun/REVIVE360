using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;
    public GameObject objectToActive;
    public GameObject objectToActive2;

    public float time = 10f;
    private float countdown;

    void Start()
    {
        countdown = time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Floor(countdown) == 0) {
            if (objectToActive != null)
            {
                objectToActive.SetActive(true);
            }
            if (objectToActive2 != null)
            {
                objectToActive2.SetActive(true);
            }
            gameObject.SetActive(false);
        }
        else
        {
            countdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(countdown).ToString();
        }
    }
}
