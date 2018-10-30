using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    float x;
    float y;
    float z;

    public Transform lightTrans;
    public DealWithUDPMessage withUDPMessage;

    public static Mover instance;

   public Transform sphere;
 public   CreateRandomPos CreateRandomPos;
  public  float Scale;
    public float easeingValue;

    private float perviousX;
	// Use this for initialization
	void Start () {
        Screen.SetResolution(1080, 1920, true);
        if (instance == null) {
            instance = this;
        }
        y = this.transform.position.y;


	}
	
	// Update is called once per frame
	void Update () {
 
        if (CreateRandomPos.GetPosition() != Vector3.zero) {
            Vector3 tempPos = CreateRandomPos.GetPosition();

            SpherePos(tempPos * Scale);
            moving(tempPos);
        }


        // Vector3 tempListPos = CreateRandomPos.GeListtPosition();

        //SpherePos(tempListPos * Scale);
        //moving(tempListPos);

    }

    void SpherePos(Vector3 vector3pos) {
        Vector3 temp = new Vector3(vector3pos.x, vector3pos.y, sphere.transform.position.z);
        sphere.position = temp;
    }

    void moving(Vector3 vector3POS) {

        x = x + (vector3POS.x - x) * easeingValue;
        //   y += (vector3POS.y - y) * .125F;
        //        z += (vector3POS.z - z) * 0.033f;

        Vector3 target = new Vector3(x * Scale, y, this.transform.position.z);
        transform.position = target;


        float lightx = withUDPMessage.Maping(target.x, withUDPMessage.OutputMin, withUDPMessage.OutputMax, -140, 140, false);


        Vector3 lightPos = new Vector3(lightx, lightTrans.localPosition.y, lightTrans.localPosition.z);

        lightTrans.localPosition = lightPos;

        //perviousX = vector3POS.x;
    }


    public void setEasingValue(float value) {
        easeingValue = value;
    }
}
