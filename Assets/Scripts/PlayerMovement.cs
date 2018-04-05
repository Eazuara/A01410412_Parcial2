using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    // Movement Properties
    public Text countText;
    private int count;
    bool sliding = false;
    float slidetimer = 0f;
    public float maxSlideTime = 1.5f;
    public float moveSpeed = 15;
    public int lives;

    public float jumpForce = 1200;
    public Transform firePoint;
    public GameObject Beam;

    void Start()
    {
        count = 0;
        countText.text = "Points: " + count.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
    }

    bool IsGrounded()
    {


        // Get Bounds and Cast Range (10% of height)
        Bounds bounds = GetComponent<Collider2D>().bounds;
        float range = bounds.size.y * 0.1f;

        // Calculate a position slightly below the collider
        Vector2 v = new Vector2(bounds.center.x,
                                bounds.min.y - range);

        // Linecast upwards
        RaycastHit2D hit = Physics2D.Linecast(v, bounds.center);

        // Was there something in-between, or did we hit ourself?
        return (hit.collider.gameObject != gameObject);
    }

    void FixedUpdate()
    {
        // Horizontal Movement
        float h = Input.GetAxis("Horizontal");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        if (h != 0)
        {
            // Move Left/Right
            GetComponent<Rigidbody2D>().velocity = new Vector2(h * moveSpeed, v.y);
            transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);

            GetComponent<Animator>().SetFloat("Correr", Mathf.Abs(h));

            // Vertical Movement (Jumping)
            bool grounded = IsGrounded();
            if (Input.GetKey(KeyCode.UpArrow) && grounded)
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);

            GetComponent<Animator>().SetBool("Salto", !grounded);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Beam, firePoint.position, firePoint.rotation);
            }
            if (Input.GetButtonDown("Slide") && !sliding)
            {
                slidetimer = 0f;

                GetComponent<Animator>().SetBool("isSliding", true);

                sliding = true;
            }
            if (sliding)
            {
                slidetimer += Time.deltaTime;
                if (slidetimer > maxSlideTime)
                {
                    sliding = false;
                    GetComponent<Animator>().SetBool("isSliding", false);
                }
            }
        }
    }
   
}