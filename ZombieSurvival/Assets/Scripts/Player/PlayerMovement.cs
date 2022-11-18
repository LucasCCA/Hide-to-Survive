using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    Animator animator;

    StaminaSystem staminaSystem;

    [SerializeField] public DecreasePlayerSpeed decreasePlayerSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        staminaSystem = GetComponent<StaminaSystem>();
    }

    void Update()
    {
        Walk();
        Run();
    }

    void Walk()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        if (movement != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void Run()
    {
        if (Input.GetButton("Jump") && Input.GetButton("Horizontal"))
        {
            if (decreasePlayerSpeed == null || decreasePlayerSpeed.enabled == false)
            {
                if (staminaSystem.currentStamina > 0)
                {
                    speed = 6f;
                }
                else if (staminaSystem.currentStamina <= 0)
                {
                    speed = 3f;
                }
            }
            else if (decreasePlayerSpeed != null && decreasePlayerSpeed.enabled == true)
        {
                if (staminaSystem.currentStamina > 0)
                {
                    speed = 4f;
                }
                else if (staminaSystem.currentStamina <= 0)
                {
                    speed = 2f;
                }
            }
        }
        else if (Input.GetButtonUp("Jump") || Input.GetButtonUp("Horizontal"))
        {
            if (decreasePlayerSpeed == null || decreasePlayerSpeed.enabled == false)
            {
                speed = 3f;
            }
            else if (decreasePlayerSpeed != null && decreasePlayerSpeed.enabled == true)
        {
                speed = 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlowDown"))
        {
            decreasePlayerSpeed.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SlowDown"))
        {
            decreasePlayerSpeed.enabled = false;
        }
    }
}
