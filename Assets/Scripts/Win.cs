using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine(FadeToBlack());
			other.gameObject.GetComponent<Caterpillar>().hasWon = true;
		}
	}

	private IEnumerator FadeToBlack()
	{
		FadeToBlack fadeToBlack = GameObject.Find("FadeToBlack").GetComponent<FadeToBlack>();
		yield return StartCoroutine(fadeToBlack.FadeScreenToBlack());

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
