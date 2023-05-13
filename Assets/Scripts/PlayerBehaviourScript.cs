using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    const float moveSpeed = 10f;
    const float jumpForce = 8f;
    const float offFallLevel = -10f; 
    [SerializeField] AudioSource fxAudioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioClip[] audioClips;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    float movementInput;
    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        AnimatePlayer();
        JumpPlayer();
        CrouchPlayer();
        PlayerFellOutOfLevel();
    }

    private void FixedUpdate()
    {
        animator.SetFloat(Tags.VERTICAL_SPEED_PARAMETER, rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.GROUND_TAG))
        {
            isGrounded = true;
            animator.SetBool(Tags.GROUNDED_PARAMETER, true);
            animator.SetBool(Tags.JUMP_PARAMETER, false);
        }
        if (collision.gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            // hurt Animation
            // decrease Health Points
            // if Health Points <= 0
            // Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.GROUND_TAG))
        {
            isGrounded = false;
            animator.SetBool(Tags.GROUNDED_PARAMETER, false);
        }
    }

    void MovePlayer()
    {
        movementInput = Input.GetAxisRaw("Horizontal"); // Raw means no smoothing Filter
        transform.position += new Vector3(movementInput, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (movementInput > 0)
        {
            animator.SetBool(Tags.RUN_PARAMETER, true);
            spriteRenderer.flipX = false;
        }
        else if (movementInput < 0)
        {
            animator.SetBool(Tags.RUN_PARAMETER, true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(Tags.RUN_PARAMETER, false);
        }
    }

    void JumpPlayer()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            animator.SetBool(Tags.JUMP_PARAMETER, true);
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            fxAudioSource.PlayOneShot(fxAudioSource.clip);
        }
    }

    void CrouchPlayer()
    {
        if (isGrounded && Input.GetKey("down"))
            animator.SetBool(Tags.CROUCH_PARAMETER, true);
        if (!Input.GetKey("down"))
            animator.SetBool(Tags.CROUCH_PARAMETER, false);
    }

    void PlayerFellOutOfLevel()
    {
        if (transform.position.y < offFallLevel)
            // Game Over
            Destroy(gameObject);
    }
}
