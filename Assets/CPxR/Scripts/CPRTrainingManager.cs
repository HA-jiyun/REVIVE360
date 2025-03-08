using UnityEngine;
using System.IO.Ports;
using System.Collections;
using TMPro;
using UnityEngine.Windows;

public class CPRTrainingManager : MonoBehaviour
{
    private SerialPort serialPort;
    private string compressionExpired;

    private bool isTrainingActive;
    private float trainingTimer;
    private float trainingDuration = 15f;

    public GameObject[] objectToActive;
    public GameObject timerActive;
    public static int compressionCount = 0;
    public TextMeshProUGUI compressionTxt;

    private void Start()
    {
        InitializeSerialPort();
    }

    private void InitializeSerialPort()
    {
        serialPort = new SerialPort("COM3", 115200);
        try
        {
            serialPort.Open();
            serialPort.ReadTimeout = 1000;
            isTrainingActive = true;
            compressionCount = 0;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error opening serial port: {e.Message}");
        }
    }

    private void Update()
    {
        if (isTrainingActive && (timerActive.activeSelf == true)) // 측정중이면 read port
        {
            string str = serialPort.ReadLine();
            inputDetection(str);
            compressionExpired = str;
            UpdateTraining();
        }

    }
    
    private void inputDetection(string input)
    {
        if (compressionCount < 30 && (int.Parse(compressionExpired) - int.Parse(input) == 1)) //  1->0으로 바뀌는 순간으로 압력 감지
        {
            objectToActive[compressionCount].SetActive(true);
            compressionCount++;
        }
    }

    private void UpdateTraining()
    {
        trainingTimer += Time.deltaTime;

        if (trainingTimer > trainingDuration)
        {
            compressionTxt.text = compressionCount.ToString();
            isTrainingActive = false;
        }
    }

    private void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}