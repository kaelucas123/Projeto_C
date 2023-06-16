using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_walk : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;
    [SerializeField] float Speed; 
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Verifique se o personagem está se movendo horizontalmente
        if (horizontal < 0)
        {
            // Inverta a escala no eixo X para que o personagem vire para a esquerda
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            // Mantenha a escala no eixo X como padrão para que o personagem fique virado para a direita
            spriteRenderer.flipX = false;
        }

        if(rb.velocity.magnitude > 0)
        {
            animator.Play("run");
        }
        else
        {
            animator.Play("idle");
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, vertical * Speed);
    }
}
