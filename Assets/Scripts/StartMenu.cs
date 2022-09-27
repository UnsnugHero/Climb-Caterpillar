using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	private GameObject _playGroup;
	private GameObject _difficultyGroup;

	private void Start()
	{
		_playGroup = GameObject.Find("PlayGroup");
		_difficultyGroup = GameObject.Find("DifficultyGroup");
		_difficultyGroup.SetActive(false);
	}

	public void OnPlay()
	{
		_playGroup.SetActive(false);
		_difficultyGroup.SetActive(true);
	}

	public void OnDifficultySelected(int difficulty)
	{
		PlayerPrefs.SetInt("Difficulty", difficulty);
		PlayGame();
	}

	private void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
