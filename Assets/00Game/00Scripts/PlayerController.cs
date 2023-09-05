using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] //typeof(TouchingDirections), typeof(Damageable))]
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigi;
    Vector2 moveInput;
    Animator animator;


    public float walkSpeed = 5f;


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
    //public bool CanMove
    //{
    //    get
    //    {
    //        return animator.GetBool(AnimationStrings.canMove);
    //    }
    //}
    //public bool IsAlive
    //{
    //    get
    //    {
    //        return animator.GetBool(AnimationStrings.isAlive);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rigi.velocity = new Vector2(moveInput.x * walkSpeed, rigi.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();



      
            SetfacingDirection(moveInput);
            IsMoving = moveInput != Vector2.zero;
     

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
}
