using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class VRSceneManagerOff : MonoBehaviour
{
	public static VRSceneManagerOff instance;

	void Awake()
	{
		disableVr();
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
