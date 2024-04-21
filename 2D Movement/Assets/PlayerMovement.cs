using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    private void Update()
    {
        // Get horizontal movement input
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed; 

        // Check if jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // Check if crouch button is pressed or released
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        // Move the character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
