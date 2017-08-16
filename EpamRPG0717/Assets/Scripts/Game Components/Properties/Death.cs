using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{

    private Health health;


    private AbstractDeathVisualizer deathAnimator;


    [SerializeField]
    private bool isDead = false;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
        deathAnimator = GetComponent<AbstractDeathVisualizer>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && health.CurrentHP <= 0)
        {
            deathAnimator.Visualize();
            isDead = true;


            // Turn off animations // ////////////////////////
            Animator animator = GetComponent<Animator>();
            if (animator != null) {
                animator.enabled = false;
            }
            Animation animation = GetComponent<Animation>();
            if (animation != null) {
                animation.enabled = false;
            }
            ///////////////////////////////////////////////////
        }

        //*
         
        if (IsDead)
        {

            Component[] components = GetComponents<CharacterModel>();

            foreach (Component c in components)
            {
                GameObject.Destroy(c);
            }

            components = GetComponents<CharacterMover>();

            foreach (Component c in components)
            {
                GameObject.Destroy(c);
            }

        }

        // */

    } // Update() //


} // End Of Class //


