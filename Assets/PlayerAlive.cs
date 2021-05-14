using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlive : MonoBehaviour, IDamage
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    private bool _groundedPlayer;
    private float _jumpHeight = 1.0f;
    private float Gravity = -9.81f;
    public float health;

    private Vector3 _velocity;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();

        _groundedPlayer = _controller.isGrounded;

        if (Input.GetButton("Jump") && _groundedPlayer)
        {
            Jump();
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * _moveSpeed);

        _velocity.y += Gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }

    private void Movement()
    {
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        _controller.Move(move * Time.deltaTime * _moveSpeed);
        _velocity.y += Gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);

        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else if (move == Vector3.zero)
        {
            Idle();
        }
    }

    private void Idle()
    {
        _moveSpeed = 0;
    }

    private void Walk()
    {
        _moveSpeed = _walkSpeed;

    }

    private void Run()
    {
        _moveSpeed = _runSpeed;
    }

    private void Jump()
    {
        _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Gravity);
    }
    public void TakeDamage()
    {
        health--;
    }
    void OnTriggerEnter(Collider collid)
    {
        if (collid.name == "Hunter")
        {
           TakeDamage();
        }


    }
}
