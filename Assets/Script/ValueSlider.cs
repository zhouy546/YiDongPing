using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ValueSlider : MonoBehaviour {
  public  Slider myslider;

   public Text text;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEasingValue()
    {
        float value = myslider.value;

        Mover.instance.setEasingValue(value);
        text.text = value.ToString();
    }
}
