using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float dashForce = 10;
    private bool canJump = true;
    public float speed = 10;
    public float jumpforce = 10;
    public float max_speed = 10;
    public float stopping_force = 5;
    public float dashTime = 0.5f;
    private Rigidbody2D rigidbody2D;
    private bool _isDashing = false;
    private bool _isJumping = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        HandleMaxSpeed();
        PlayerStopping();
    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x, 0) * speed);
    }

    private void HandleMaxSpeed()
    {
        if (_isDashing)
        {
            return;
        }
        if (rigidbody2D.linearVelocityX >= max_speed)
        {
            rigidbody2D.linearVelocityX = max_speed;
        }
        else if (rigidbody2D.linearVelocityX <= -max_speed)
        {
            rigidbody2D.linearVelocityX = -max_speed;
        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX, 0) * stopping_force);
        }

    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnDash()
    {
        if(_isDashing)
        {
            return;
        }
        _isDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
        StartCoroutine(ResetDash(dashTime));
    }
    IEnumerator ResetDash(float timeToRest)
    {
        yield return new WaitForSeconds(timeToRest);
        _isDashing = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}