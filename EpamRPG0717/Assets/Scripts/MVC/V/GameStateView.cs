using System.Text;
using UnityEngine;

public class GameStateView : MonoBehaviour{

    private EquippedSpells spells;

    void Start() {
        spells = gameObject.GetComponent<EquippedSpells>();
        if (spells == null) {
            print("Spells are null");
        }
    }


    void Update() {
        StringBuilder sb = new StringBuilder();
        sb.Append("Current Spell: ");
        sb.Append(spells.GetCurrentSpell().Name);//.Append(": ").Append(spells.GetCurrentSpell().Description);
        sb.Append("\n");
        sb.Append("mouseX:").Append(Input.GetAxis("Mouse X")).Append( ",  mouseY:");
        sb.Append(Input.GetAxis("Mouse Y"));
        Messaging.SetTechInfoText(sb.ToString());
    }
}
