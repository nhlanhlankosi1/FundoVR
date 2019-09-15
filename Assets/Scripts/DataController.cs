using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
	public RoundData[] allRoundData; //hold data for each round

	// Start is called before the first frame update
	void Start()
	{
		DontDestroyOnLoad(gameObject); //when load scenes this data will persist

		SceneManager.LoadScene("GameScene");

	}

	public RoundData GetCurrentRoundData() //returns round one data...we only have one round
	{
		return allRoundData[0];
	}

	// Update is called once per frame
	void Update()
	{

	}

}
