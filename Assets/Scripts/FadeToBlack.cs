using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
	[SerializeField] private float _fadeSpeed = 1f;
	[SerializeField] private float _fadeDelay = 1f;

	public IEnumerator FadeScreenToBlack()
	{
		Image image = GetComponent<Image>();
		while (image.color.a < 1)
		{
			Color imageColor = image.color;
			float fadeAmount = imageColor.a + (_fadeSpeed * Time.deltaTime);

			image.color = new Color(image.color.r, image.color.g, image.color.b, fadeAmount);
			yield return null;
		}
		yield return new WaitForSeconds(_fadeDelay);
	}

	public IEnumerator FadeBlackScreenOut()
	{
		Image image = GetComponent<Image>();
		while (image.color.a > 0)
		{
			Color imageColor = image.color;
			float fadeAmount = imageColor.a - (_fadeSpeed * Time.deltaTime);

			image.color = new Color(image.color.r, image.color.g, image.color.b, fadeAmount);
			yield return null;
		}
		yield return new WaitForSeconds(_fadeDelay);
	}
}
