using System.Text;
using UnityEngine;

public class PlayerStateInfo : MonoBehaviour{

    private EquippedSpells spells;
    private Health health;


    public void SetInfoSource(GameObject player) {
        this.spells = player.GetComponent<EquippedSpells>();;
        this.health = player.GetComponent<Health>();
    }


    void Update() {
        StringBuilder sb = new StringBuilder();
        sb.Append("Health: ").Append(health.CurrentHP).Append(" of ").Append(health.MaxHP);
        sb.Append("\n");
        sb.Append("Current Spell: ");
        sb.Append(spells.GetCurrentSpell().Name);//.Append(": ").Append(spells.GetCurrentSpell().Description);
        sb.Append("\n");
        sb.Append("mouseX:").Append(Input.GetAxis("Mouse X")).Append( ",  mouseY:");
        sb.Append(Input.GetAxis("Mouse Y"));
        Messaging.SetTechInfoText(sb.ToString());

//        print(TestEnum.aaaa.ToString());
    }
}
