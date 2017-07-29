using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private float maxHP = 100;
    [SerializeField]
    private float currentHP;

    public float MaxHP
    {
        get
        {
            return maxHP;
        }

        set
        {
            maxHP = value;
        }
    }

    public float CurrentHP
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;
        }
    }

    public void ChangeHealthBy(float points)
    {
        CurrentHP += points;
        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        } else if (CurrentHP < 0)
        {
            CurrentHP = 0;
        }
    }


	// Use this for initialization
	void Start () {
        CurrentHP = MaxHP;
	}
	


	// Update is called once per frame
	void Update () {
		
	}
}
