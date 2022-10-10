using UnityEngine;
//using UnityEngine.Physics2DModule;
using System.Collections;

/// <summary>
/// Attached to the Player gameobject
/// Controls the player movement and other behaviors like firing bullets and collision detections
/// </summary>
public class PlayerCtrl : MonoBehaviour 
{
	[Tooltip("This is a positive int which affects the movement speed of the player")]
	public int speedBoost;

	[Tooltip("This is a positive int wich affects the movement speed of the jump")]
	public int jumpSpeed;

	public Transform feet;

	public float feetRadius;
	public GameObject leftBullet, rightBullet;

	public Transform leftBulletSpownPos;
	public Transform rightBulletSpownPos;

	public LayerMask whatIsGround;

	public float boxWidth;
	public float boxHeight;

	bool isGrounded;

	bool isJumping;

	Rigidbody2D rigidBody;

	SpriteRenderer spriteRenderer;

	/// <summary>
	/// State: 0-idle, 1-run, 2-jump, 3-fall, -1-hurt
	/// </summary>
	Animator animator;

	void Start()
    {
		rigidBody = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
    }

	/// <summary>
    /// This method is called every frame of the game
    /// </summary>
	void Update()
    {
		isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth, boxHeight), 360.0f, whatIsGround);

		float playerSpeed = Input.GetAxisRaw("Horizontal"); // value will be -1, 1 or 0
		playerSpeed *= speedBoost;

		if(playerSpeed != 0)
        {
			MoveHorizontal(playerSpeed);
        }
        else
        {
			StopMove();
        }

		if (Input.GetButtonDown("Jump"))
		{
			Jump();
		}

		if (Input.GetButtonDown("Fire1"))
		{
			FireBullets();
		}

		Fall();
    }

	/// <summary>
	/// Moves the player on the x axis
	/// </summary>
	/// <param name="playerSpeed"></param>
	void MoveHorizontal(float playerSpeed)
    {
		rigidBody.velocity = new Vector2(playerSpeed, rigidBody.velocity.y);

		if(playerSpeed < 0)
		{
			spriteRenderer.flipX = true;
		}
		else if(playerSpeed > 0)
		{
			spriteRenderer.flipX=false;
		}

		if (!isJumping)
		{
            animator.SetInteger("State", 1);
        }


    }


	void StopMove()
    {
		rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        if (!isJumping)
		{
            animator.SetInteger("State", 0);
        }
    }
	
	/// <summary>
	/// Makes the player jump on the y axis
	/// </summary>
	void Jump()
	{
		if (isGrounded)
		{
            
            rigidBody.AddForce(new Vector2(rigidBody.velocity.x, jumpSpeed));
            isJumping = true;
            animator.SetInteger("State", 2);
        }
    }

	void Fall()
	{
		if (!isGrounded && rigidBody.velocity.y < 0)
		{
            animator.SetInteger("State", 3);
        }
    }

	void FireBullets()
	{
		if (spriteRenderer.flipX)
			Instantiate(leftBullet, leftBulletSpownPos.position, Quaternion.identity);
        if (!spriteRenderer.flipX)
            Instantiate(rightBullet, rightBulletSpownPos.position, Quaternion.identity);
    }

	/// <summary>
	/// Sets isJumping to false on collision with ground objects
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isJumping= false;
		}
	}

	/// <summary>
	/// This draws a sphere on the feet componentf for visual debuging
	/// </summary>
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight, 0));
	}
}
