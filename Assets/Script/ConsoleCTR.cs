using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCTR : MonoBehaviour {
    private bool toggleBall =true;
    private bool toggleConsole=false;
    public RectTransform console;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (toggleConsole) {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                toggleBall = !toggleBall;
                Mover.instance.sphere.GetComponent<MeshRenderer>().enabled = toggleBall;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            toggleConsole = !toggleConsole;
            console.gameObject.SetActive(toggleConsole);
        }
	}


}
