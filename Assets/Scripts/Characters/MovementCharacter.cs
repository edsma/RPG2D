using Assets.Scripts;
using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    public bool isMoving => _movementDirection.magnitude > 0f;
    public Vector2 MovementDirection => _movementDirection;
    public float Velocity => velocity;
    private Rigidbody2D _rigidBody2D;
    private Vector2 _input;
    private Vector2 _movementDirection;
    public CharacterHealth _characterHealth { get; private set; }
    private void Awake()
    {
        _rigidBody2D= GetComponent<Rigidbody2D>();
        _characterHealth = GetComponent<CharacterHealth>();
    }



    // Update is called once per frame
    void Update()
    {
        if (!_characterHealth.IsCharacterDefeated)
        {
            _input = new Vector2(Input.GetAxisRaw(Constants.Axis.horizontal), Input.GetAxisRaw(Constants.Axis.vertical));
            //X
            if (_input.x > 0.1f)
            {
                _movementDirection.x = 1f;
            }
            else if (_input.x < 0f)
            {
                _movementDirection.x = -1f;
            }
            else
            {
                _movementDirection.x = 0f;
            }
            //Y

            if (_input.y > 0.1f)
            {
                _movementDirection.y = 1f;
            }
            else if (_input.y < 0f)
            {
                _movementDirection.y = -1f;
            }
            else
            {
                _movementDirection.y = 0f;
            }
        }
       
    }

    private void FixedUpdate()
    {
        _rigidBody2D.MovePosition(_rigidBody2D.position + _movementDirection * Velocity * Time.fixedDeltaTime);
    }
}
