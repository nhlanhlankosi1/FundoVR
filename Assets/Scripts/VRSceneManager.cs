using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class VRSceneManager : MonoBehaviour
{
	public static VRSceneManager instance;

	void Awake()
	{
		enableVr();
		//or
		//disableVR();
	}

	// Use this for initialization
	public void Start()
	{
		instance = this;
	}

	public IEnumerator LoadDevice(string newDevice, bool enable)
	{
		XRSettings.LoadDeviceByName(newDevice);
		yield return null;
		XRSettings.enabled = enable;
	}
	
	void enableVr()
	    {
	        StartCoroutine(LoadDevice("cardboard", true));
	    }

	void disableVr()
	    {
	        StartCoroutine(LoadDevice("none", false));
	    }
}
