using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displays : MonoBehaviour
{
	// Use this for initialization
    void Start()
    {
		Screen.SetResolution(4800, 1800, false);
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON.
        // Check if additional displays are available and activate each.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
		    Display.displays[1].SetParams(2880, 1800, 1920, 0) ;
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
    }
    //public void Activate(int width, int height, int refreshRate)
}
//2880*1800 , 1920*1080 
//Display.displays[1].SetParams(Width of display 1,height of display 1,starting x for display 1,starting y for display 1);
/*Camera[] myCams = new Camera[3];
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        //Get Main Camera
        myCams[0] = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        //Find All other Cameras
        myCams[1] = GameObject.Find("Camera0").GetComponent<Camera>();
        myCams[2] = GameObject.Find("Camera1").GetComponent<Camera>();

        //Call function when new display is connected
        Display.onDisplaysUpdated += OnDisplaysUpdated;

        //Map each Camera to a Display
        mapCameraToDisplay();
    }

    void mapCameraToDisplay()
    {
        //Loop over Connected Displays
        for (int i = 0; i < Display.displays.Length; i++)
        {
            myCams[i].targetDisplay = i; //Set the Display in which to render the camera to
            Display.displays[i].Activate(); //Enable the display
        }
    }

    void OnDisplaysUpdated()
    {
        Debug.Log("New Display Connected. Show Display Option Menu....");
    }*/