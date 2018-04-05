using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour {
    public float maxVel = 5f; //Max Speed when walking
    public float yJumpForce = 300f; //JumForce given when jumping

    private bool isjumpling = false;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 jumpforce;
    private bool movingRight = true;

    //public GameObject enemigo;
    public float health = 300f; //Health of our player
    public static float scoreMario = 0f; //Score of the player

    public AudioClip coin; //Music when colliding when coins
    public AudioClip jump; //Music when jumping

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Update horizontal speed
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rb.velocity.y);

        v *= maxVel;

        vel.x = v;

        rb.velocity = vel;

        //Change to walking animation when needed
        if (v != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //If player press jump
        if (Input.GetAxis("Salto") > 0.01f)
        {
            if (!isjumpling)
            {
                if (rb.velocity.y == 0)
                {
                    //if player jumped, we play animation for jumping
                    anim.SetBool("Salto", true); //Change animation when jumping

                    isjumpling = true;
                    //This 0 value is for the player to only go upside down
                    jumpforce.x = 0f;
                    //This will be a variable, the force in the jump will take it
                    jumpforce.y = yJumpForce;
                    //The rigidBody of the player object will take this force for moving
                    rb.AddForce(jumpforce);
                    //sound played when jumping
                    AudioSource.PlayClipAtPoint(jump, transform.position);
                }
            }
        }
        else
        {
            isjumpling = false;
        }
        if (movingRight && v < 0)
        {
            movingRight = false;
            Flip();
        }
        else if (!movingRight && v > 0)
        {
            movingRight = true;
            Flip();
        }

    }
    //method for flipping the sprite when going to opposite direction
    private void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

}

