using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]// typeof(Damageable))]
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigi;
    Vector2 moveInput;
    Animator animator;
    TouchingDirections touchingDirections;
    //  Damageable damageable;


    public float walkSpeed = 5f;
    public float jumpImpulse = 10f;
    public float rollSpeed = 10f;
    public float airSpeed = 8f;


    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }
    public bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    public float CurrentMoveSpeed
    {
        get
        {

            if (CanMove)
            {

                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                    {

                        return walkSpeed;

                    }

                    else return airSpeed;
                }
                else
                {  //Idle is 0
                    return 0;
                }
            }
            else
            {//Movement Locked
                return 0;
            }
        }

    }



    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rigi.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rigi.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rigi.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();



        if (IsAlive)
        {
            SetfacingDirection(moveInput);
            IsMoving = moveInput != Vector2.zero;
        }
        else
        {
            IsMoving = false;
        }

    }

    private void SetfacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;

        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    { //TODO check if alive as well
        if (context.started && touchingDirections.IsGrounded&&CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rigi.velocity = new Vector2(rigi.velocity.x, jumpImpulse);
        }


    }
    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded&&IsMoving&&CanMove)
        {
            animator.SetTrigger(AnimationStrings.roll);
            rigi.velocity = new Vector2(rollSpeed* moveInput.x, rigi.velocity.y);
        }
    }
    public void Onattack(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

}