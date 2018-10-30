using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPS : MonoBehaviour {
    //Time DEBUG
    public int width = 1080;
    public int height = 1920;

    public Text FrameRateText;

    float Tick;
    float HighestFPS;
    float LowestFPS=200;
    float AverageFPS;
    float LastFPS;
    float total;
    float currentFPS;
    void Awake()
    {
        Screen.SetResolution(width, height, true);
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(UpdateUpdateFrameRate(1));
        StartCoroutine(LowestFPSupdate(1));

    }

    // Update is called once per frame
    void Update () {

    }



    public IEnumerator UpdateUpdateFrameRate(float waitTime)
    {
        AverageFPS = HighestFPS  = (int)(1f / Time.deltaTime);
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Tick += 1* (int)waitTime;
             currentFPS = (int)(1f / Time.deltaTime);

            total += LastFPS;
            if (currentFPS > HighestFPS)
            {
                HighestFPS = currentFPS;
            }



            float DisplayAverage = total / Tick;



            string FCurrentFPS = (currentFPS).ToString() + "FPS";
            string FLowestFPS = LowestFPS.ToString() + "FPS";
            string FHighestFPS = HighestFPS.ToString() + "FPS";
            string FaverageFPS = DisplayAverage.ToString() + "FPS";
            string Ftime = Tick.ToString() + "SEC";
            FrameRateText.text = "Current: " + FCurrentFPS + "\n" + "Lowest: " + FLowestFPS + "\n" + "Heighest: " + FHighestFPS + "\n" + "AverageFPS: " + FaverageFPS + "\n " + "Time: " + Ftime;
            LastFPS = currentFPS;
        }
    }

    IEnumerator LowestFPSupdate(float waitTime) {
        yield return new WaitForSeconds(4);

        while (true)
        {
            if (currentFPS < LowestFPS)
            {
                LowestFPS = currentFPS;
            }

            yield return new WaitForSeconds(waitTime);

        }



    }
}
