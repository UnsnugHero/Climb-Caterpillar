using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : MonoBehaviour
{
	public bool isDead = false;
	public bool hasWon = false;

	private Animator _animator;
	private Rigidbody2D _rigidBody;
	private Vector2 _direction;

	[SerializeField] private float _speed;
	[SerializeField] private float _rotationSpeed;

	// Start is called before the first frame update
	void Start()
	{
		_animator = GetComponent<Animator>();
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!isDead && !hasWon)
		{
			float directionX = Input.GetAxisRaw("Horizontal");
			float directionY = Input.GetAxisRaw("Vertical");
			_direction = new Vector2(directionX, directionY).normalized;
			AnimateMovement(directionX, directionY);
			SetDirectionFacing();
		}
		else if (isDead)
		{
			_direction = Vector2.zero;
			_rigidBody.gravityScale = 40f;
		}
		else if (hasWon)
		{
			_direction = Vector2.zero;
		}
	}

	private void FixedUpdate()
	{
		_rigidBody.velocity = new Vector2(_direction.x * _speed, _direction.y * _speed);
	}

	private void SetDirectionFacing()
	{
		if (_direction != Vector2.zero)
		{
			Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, _direction);
			transform.rotation = toRotation;
		}
	}

	private void AnimateMovement(float directionX, float directionY)
	{
		bool isMoving = directionX != 0f || directionY != 0f;
		_animator.SetBool("isMoving", isMoving);
	}
}
