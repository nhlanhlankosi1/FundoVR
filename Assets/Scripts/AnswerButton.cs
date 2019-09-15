using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
	public Text answerText; //text to display
	private GameController gameController; //reference to the gameController

	private AnswerData answerData; //store the answer instance

	// This script was written to control the gaze behavior to change scene
	public Image circleImageGaze;
	public float totalTime = 3;
	public float gvrTimer;  // MyTime in other video
	bool gvrStatus;

	// Use this for initialisation
	void Start()
	{
		gameController = FindObjectOfType<GameController>(); //find the game controller
	}

	public void Setup(AnswerData data) //pass in answer data and set up for display
	{
		answerData = data;
		answerText.text = answerData.answerText;
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
			HandleClick();
			GVROff();
		}
	}

	//handle the button click and send if the answer was correct to the game controller
	public void HandleClick()
	{
		gameController.AnswerButtonClicked(answerData.isCorrect);
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
