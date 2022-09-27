using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
	public void OnRestart()
	{
		SceneManager.LoadScene(1);
	}

	public void OnQuit()
	{
		SceneManager.LoadScene(0);
	}
}
