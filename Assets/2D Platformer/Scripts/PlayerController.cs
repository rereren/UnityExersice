using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;
        private GameManager gameManager;
        private Joystick joystick; // Reference to the joystick object

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            joystick = GameObject.FindObjectOfType<Joystick>(); // Assign the joystick reference
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void Update()
        {
            float moveInput = joystick.Horizontal; // Use joystick input instead of Input.GetAxisRaw("Horizontal")

            if (moveInput < 0)
            {
                MoveLeft();
            }
            else if (moveInput > 0)
            {
                MoveRight();
            }
            else
            {
                StopMoving();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }

        public void StopMoving()
        {
            animator.SetInteger("playerState", 0); // Turn on idle animation
        }

        private void MoveLeft()
        {
            Vector3 direction = transform.right * -1f;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetInteger("playerState", 1); // Turn on run animation

            if (facingRight)
            {
                Flip();
            }
        }

        private void MoveRight()
        {
            Vector3 direction = transform.right * 1f;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetInteger("playerState", 1); // Turn on run animation

            if (!facingRight)
            {
                Flip();
            }
        }

        public void Jump()
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }
            else
            {
                deathState = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
            }
        }
    }
}