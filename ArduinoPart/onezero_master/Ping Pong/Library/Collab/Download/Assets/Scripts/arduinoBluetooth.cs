using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using UnityEngine;
using System.Threading;

public class arduinoBluetooth : MonoBehaviour
{
    
	SerialPort sp;
	string text;
	string data;
	public GameObject wall0,wall1;
	trigger triggerScript;
	ResetaBall resetScript;
	public bool hithit,sendingD13;
    public string serialPortName = "/dev/cu.OZ01-DevB";///dev/cu.OZ01-DevB
	string[] parsedData;
	private Vector3 velocityA = Vector3.zero;
	private Vector3 velocityB = Vector3.zero;
	private Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.03F;
    public int keyDown;
    public int receive;
    
	void Start()
	{
		sp = new SerialPort(serialPortName, 9600);
		if (!sp.IsOpen)
		{
			print("Opening "+serialPortName+" baud 9600");
			sp.Open();
			sp.ReadTimeout = 100;
			sp.Handshake = Handshake.None;
			if (sp.IsOpen)
			{
				print("Open");
			}
		}
		GameObject trigger = GameObject.Find("Trigger");
		triggerScript = trigger.GetComponent<trigger>();
	}
	void Update()
	{
		hithit = triggerScript.hit;
		if (sp.IsOpen)
		{
			data = sp.ReadLine();
			sp.BaseStream.Flush();
			//print(data);
			parsedData = data.Split(new string[] { "," }, StringSplitOptions.None);
			Vector3 p = wall0.transform.position;
			Vector3 p1 = wall1.transform.position;
			p.z = float.Parse(parsedData[0]) / -5;
            p1.z = float.Parse(parsedData[1]) / 5;
            receive = int.Parse(parsedData[2]);
			wall0.transform.position = Vector3.SmoothDamp(wall0.transform.position, p, ref velocityA, smoothTime);//p smoothTime
			wall1.transform.position = Vector3.SmoothDamp(wall1.transform.position, p1, ref velocityB, smoothTime);//p
		}

		if (sendingD13)
		{
            if (hithit == true)
            {
                sp.WriteLine("HIGH");
                sp.BaseStream.Flush();
            }
			if (hithit == false)
			{
				sp.WriteLine("LOW");
				sp.BaseStream.Flush();
			}
        }

		if (Input.GetKeyDown(KeyCode.Space))
        {
			keyDown = 1;
            
        }
		if (Input.GetKeyUp(KeyCode.Space))
        {
			keyDown = 0;

        }
		sp.WriteLine(keyDown.ToString());
        sp.BaseStream.Flush();
	}
}
