using UnityEngine;

public class PigeonController : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the object moves left
    public float jumpForce = 5f; // Force applied when jumping
    public bool randomJumpHeight = false;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    private bool isAlive = true;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();

        // Automatically jump when the object is grounded
        if (isGrounded)
        {
            Jump();
        }
    }

    void MoveLeft()
    {
        if (isAlive)
        {
            // Set the velocity to move the object to the left
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y); // Maintain the current vertical velocity
        }
    }

    void Jump()
    {
        if (isAlive)
        {
            if (randomJumpHeight)
            {
                rb.AddForce(Vector2.up * Random.Range(jumpForce, jumpForce * 2), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            isGrounded = false; // Set grounded to false when jumping
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set grounded to true when touching the ground
        }

        // Check if the object collides with the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            isAlive = false;
            PlaySoundEffect(); // Play the sound effect
        }
    }

    private void PlaySoundEffect()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip); // Play the sound effect immediately
        }
    }
}
