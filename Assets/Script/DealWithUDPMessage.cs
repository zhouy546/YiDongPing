//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithUDPMessage : MonoBehaviour {
    public FPS fPS;

    public CreateRandomPos createRandomPos;

    //public FocusByUDP focusByUDPClass;//根据UDP数据处理相机移动的类
    private string dataTest;

    float temp;

    public float inputMin, inputMax;

    public float Offset {

        get {
            return 300;
        }
    }

    private float outputMin;
    public float OutputMin {
        get {
            return outputMin + Offset;
                }
        set
        {
            outputMin = value;
        }
    }


    public Transform Locator;
    public float OutputMax {
        get {

            return Locator.position.x- Offset;
        }
        set {
            Locator.position = new Vector3(value, Locator.position.y, Locator.position.z);
                }
    }

    public MainUICTR mainUICTR;
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {
        dataTest = _data;
        //Debug.Log( "doing");

        //  focusByUDPClass.CameraFocusON(_data);
    }
    private void FixedUpdate()
    {
        GetMessage(dataTest);
         //Debug.Log("数据：" + dataTest);  
    }


    void GetMessage(string data)
    {
        if (data != null) {
            if (temp != float.Parse(data)) {
                temp = float.Parse(data);

                Debug.Log("inputMin" + inputMin + "inputMax"+ inputMax);
                Debug.Log("OutputMin" + OutputMin + "OutputMax" + OutputMax);
                mainUICTR.Check(temp);

                float Xvalue = Maping(temp, inputMin, inputMax, OutputMin, OutputMax, false);
              
            

                Debug.Log(Xvalue);
                Vector3 POS = new Vector3(Xvalue, Camera.main.transform.position.y, Camera.main.transform.position.z);


                createRandomPos.TargetPos.Enqueue(POS);
                //createRandomPos.ListPos.Add(POS);
            }

        }

        //Debug.Log("null");

        return;
    }

    public float Maping(float value, float inputMin, float inputMax, float outputMin, float outputMax, bool clamp)
    {
        float outVal = ((value - inputMin) / (inputMax - inputMin) * (outputMax - outputMin) + outputMin);

        if (clamp)
        {
            if (outputMax < outputMin)
            {
                if (outVal < outputMax) outVal = outputMax;
                else if (outVal > outputMin) outVal = outputMin;
            }
            else
            {
                if (outVal > outputMax) outVal = outputMax;
                else if (outVal < outputMin) outVal = outputMin;
            }
        }


        return outVal;
    }


}
