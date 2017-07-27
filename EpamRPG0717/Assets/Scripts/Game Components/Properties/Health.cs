using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int currentHP;

    public int MaxHP
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

    public int CurrentHP
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

    public void ChangeHealthBy(int points)
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
