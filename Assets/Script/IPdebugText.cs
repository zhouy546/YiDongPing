using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IPdebugText : MonoBehaviour {

    public GetUDPMessage REF_getUDPMessage;

   public Text text;
	// Use this for initialization
	void Start () {
        StartCoroutine(initi());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator initi() {
        yield return new WaitForSeconds(.5f);
        string port = REF_getUDPMessage.m_ReceivePort.ToString();
        string ip = Network.player.ipAddress;
        SetText(port, ip);
    }

    void SetText(string receivePort, string ip) {
        text.text = "receive port: " + receivePort + "\n" + "IP address" + ip;
    }

    void setPort(string port) {
        REF_getUDPMessage.m_ReceivePort = int.Parse(port);
    }
}
