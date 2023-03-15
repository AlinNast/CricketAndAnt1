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

	[Tooltip("This a a slot for feet component")]
	public Transform feet;

	[Tooltip("positive int to expand feet collision area")]
	public float feetRadius;


	public GameObject GarbageCollector;


    [Tooltip("i forgot what this is")]
    public LayerMask whatIsGround;

    [Tooltip("i forgot what this is")]
    public float boxWidth;
	public float boxHeight;


	public bool SFXon;

	public bool canFire;

	// is true if collision with ground taged tiles and feet component of player
	bool isGrounded;

	// used to check for double jumps
	public bool isJumping;

	public bool isStuck;
	// for mobile controlls
	public bool leftPressed;
	public bool rightPressed;
	bool jumpPressed;
	bool shootPressed;

	
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
		// ground colliesion
		isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth, boxHeight), 360.0f, whatIsGround);

		// player speed
		float playerSpeed = Input.GetAxisRaw("Horizontal"); // value will be -1, 1 or 0
		if (isJumping)
		{
			playerSpeed *= speedBoost * 2;
		}
		else
		{
            playerSpeed *= speedBoost;
        }

        // key controlls
        if (playerSpeed != 0)
        {
			MoveHorizontal(playerSpeed);
        }
        else
        {
			//StopMove();
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

		// button controlls
		if (leftPressed)
		{
            if (isJumping)
			{
                MoveHorizontal(-speedBoost *2);
            }
			else
			{
                MoveHorizontal(-speedBoost);
            }
			
		}
        if (rightPressed)
        {
            if (isJumping)
            {
                MoveHorizontal(speedBoost * 2);
            }
            else
            {
                MoveHorizontal(speedBoost);
            }
        }
		if (jumpPressed)
		{
            jumpPressed = false;
			Jump();
		}
		if (shootPressed)
		{
            shootPressed = false;
            FireBullets();
        }
    }

	// player actual controlls
	/// <summary>
	/// Moves the player on the x axis
	/// </summary>
	/// <param name="playerSpeed"></param>
	void MoveHorizontal(float playerSpeed)
    {
		rigidBody.velocity = new Vector2(playerSpeed, rigidBody.velocity.y);

		if(playerSpeed < 0)
		{
			spriteRenderer.flipX = false;
		}
		else if(playerSpeed > 0)
		{
			spriteRenderer.flipX=true;
		}

		if (!isJumping)
		{
            animator.SetInteger("State", 1);
        }


    }

	/// <summary>
	/// makes the player stop
	/// </summary>
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
			AudioController.Instance.PlayerJump(transform.position);
            rigidBody.AddForce(new Vector2(rigidBody.velocity.x, jumpSpeed));
            isJumping = true;
            animator.SetInteger("State", 2);
        }
    }

	/// <summary>
	/// checks if player is falling and show propper animation
	/// </summary>
	void Fall()
	{
		if (!isGrounded && rigidBody.velocity.y < 0)
		{
            animator.SetInteger("State", 3);
        }
    }

	/// <summary>
	/// Makes the player shoot
	/// </summary>
	void FireBullets()
	{
		if (canFire)
		{
			Debug.Log("note");
        }
		else
		{
			Debug.Log("cry");
		}
	
    }


	// Mobile controlls
	public void MobileMoveLeft()
	{
        leftPressed = true;
	}
	public void MobileMoveRight() 
	{
        rightPressed = true;
	}

	public void MobileStop()
	{
        leftPressed = false;
		rightPressed = false;
		StopMove();
	}

	public void MobileJump()
	{
        jumpPressed = true;
	}

	public void MobileShoot()
	{
		shootPressed = true;
	}


	/// <summary>
	/// Sets isJumping to false on collision with ground objects
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			GameCtrl.instance.PlayerDiedAnimation(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		switch (collider.gameObject.tag)
		{
			case "Coin":
				if (SFXon)
					SFXCtrl.Instance.ShowCoinSparkle(collider.gameObject.transform.position);
				break;

			case "Violin":
				canFire = true;
				Vector3 violinPos = collider.gameObject.transform.position;
				Destroy(collider.gameObject);
                if (SFXon)
                    SFXCtrl.Instance.ShowViolinSparckle(violinPos);
				break;

			case "Water":
				//GarbageCollector.SetActive(false);
				if (SFXon)
				{
					SFXCtrl.Instance.ShowWaterSplash(collider.gameObject.transform.position);
                    AudioController.Instance.Splash(transform.position);
				}
				//this next line might be buggi
                GameCtrl.instance.PlayerDrowned(transform.gameObject);
                break;

			default:
				break;
		}
	}

		
}
