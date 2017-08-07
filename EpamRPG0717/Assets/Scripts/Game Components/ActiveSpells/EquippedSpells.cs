using System.Collections.Generic;
using UnityEngine;

public class EquippedSpells : MonoBehaviour {

    private List<AbstractSpell> spells = new List<AbstractSpell>();
    private int currentSpellIndex = 0;

    public void AddSpell(AbstractSpell spell) {
        spells.Add(spell);
    }

    public void RemoveSpellAt(int index) {
        spells.RemoveAt(index);
    }

    public AbstractSpell GetSpellAt(int index) {
        if ( 0 <= index && index < spells.Count) {
            return spells[index];
        } else {
            return null;
        }
    }

    public AbstractSpell GetCurrentSpell() {
        return  GetSpellAt(currentSpellIndex);
    }

    public void ShiftForward() {
        currentSpellIndex = (currentSpellIndex + 1) % spells.Count;
    }

    public void ShiftBackward() {
        currentSpellIndex = (spells.Count + currentSpellIndex - 1) % spells.Count;
    }


    void Update() {
//        EquippedSpellsView.Redraw(this);
    }
}
