using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem; // Ensure this is included for InputAction

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))] // This will add a Rigidbody2D component to the GameObject if it doesn't already have one
public class PlayerController : MonoBehaviour
{
    public float jumpimpulse = 10f; // Player jump impulse
    public float airWalkSpeed = 3f; // Player run speed
    public float runSpeed = 8f; // Player run speed
    public float walkSpeed = 5f; // Player walk speed
    private Vector2 moveInput; // Store the move input from PlayerInput
    TouchingDirections touchingDirections;
    Damageable damageable;

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
                        // if(IsRunning)
                        // {
                        //     return runSpeed;
                        // }
                        // else
                        // {
                        //     return walkSpeed;
                        // }
                        return walkSpeed;
                    }
                    else
                    {
                        return airWalkSpeed;
                    }
                }
                else
                {
                    return 0;
                }
            }

            else
            {
                return 0;
            }

        }
    }

    [SerializeField]
    private bool _isMoving = false; // Private field to store if the player is moving
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value); // Set the animator parameter to the value of IsMoving
        }
    } // Property to check if the player is moving

    public bool _isFacingRight = true; // Private field to store if the player is facing right

    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1); // Flip the player's sprite
            }
            _isFacingRight = value;
        }
    } // Property to check if the player is facing right

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }

        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    private Rigidbody2D rb; // Reference to Rigidbody2D
    Animator animator; // Reference to Animator

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Initialize the Rigidbody2D reference
        animator = GetComponent<Animator>(); // Initialize the Animator reference
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
    }

    private void FixedUpdate()
    {
        // if (CanMove)
        // {
        //     // Apply movement
        //     rb.linearVelocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.linearVelocity.y);
        // }
        // else
        // {
        //     // Stop horizontal movement
        //     rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        // }

        if (!damageable.LockVelocity)
        {
            rb.linearVelocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.linearVelocity.y);
        }


        // Update yVelocity for the animator
        animator.SetFloat(AnimationStrings.yVelocity, rb.linearVelocity.y);
    }


    // This method is called by PlayerInput via UnityEvent
    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // Get the movement input

        if (CanMove)
        {

            IsMoving = moveInput != Vector2.zero; // Set IsMoving to true if the player is moving

            SetFacingDirection(moveInput); // Call the method to set the facing direction
        }
        else
        {
            IsMoving = false;
        }

    }

    private void SetFacingDirection(Vector2 direction)
    {
        if (direction.x > 0 && !IsFacingRight) // If moving right
        {
            IsFacingRight = true; // Set IsFacingRight to true
        }
        else if (direction.x < 0 && IsFacingRight) // If moving left
        {
            IsFacingRight = false; // Set IsFacingRight to false
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger); // Set the jump trigger in the animator
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpimpulse); // Set the y velocity to the jump impulse
        }
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger); // Set the attack trigger in the animator
        }
    }

    public void onRangedAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.rangedAttackTrigger); // Set the attack trigger in the animator
        }
    }

    public void onHit(int damage, Vector2 knockback)
    {
        // LockVelocity = true;
        rb.linearVelocity = new Vector2(knockback.x, rb.linearVelocity.y + knockback.y); // Apply knockback
    }
}
