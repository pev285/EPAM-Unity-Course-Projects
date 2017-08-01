using System.Collections.Generic;
using UnityEngine;

public class InventoryModel {
    private List<InventorySlot> slots;

    [SerializeField]
    private int capacity = 10;

    public InventoryModel () {
        slots = new List<InventorySlot>(capacity);

        for (int i = 0; i < capacity; i++) {
            slots[i] = new InventorySlot();
        }
    }

    /*
    public ChangeCapacity(int cap) {
        if (cap > capacity) {
            for (int i = capacity; i < cap; i++) {
                ? change List capacity
                slots[i] = new InventorySlot();
            }
        } else if (cap < capacity) {
            for (int i = cap; i < capacity; i++) {
                slots[i] = null;
            }
            capacity = cap;
        }
    }

    public this[] (int index) {

    get;
    set;

    if (index >= 0 && index < capacity) {
        return slots[index].Item;
    }

    return null;
    }

*/

    public int Capacity {
        get {
            return capacity;
        }
    }

}