using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioSource fxAudioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioClip[] audioClips;
    const float moveSpeed = 10f;
    const float jumpForce = 8f;
    const float downForce = 4f;
    const float offFallLevel = -10f;
    const float gameOverDelay = 1f;
    const float cancelJumpTime = 0.5f;
    int healthPoints = 100;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    float movementInputHorizontal;
    float movementInputVertical;
    bool jumpPressed = false;
    bool jumpReleased = false;
    bool isCrouching = false;
    bool isGrounded = true;
    Text healthText;

    // Animator Tags
    int verticalSpeedHash = Animator.StringToHash(Tags.VERTICAL_SPEED_PARAMETER);
    int groundedHash = Animator.StringToHash(Tags.GROUNDED_PARAMETER);
    int jumpHash = Animator.StringToHash(Tags.JUMP_PARAMETER);
    int hurtHash = Animator.StringToHash(Tags.HURT_PARAMETER);
    int runHash = Animator.StringToHash(Tags.RUN_PARAMETER);
    int crouchHash = Animator.StringToHash(Tags.CROUCH_PARAMETER);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        GameObject healthTextObject = GameObject.FindWithTag(Tags.HEALTH_TEXT);
        healthText = healthTextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckESC();
        GetInput();
        MovePlayer();
        AnimatePlayer();
        HandleJump();
        HandleCrouch();
        PlayerFellOutOfLevel();
    }

    private void FixedUpdate()
    {
        animator.SetFloat(verticalSpeedHash, rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.GROUND_TAG))
        {
            isGrounded = true;
            animator.SetBool(groundedHash, true);
            animator.SetBool(jumpHash, false);
        }
        if (collision.gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            animator.SetBool(hurtHash, true);
            healthPoints -= 10;
            healthText.text = "Health " + healthPoints;
            if (healthPoints <= 0)
            {
                Invoke("GameOver", gameOverDelay);
                Destroy(gameObject, gameOverDelay);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.GROUND_TAG))
        {
            isGrounded = false;
            animator.SetBool(groundedHash, false);
        }
        if (collision.gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            animator.SetBool(hurtHash, false);
        }
    }

    void CheckESC()
    {
        bool escPressed = Input.GetKey(KeyCode.Escape);
        if (escPressed)
            MainMenu.LoadMainMenu();
    }

    void GetInput()
    {
        movementInputHorizontal = Input.GetAxisRaw("Horizontal"); // Raw means no smoothing Filter
        movementInputVertical = Input.GetAxisRaw("Vertical"); // Raw means no smoothing Filter
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
            StartCoroutine(CancelIsJumping());
        }
        if (Input.GetButtonUp("Jump"))
            jumpReleased = true;
    }

    void MovePlayer()
    {
        transform.position += new Vector3(movementInputHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (movementInputHorizontal > 0)
        {
            animator.SetBool(runHash, true);
            spriteRenderer.flipX = false;
        }
        else if (movementInputHorizontal < 0)
        {
            animator.SetBool(runHash, true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(runHash, false);
        }
    }

    void HandleJump()
    {
        if (jumpPressed && isGrounded)
        {
            jumpPressed = false;
            jumpReleased = false;
            animator.SetBool(jumpHash, true);
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            fxAudioSource.PlayOneShot(audioClips[0]);
        }
        if (jumpReleased && !isGrounded && rigidBody.velocity.y > 0)
        {
            jumpReleased = false;
            rigidBody.AddForce(Vector2.down * downForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator CancelIsJumping()
    {
        yield return new WaitForSeconds(cancelJumpTime);
        jumpPressed = false;
    }

    void HandleCrouch()
    {
        if (!isCrouching && isGrounded && movementInputVertical < 0)
        {
            animator.SetBool(crouchHash, true);
            isCrouching = true;
        }
        if (isCrouching && movementInputVertical >= 0)
            animator.SetBool(crouchHash, false);
    }

    void PlayerFellOutOfLevel()
    {
        if (transform.position.y < offFallLevel)
        {
            Invoke("GameOver", gameOverDelay);
            Destroy(gameObject, gameOverDelay);
        }
    }

    void GameOver()
    {
        MainMenu.GameOver();
    }
}
