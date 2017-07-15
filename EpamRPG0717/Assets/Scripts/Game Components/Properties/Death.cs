using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{

    private Health health;
    private IAnimator animator;
    private bool isDead;

    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
        animator = GetComponent<IAnimator>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && health.CurrentHP <= 0)
        {
            animator.Die();
            isDead = true;
        }
    }
}
