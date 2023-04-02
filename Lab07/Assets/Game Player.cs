using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 200f;

    private Animator animator;
    private Rigidbody rigidbody;
    private float verticalInput;
    private float horizontalInput;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(verticalInput));
        animator.SetBool("IsTurningLeft", false);
        animator.SetBool("IsTurningRight", false);

        if (Mathf.Approximately(verticalInput, 0f))
        {
            if (horizontalInput < 0f)
            {
                animator.SetBool("IsTurningLeft", true);
            }
            else if (horizontalInput > 0f)
            {
                animator.SetBool("IsTurningRight", true);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
        rigidbody.MovePosition(transform.position + transform.TransformDirection(movement));
        
        if (Mathf.Approximately(horizontalInput, 0f))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.fixedDeltaTime * Mathf.Sign(verticalInput));
        }
        else
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.fixedDeltaTime * Mathf.Sign(horizontalInput));
        }    
}
}
