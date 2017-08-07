
using UnityEngine;

public class FriendOrFoe {

    public static bool IsAFriend(GameObject go1, GameObject go2)
    {
        return go1.GetComponent<TeamID>().ThisTeam == go2.GetComponent<TeamID>().ThisTeam;
    }

}
