using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class UserControlledMovement : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody2D m_RigidBody2D;

    // constants
    public float MOVEMENT_FORCE_MULTIPLIER = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Moves the gameobject based on the input from the user.
    void ApplyMovementFromInput()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");
        Vector2 movement_vector = new Vector2(horizontal_input, vertical_input);
        m_Animator.SetFloat("Horizontal", horizontal_input);
        m_Animator.SetFloat("Vertical", vertical_input);
        m_Animator.SetFloat("Speed", movement_vector.sqrMagnitude);

        m_RigidBody2D.MovePosition(m_RigidBody2D.position + movement_vector * MOVEMENT_FORCE_MULTIPLIER * Time.deltaTime);
    }

    void FixedUpdate()
    {
        ApplyMovementFromInput();
    }
}
