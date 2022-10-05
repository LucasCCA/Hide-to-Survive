using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    Animator animator;

    StaminaSystem staminaSystem;

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
        if(Input.GetButton("Jump") && Input.GetButton("Horizontal"))
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
        else if(Input.GetButtonUp("Jump"))
        {
            speed = 3f;
        }
    }
}
