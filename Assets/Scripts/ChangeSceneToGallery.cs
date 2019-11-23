using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneToGallery : MonoBehaviour
{
    // This script was written to control the gaze behavior to change scene


    public Image circleImageGaze;
    public float totalTime = 3;
    public float gvrTimer;  // MyTime in other video
    bool gvrStatus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            circleImageGaze.fillAmount = gvrTimer / totalTime;

        }

        if (gvrTimer >= 3f)
        {
            changeScene();
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene("SampleVideoGallery");
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0f;
        circleImageGaze.fillAmount = 0;
    }

}













