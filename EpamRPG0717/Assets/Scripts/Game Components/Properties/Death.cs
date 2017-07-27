using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{

    private Health health;


    private AbstractDeathVisualizer deathAnimator;


    [SerializeField]
    private bool isDead = false;

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
        }
    }


}
