using UnityEngine;
using System;
using System.Collections.Generic;
using TrackIRUnity;

[Serializable]
public class Limit {
    public float lower, upper;
}

public class FlightMovement : MonoBehaviour {
	
	
	#region TrackIR Variables
	TrackIRUnity.TrackIRClient trackIRclient;
	
	public bool useGUI;
	
    bool running;
	
	public static bool startRun;
	
    string status, data;
	
    public Rect statusRect;
    public Rect dataRect;
	
    public float positionReductionFactor, rotationReductionFactor;
	
    public Limit positionXLimits, positionYLimits, positionZLimits, yawLimits, pitchLimits, rollLimits;
	
    public bool useLimits;
	
    public Camera trackIRCamera;	
	#endregion
	
	
	#region Space Ship variables
	Transform target;
	
    public float speed = 100F;
	
	enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	RotationAxes axes = RotationAxes.MouseXAndY;
	float sensitivityX = 0.05F;
	float sensitivityY = 0.05F;

	float minimumX = -200F;
	float maximumX = 200F;

	float minimumY = -60F;
	float maximumY = 60F;
	
	float rotationY = 0F;
	#endregion
	
	void Start () {	
		trackIRclient = new TrackIRUnity.TrackIRClient();  // Detecting and creating an TrackIR to get data from
        status = "";
        data = "";
		
		Screen.lockCursor = true;
		
		target = GameObject.FindGameObjectWithTag("SpaceShip").transform;		
	}
	
	void Update () {
		Movement();
		
		if (!running && startRun)
		{
			StartCamera();	
		}
		else
		{
				
		}
	}
	
	void FixedUpdate()
	{
		if (!target)
			return;	
		
		target.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
	}
	
	void Movement()
	{
		if (running)
		{
			data = trackIRclient.client_TestTrackIRData();          // Data for debugging output, can be removed if not debugging/testing
			
			TrackIRClient.LPTRACKIRDATA tid = trackIRclient.client_HandleTrackIRData(); // Data for head tracking
			
			Vector3 pos = trackIRCamera.transform.localPosition;                          // Updates main camera, change to whatever
            Vector3 rot = trackIRCamera.transform.localRotation.eulerAngles;
			
			if (!useLimits) 
			{
                pos.x = -tid.fNPX * positionReductionFactor;                                        
                pos.y = tid.fNPY * positionReductionFactor;
                pos.z = -tid.fNPZ * positionReductionFactor;
				
                rot.y = -tid.fNPYaw * rotationReductionFactor;
                rot.x = tid.fNPPitch * rotationReductionFactor;
                rot.z = tid.fNPRoll * rotationReductionFactor;
            } 
			else 
			{
                pos.x = Mathf.Clamp(-tid.fNPX *- positionReductionFactor, positionXLimits.lower, positionXLimits.upper);
                pos.y = Mathf.Clamp(tid.fNPY * positionReductionFactor, positionYLimits.lower, positionYLimits.upper);
                pos.z = Mathf.Clamp(-tid.fNPZ * positionReductionFactor, positionZLimits.lower, positionZLimits.upper);
                
                rot.y = Mathf.Clamp(-tid.fNPYaw * rotationReductionFactor, yawLimits.lower, yawLimits.upper);
                rot.x = Mathf.Clamp(tid.fNPPitch * rotationReductionFactor, pitchLimits.lower, pitchLimits.upper);
                rot.z = Mathf.Clamp(tid.fNPRoll * rotationReductionFactor, rollLimits.lower, rollLimits.upper);
            }
			
			Camera.main.transform.localRotation = Quaternion.Euler(rot);
		}
		else
		{
			if (axes == RotationAxes.MouseXAndY)
			{
				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			else if (axes == RotationAxes.MouseX)
			{
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}	
		}
	}
	
	void StartCamera() {
        if (trackIRclient != null && !running) {                        // Start tracking
            status = trackIRclient.TrackIR_Enhanced_Init();
            running = true;
        }
    }
    void StopCamera() {
        if (trackIRclient != null && running) {                         // Stop tracking
            status = trackIRclient.TrackIR_Shutdown();
            running = false;
        }
    }

    void OnEnable() {
        StartCamera();
    }
    void OnDisable() {
        StopCamera();
    }
    void OnApplicationQuit() {                              // Shutdown the camera when we quit the application.
        StopCamera();
    }
}
