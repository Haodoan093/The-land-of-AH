using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]
public class BringerController : MonoBehaviour
{
    public float walkAcceleration = 3f;
    public float maxSpeed = 3f;
    public float walkStopRate = 0.05f;
    Rigidbody2D rigi;
    TouchingDirections touchingDirection;
    Animator animator;
     Damageable damageable;
    //atk
    public DetectionZone attackZone;
    public DetectionZone cliffDetection;
    public enum WalkalbeDirection
    {
        Right,
        Left
    }
    private Vector2 walkDirectionVector = Vector2.right;

  
    private WalkalbeDirection _walkDirection;
    public WalkalbeDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                //Direction flipped
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkalbeDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if (value == WalkalbeDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }


            }
            _walkDirection = value;

        }
    }
    private bool _hasTarget;
    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }

    }
    public float AttackCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.attackCooldown);
        }
        private set
        {
            animator.SetFloat(AnimationStrings.attackCooldown, MathF.Max(value, 0));
        }
    }



    private void Awake()
    {

        rigi = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<TouchingDirections>();
        animator = GetComponentInChildren<Animator>();
        damageable = GetComponent<Damageable>();
    }


    private void FlipDirection()
    {

        if (WalkDirection == WalkalbeDirection.Right)
        {
            WalkDirection = WalkalbeDirection.Left;
        }
        else if (WalkDirection == WalkalbeDirection.Left)
        {
            WalkDirection = WalkalbeDirection.Right;
        }

    }
    private void FixedUpdate()
    {

        if (touchingDirection.IsOnWall && touchingDirection.IsGrounded&&!HasTarget)
        {// dang tren Groud va phai tuong or cliff
            FlipDirection();
        }
        if(!damageable.LockVelocity) {
            if (CanMove)
            {//gioi han toc do
                rigi.velocity = new Vector2(maxSpeed * walkDirectionVector.x, rigi.velocity.y);
            }
            else
            {
                rigi.velocity = new Vector2(Mathf.Lerp(rigi.velocity.x, 0, walkStopRate), rigi.velocity.y);
            }
        }
       
             
          

    }
    // Update is called once per frame
    private void Update()
    {
        HasTarget = attackZone.detectionColliders.Count > 0;
        if (AttackCooldown > 0)
        {
            AttackCooldown -= Time.deltaTime;
        }
    }
    public void OnHit(float dmg, Vector2 knockBack)
    {
        // LockVelocity = true;
        rigi.velocity = new Vector2(knockBack.x, rigi.velocity.y + knockBack.y);
    }
    public void OnCliffDetection()
    {
        if (touchingDirection.IsGrounded)
        {
            FlipDirection();
        }
    }
}
