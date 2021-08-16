using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Animator animator;
    public bool stunned;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isHurt", true);
            stunned = true;
        }
        else
        {
            animator.SetBool("isHurt", false);
        }
    }
}
