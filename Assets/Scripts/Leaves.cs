using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
	private ParticleSystem _particleSystem;

	[SerializeField] private float _speedUpTo = 3f;
	[SerializeField] private float _speedDelay = 2f;

	[SerializeField] private float _easyRateOverTime = 5f;
	[SerializeField] private float _normalRateOverTime = 10f;
	[SerializeField] private float _hardRateOverTime = 15f;

	private void Start()
	{
		_particleSystem = GetComponent<ParticleSystem>();

		int difficulty = PlayerPrefs.GetInt("Difficulty");
		SetDifficultyEmission(difficulty);

		StartCoroutine(SpeedUpLeaves());
	}

	private void OnParticleCollision(GameObject other)
	{
		Caterpillar caterpillar = other.GetComponent<Caterpillar>();
		if (!caterpillar.hasWon && !caterpillar.isDead)
		{
			AudioManager.Instance.PlaySound("Fall");
			caterpillar.isDead = true;
		}
	}

	private void SetDifficultyEmission(int difficulty = 1)
	{
		ParticleSystem.EmissionModule emission = _particleSystem.emission;
		if (difficulty == 0)
		{
			emission.rateOverTime = _easyRateOverTime;
		}
		else if (difficulty == 1)
		{
			emission.rateOverTime = _normalRateOverTime;
		}
		else
		{
			emission.rateOverTime = _hardRateOverTime;
		}
	}

	// Leaves fall too slowly so player can climb half upway the tree
	// without encountering leaves so speeding up to account for this
	private IEnumerator SpeedUpLeaves()
	{
		ParticleSystem.MainModule _main = _particleSystem.main;
		_main.simulationSpeed = _speedUpTo;
		yield return new WaitForSeconds(_speedDelay);

		_main.simulationSpeed = 1f;
	}
}
