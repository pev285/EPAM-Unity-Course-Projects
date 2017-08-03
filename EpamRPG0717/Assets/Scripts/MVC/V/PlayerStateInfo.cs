using System.Text;
using UnityEngine;

public class PlayerStateInfo : MonoBehaviour{

    private EquippedSpells spells;

    void Start() {
        spells = gameObject.GetComponent<EquippedSpells>();
        if (spells == null) {
            print("Spells are null");
        }
    }

    enum TestEnum {aaaa, bbbb, cccc};

    void Update() {
        StringBuilder sb = new StringBuilder();
        sb.Append("Current Spell: ");
        sb.Append(spells.GetCurrentSpell().Name);//.Append(": ").Append(spells.GetCurrentSpell().Description);
        sb.Append("\n");
        sb.Append("mouseX:").Append(Input.GetAxis("Mouse X")).Append( ",  mouseY:");
        sb.Append(Input.GetAxis("Mouse Y"));
        Messaging.SetTechInfoText(sb.ToString());

//        print(TestEnum.aaaa.ToString());
    }
}
