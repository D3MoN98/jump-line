using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BallMovement : MonoBehaviour
{
    public TMP_Text text;
    public Rigidbody2D ball;


    [Header("Movements")]
    [SerializeField]
    public float speed = 10f;
    [SerializeField]
    public float upForce = 20f;
    [SerializeField]
    public float acceleration = 7f;
    [SerializeField]
    public float decceleration = 7f;
    [SerializeField]
    public float velocityPower = 0.9f;
    [SerializeField]
    private float fallMultiplier = 0.1f;
    [SerializeField]
    private float jumpMultiplier = 0.1f;

    private float turn;
    private bool isGrounded = false;
    private float rayCatGroudDistance = 0.8f;



    private void FixedUpdate()
    {
        isGrounded = gameObject.GetComponentInChildren<GroundCheck>().isGrounded;
        // GroundCheck();
        QuickFall();
        Move();
    }

    public void GroundCheck(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCatGroudDistance);
        Debug.DrawRay(transform.position, Vector2.down * rayCatGroudDistance);
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            ball.velocity = new Vector2(ball.velocity.x, upForce);
        }
    }

    public void QuickFall()
    {
        if(ball.velocity.y > 0){
            ball.velocity += Vector2.up * Physics2D.gravity * jumpMultiplier;
        }else if(ball.velocity.y < 0){
            ball.velocity += Vector2.up * Physics2D.gravity * fallMultiplier;
        }
    }

    public void OnMove(InputValue input)
    {
        turn = input.Get<Vector2>().x;
        text.text = turn.ToString();
    }

    public void Move(){
        float targetSpeed = turn * speed;
        float speedDif = targetSpeed - ball.velocity.x;
        float accelerate = (Mathf.Abs(targetSpeed) > 0.1f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelerate, velocityPower) * Mathf.Sign(speedDif);
        ball.AddForce(movement * Vector2.right);
    }
}
