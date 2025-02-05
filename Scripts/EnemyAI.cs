using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    public float moveSpeed;
    public Collider WeaponCollider;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (2.0f <= dist && dist < 12.0f)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttacking", false);

            transform.LookAt(player);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (dist < 2.0f)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isAttacking", false);
        }
    }
    void WeaponOn()
    {
        WeaponCollider.enabled = true;
    }
    void WeaponOff()
    {
        WeaponCollider.enabled = false;
    }

}
