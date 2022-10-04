using UnityEngine;
using System.Collections;

/// <summary>
/// Attached to the Player gameobject
/// Controls the player movement and other behaviors like firing bullets and collision detections
/// </summary>
public class PlayerCtrl : MonoBehaviour 
{
	#region: PUBLIC VARIABLES
	public float moveSpeed;
	public float jumpForceY;
	public Transform groundCheck;
	public float doubleJumpDelay;
	#endregion

	#region: PRIVATE VARIABLES
	Rigidbody2D rb;
	Animator anim;
	SpriteRenderer sr;
	bool canDoubleJump;
	bool facingRight;

	[SerializeField]
	bool isGrounded;
	#endregion

	#region: MONOBEHAVIOR METHODS
	// Use this for initialization

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();

		if(sr.flipX)
			facingRight = true;
		else
			facingRight = false;
	}

	void Update () 
	{
		isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(isGrounded && rb.velocity.x == 0)
			anim.SetInteger("State",0);

		// MOVE LEFT
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			MoveLeft();
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			StopMoving();
		}

		// MOVE RIGHT
		if(Input.GetKey(KeyCode.RightArrow))
		{
			MoveRight();
		}
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			StopMoving();
		}
			
		// JUMP
		if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
		{
			Jump();
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) && canDoubleJump)
		{
			Jump();
		}
			
		HandleJumpAndFall();
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck.transform.position,0.02f);
	}
	#endregion

	#region: PRIVATE METHODS
	void ActivateDoubleJump()
	{
		canDoubleJump = true;
	}

	void MoveLeft()
	{	
		rb.velocity = new Vector2(-moveSpeed,rb.velocity.y);
		anim.SetInteger("State",1);
		sr.flipX = true;
	}
		
	void MoveRight()
	{
		rb.velocity = new Vector2(moveSpeed,rb.velocity.y);
		anim.SetInteger("State",1);
		sr.flipX = false;
	}
		
	void StopMoving()
	{
		rb.velocity = Vector2.zero;
		anim.SetInteger("State",0);
	}
		
	void Jump()
	{
		if(isGrounded)
		{
			rb.AddForce(new Vector2(0, jumpForceY));
			isGrounded = false;
			anim.SetInteger("State",2);
			Invoke("EnableDoubleJump", doubleJumpDelay);
		}

		if(canDoubleJump)
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(new Vector2(0, jumpForceY));
			anim.SetInteger("State",2);
			canDoubleJump = false;
		}
	}

	void EnableDoubleJump()
	{
		canDoubleJump = true;
	}
		
	void HandleJumpAndFall()
	{
		if(!isGrounded)
		{
			if(rb.velocity.y > 0)
			{
				anim.SetInteger("State",2);
			}
			if(rb.velocity.y < 0)
			{
				anim.SetInteger("State",3);
			}
		}
	}
	#endregion

	#region: COLLISIONS
	void OnCollisionEnter2D(Collision2D other)
	{
		switch (other.gameObject.tag) 
		{
		case "Ground":
			canDoubleJump = false;
			break;
		default:
			break;
		}
	}
	#endregion


}
