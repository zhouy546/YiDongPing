using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBG : ImageBase {

	// Use this for initialization
	public void Start () {
        base.Start();
	}

    // Update is called once per frame
    public void Update () {
        base.Update();
    }

  public  void HideAll() {
        changeImageAlpha(0f, .5f, OnAlphaComplete);
        ShinkSown();
    }

   public  void ShowAll() {
        changeImageAlpha(.8f, .5f, OnAlphaComplete);
        ScaleUp();
    }

    void ScaleUp() {
        ChangeScale(Vector3.one, .5f);
    }

    void ShinkSown() {
        ChangeScale(Vector3.zero, .5f);
    }
}
