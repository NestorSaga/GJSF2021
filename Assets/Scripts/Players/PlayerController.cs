using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction {UP, DOWN, LEFT, RIGHT}
public enum State {IDLE, MOVING, ATTACKING}
public class PlayerController : MonoBehaviour
{
    // Movement
    [Header("Movement Parameters")]
    public float speed = 5;
    public float jumpForce = 5;
    bool isGrounded; // Variable de control interna, en algun momento la podriamos llegar a usar.
    private Rigidbody rb;
    State state = State.IDLE;
    Direction direction = Direction.DOWN;

    // Attack
    [Header("Attack Parameters")]
    public GameObject hitbox;
    public float attackRange = 1;
    public float attackDuration = 0.2f;
    public float damage = 5;

    // Gestión de inputs
    Vector3 playerInput;
    bool jumpInput, attackInput, flip;

    // Valores
    public float P1HP, maxP1HP;

    // Referencias



    public Animator animator;
    public SoundManager sm;


    public void OnMove(InputAction.CallbackContext ctx) => playerInput = new Vector3(ctx.ReadValue<Vector2>().x, 0 , ctx.ReadValue<Vector2>().y);
    public void OnJump(InputAction.CallbackContext ctx) => jumpInput = ctx.ReadValueAsButton();
    public void OnAttack(InputAction.CallbackContext ctx) => attackInput = ctx.ReadValueAsButton();
    public void OnPause(InputAction.CallbackContext ctx) => Debug.Log("Pause!"); // Quiza ni lo termine haciendo el player en si...

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        P1HP = maxP1HP;
    }

    private void Update()
    {
        // Flip player model
        if (playerInput.x > 0.1f)
            animator.transform.localScale = new Vector3(0.5f, animator.transform.localScale.y, animator.transform.localScale.z);

        else if (playerInput.x < -0.1f) 
            animator.transform.localScale = new Vector3(-0.5f, animator.transform.localScale.y, animator.transform.localScale.z);

        // Update Animator
        animator.SetFloat("Speed", playerInput.magnitude);
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("AttackInput", attackInput);
    }

    void FixedUpdate()
    {
        //Direction
        if (playerInput.x < 0) direction = Direction.LEFT;
        else if (playerInput.x > 0) direction = Direction.RIGHT;
        else if (playerInput.z < 0) direction = Direction.DOWN;
        else if (playerInput.z > 0) direction = Direction.UP;

        //Movement
        rb.MovePosition(transform.position + playerInput * Time.deltaTime * speed);

        //Jump
        if (Physics.CheckSphere(transform.position - transform.up * GetComponent<CapsuleCollider>().height/2, 0.1f, (1 << 8)))
        {
            // Definimos grounded
            isGrounded = true;

            // Si salta...
            if (jumpInput)
                rb.velocity = Vector3.up * jumpForce;
        }

        else isGrounded = false;

        //Attack
        if (attackInput)
            StartCoroutine(AttackCoroutine(attackDuration));

        // Reseteamos bools de input
        jumpInput = false;
        attackInput = false;
    }

    IEnumerator AttackCoroutine(float duration)
    {
        switch (direction)
        {
            case Direction.UP:
                hitbox.transform.localPosition = transform.forward * attackRange;
                break;

            case Direction.DOWN:
                hitbox.transform.localPosition = -transform.forward * attackRange;
                break;

            case Direction.LEFT:
                hitbox.transform.localPosition = -transform.right * attackRange;
                break;

            case Direction.RIGHT:
                hitbox.transform.localPosition = transform.right * attackRange;
                break;
        }

        hitbox.SetActive(true);


        while (duration > 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }
        hitbox.SetActive(false);
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Fire")
        {
            switch (direction)
            {
                case Direction.UP:
                    rb.AddForce(-transform.forward * 2000);
                    break;

                case Direction.DOWN:
                    rb.AddForce(transform.forward * 2000);
                    break;

                case Direction.LEFT:
                    rb.AddForce(transform.right * 2000);
                    break;

                case Direction.RIGHT:
                    rb.AddForce(-transform.right * 2000);
                    break;
            }

            TakeDamage(10);
        }
    }

    public void TakeDamage(float quantity)
    {
        P1HP -= quantity;
    }
}
