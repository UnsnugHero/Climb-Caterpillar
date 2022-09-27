using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Vector3 _velocity = Vector3.zero;
	private bool _shouldFollow = true;

	[SerializeField] private Vector3 _offset = new Vector3(0f, -1f, -10f);
	[SerializeField] private float _smoothTime = 0.5f;

	[SerializeField] private Transform _target;

	// Update is called once per frame
	void Update()
	{
		if (_shouldFollow)
		{
			Vector3 targetPosition = _target.position + _offset;
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
		}
	}

	public void SetFollowing(bool shouldFollow)
	{
		_shouldFollow = shouldFollow;
	}
}

