using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomPos : MonoBehaviour {
    
    public Queue<Vector3> TargetPos = new Queue<Vector3>();

    public List<Vector3> ListPos = new List<Vector3>();
    Vector3 CurrentPosition;
    float min;
    float max
    {
        get { return min +4f; }
    }


	// Use this for initialization
	void Start () {
        ListPos.Add(Vector3.zero);
        //StartCoroutine(RandomPos(min, max));
      //  StartCoroutine(RandomListPos(min, max));
    }

    // Update is called once per frame
    void Update () {

    }




    public Vector3 GetPosition() {
        if (TargetPos.Count > 0)
        {
            //Debug.Log("ListCount" + TargetPos.Count);
            Vector3 temp = TargetPos.Dequeue();
            CurrentPosition = temp;
            //Debug.Log("current value:" + temp);
        }

        return CurrentPosition;
    }

    public Vector3 GeListtPosition()
    {
        if (ListPos.Count > 1)
        {
            //Debug.Log("ListCount" + TargetPos.Count);
            Vector3 temp = ListPos[1];
            CurrentPosition = temp;
            ListPos.RemoveAt(1);
            //Debug.Log("current value:" + temp);
        }

        return CurrentPosition;
    }


    IEnumerator RandomListPos(float _min, float _max)
    {
        yield return new WaitForSeconds(1 / 8);
        float XValue = Random.Range(_min, _max);
        Vector3 POS = new Vector3(XValue, Camera.main.transform.position.y, Camera.main.transform.position.z);

        min = XValue;

        ListPos.Add(POS);

        Debug.Log("Create pos");

        StartCoroutine(RandomListPos(min, max));
    }

    IEnumerator  RandomPos(float _min,float _max) {
    yield return new WaitForSeconds(1/8);
    float XValue =    Random.Range(_min, _max);
        Vector3 POS = new Vector3(XValue, Camera.main.transform.position.y, Camera.main.transform.position.z);

        min = XValue;

        TargetPos.Enqueue(POS);

        Debug.Log("Create pos");

        StartCoroutine(RandomPos(min, max));
    }

    

}
