using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
	private void Start()
	{
		FadeToBlack fadeBlack = GameObject.Find("FadeBlack").GetComponent<FadeToBlack>();
		StartCoroutine(fadeBlack.FadeBlackScreenOut());
	}

	public void OnExit()
	{
		SceneManager.LoadScene(0);
	}
}
