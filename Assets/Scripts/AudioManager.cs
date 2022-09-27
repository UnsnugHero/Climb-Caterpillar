using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager _instance;
	public static AudioManager Instance
	{
		get { return _instance; }
	}

	[SerializeField] private List<Sound> _sounds;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in _sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	private void Start()
	{
		PlaySound("Piano");
		PlaySound("Ambience");
		// StartCoroutine(FadeInSound("Ambience", 5f));
	}

	public void PlaySound(string name)
	{
		Sound s = _sounds.Find(sound => sound.name == name);

		if (s == null || s.source == null)
		{
			Debug.LogWarning($"Sound with name {name} not found");
			return;
		}

		if (!s.playIfAlreadyPlaying && s.source.isPlaying)
		{
			return;
		}

		s.source.Play();
	}

	public void StopSound(string name)
	{
		Sound s = _sounds.Find(sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning($"Sound with name {name} not found");
			return;
		}

		s.source.Stop();
	}

	public void PauseAudio()
	{
		foreach (Sound s in _sounds)
		{
			if (s.source.isPlaying && s.shouldStopOnPause)
			{
				s.source.Pause();
				s.isPaused = true;
			}
		}
	}

	public void ResumeAudio()
	{
		foreach (Sound s in _sounds)
		{
			if (s.isPaused)
			{
				s.source.Play();
				s.isPaused = false;
			}
		}
	}

	public void StopAllAudio()
	{
		foreach (Sound s in _sounds)
		{
			s.source.Stop();
		}
	}

	public bool IsSoundPlaying(string name)
	{
		Sound s = _sounds.Find(sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning($"Sound with name {name} not found");
			return false;
		}

		return s.source.isPlaying;
	}

	public void SetVolume(string name, float volume)
	{
		Sound s = _sounds.Find(sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning($"Sound with name {name} not found");
			return;
		}

		if (volume < 0f || volume > 1f)
		{
			Debug.LogWarning("Volumne out of valid range");
			return;
		}

		s.source.volume = volume;
	}

	public IEnumerator FadeInSound(string name, float fadeTime)
	{
		Sound s = _sounds.Find(sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning($"Sound with name {name} not found");
			yield break;
		}

		if (s.source.isPlaying)
		{
			Debug.LogWarning("Sound is already playing");
			yield break;
		}

		s.source.Play();
		s.source.volume = 0;

		float resultVolume = s.volume;
		Debug.Log(s.volume);
		float frameCount = fadeTime / Time.deltaTime;
		float framesPassed = 0;

		while (framesPassed <= frameCount)
		{
			var t = framesPassed++ / frameCount;
			s.source.volume = Mathf.Lerp(0, resultVolume, t);
			yield return null;
		}

		s.source.volume = resultVolume;
	}
}
