using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Text questionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;
	public GameObject correctAnswerDisplay;
	public GameObject wrongAnswerDisplay;
	public GameObject gameTimeAndScoreDisplay;
	public Text finalScore;
	public Text timeIsUp;
	public Text timeTakenOnQuiz;
	public GameObject timeTakenOnQuizObject;


	private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int questionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();


	// Start is called before the first frame update
	void Start()
	{
		dataController = FindObjectOfType<DataController>(); //we can use Find() because we start with the Persistent Scene which has a data controller
															 //Once dataController is loaded initialize game variables with the data found
		currentRoundData = dataController.GetCurrentRoundData();
		questionPool = currentRoundData.questions;
		timeRemaining = currentRoundData.timeLimitInSeconds;
		UpdateTimeRemainingDisplay();

		//initialise remaining game data and show first question
		playerScore = 0;
		questionIndex = 0;

		Invoke("ShowQuestion", 1f);

		isRoundActive = true;

	}

	private void ShowQuestion()
	{
		//Remove old answers get current question and display the text
		RemoveAnswerButtons();
		QuestionData questionData = questionPool[questionIndex];
		questionDisplayText.text = questionData.questionText;

		//Get all answers for the question, create new buttons for each and add them to the answerButtonParent object (AnswerPanel)
		for (int i = 0; i < questionData.answers.Length; i++)
		{
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
			answerButtonGameObjects.Add(answerButtonGameObject);
			answerButtonGameObject.transform.SetParent(answerButtonParent);

			//we get a reference to the answer button then use its attached script to set the answer
			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>(); //Give the gameobject an answer button component
			answerButton.Setup(questionData.answers[i]);
		}
	}

	private void RemoveAnswerButtons()
	{
		//if answer buttons exists remove them, remove the game object and add it to the available object pool
		while (answerButtonGameObjects.Count > 0)
		{
			answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
			answerButtonGameObjects.RemoveAt(0);
		}
	}

	public void AnswerButtonClicked(bool isCorrect)
	{
		//Increase player Score if answer is correct and update the display
		if (isCorrect)
		{
			playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = "Score: " + playerScore.ToString();

			questionDisplay.SetActive(false);
			correctAnswerDisplay.SetActive(true);
		}
		else
		{
			questionDisplay.SetActive(false);
			correctAnswerDisplay.SetActive(false);
			wrongAnswerDisplay.SetActive(true);
		}

		//delay the method for 1.5 seconds
		Invoke("ShowNextQuestion", 1.5f);

	}

	public void ShowNextQuestion()
	{
		correctAnswerDisplay.SetActive(false);
		wrongAnswerDisplay.SetActive(false);
		questionDisplay.SetActive(true);

		//If we have more questions, show the next question otherwise end the round
		if (questionPool.Length > questionIndex + 1)
		{
			questionIndex++;
			ShowQuestion();
		}

		else
		{
			EndRound();
			timeTakenOnQuiz.text = "You Took: " + Mathf.Round(75 - timeRemaining).ToString() + " Seconds";
		}

	}

	public void EndRound()
	{
		//set the round over and turn off question display and turn on round end display panel
		isRoundActive = false;
		questionDisplay.SetActive(false);
		roundEndDisplay.SetActive(true);
		gameTimeAndScoreDisplay.SetActive(false);
		finalScore.text = "Your Final Score Is:  " + playerScore.ToString() + " / 100";

	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene("MainScene");
	}

	private void UpdateTimeRemainingDisplay()
	{
		timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
	}

	// Update is called once per frame
	void Update()
	{
		//if round is active, decrement time remaining and update display
		if (isRoundActive)
		{
			timeRemaining -= Time.deltaTime;
			UpdateTimeRemainingDisplay();

			//if time is 0 or less end round
			if (timeRemaining <= 0f)
			{
				EndRound();
				timeIsUp.text = "SORRY, TIME'S UP";
				timeTakenOnQuizObject.SetActive(false);
			}

		}

	}

}
