using System.Collections.Generic;
using UnityEngine;

public class CommonGameUnitFactory {

    private Dictionary<Identification.UnitType, AbstractGameUnitCreator> creators;

    public CommonGameUnitFactory() {
        creators = new Dictionary<Identification.UnitType, AbstractGameUnitCreator>();
    }

    public AbstractGameUnit CreateGameUnit(Identification.UnitType type, Vector3 position) {
        AbstractGameUnitCreator creator = creators[type];

        if (creator == null) {
            return null;
        } else {
            return creator.CreateGameUnit(position);
        }
    }

    public void AddCreator(Identification.UnitType type, AbstractGameUnitCreator creator) {
        creators.Add(type, creator);
    }

}