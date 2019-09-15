using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScreenController : MonoBehaviour
{
   public void StartQuiz()
	{
		SceneManager.LoadScene("GameScene");
	}
}
