using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        if(!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        if(Input.GetButton("Horizontal"))
        {
            animator.SetBool("Walking", true);
        }
        else if(Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("Walking", false);
        }
        
    }
}
