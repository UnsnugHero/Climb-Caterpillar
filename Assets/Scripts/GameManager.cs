using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get { return _instance; }
	}

	private Caterpillar _caterpillar;
	private CameraFollow _cameraFollow;
	private GameObject _restartMenu;
	private GameObject _bottomBound;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	private void Start()
	{
		_caterpillar = GameObject.Find("Caterpillar").GetComponent<Caterpillar>();
		_cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
		_restartMenu = GameObject.Find("RestartMenu");
		_bottomBound = GameObject.Find("BottomBound");

		_restartMenu.SetActive(false);
	}

	private void Update()
	{
		_cameraFollow.SetFollowing(!_caterpillar.isDead);
		_bottomBound.SetActive(!_caterpillar.isDead);
		_restartMenu.SetActive(_caterpillar.isDead);
	}
}
