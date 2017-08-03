using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamID : MonoBehaviour {

    public enum Teams { A, B, C };

    [SerializeField]
    private Teams thisTeam = Teams.A;

}
