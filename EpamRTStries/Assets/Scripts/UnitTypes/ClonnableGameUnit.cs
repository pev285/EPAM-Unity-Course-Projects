﻿using System;
using UnityEngine;

[System.Serializable]
public class ClonnableGameUnit : AbstractGameUnit {

    [SerializeField]
    private int id;
    public override int ID {
        get {
            return id;
        }
        set {
            id = value;
        }
    }

    [SerializeField]
    private string description;
    public override string Description {
        get {
            return description;
        }
        set {
            description = value;
        }
    }


    [SerializeField]
    private float currentHP;
    public override float CurrentHP {
        get {
            return currentHP;
        }
    }


    [SerializeField]
    private float currentMP;
    public override float CurrentMP {
        get {
            return currentMP;
        }
    }



    [SerializeField]
    private GameUnitCharacteristics characteristics;
    public override GameUnitCharacteristics Characteristics {
        get {
            return characteristics;
        }
    }


    [SerializeField]
    private GameObject avatar;
	public override UnityEngine.GameObject Avatar {
		get {
			return avatar;
		}
	}

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private ClonnableGameUnit(int id, string descr, GameUnitCharacteristics characteristics, GameObject avatar) {

        this.id = id;
        this.description = descr;
        this.characteristics = characteristics;

        this.avatar = avatar;

        this.currentHP = this.characteristics.MaxHP;
        this.currentMP = this.characteristics.MaxMP;
    }


    /**
    * All clones refer to the same GameUnitCharacteristics instance
    * Each clone has its own avatar instance
     */
    public ClonnableGameUnit CreateClone(Vector3 position, int id = 0, string descr = "") {

        GameObject newAvatar = GameObject.Instantiate(this.Avatar, position, this.Avatar.transform.rotation);

        return new ClonnableGameUnit(id, descr, characteristics, newAvatar);

    }

    /**
    * Creates copy of prototype with the same avatar GameObject,
    * but with different instance of GameUnitCharacteristics
     */
    public ClonnableGameUnit CreateCopy() {

        GameUnitCharacteristics characteristicsCopy = characteristics.CreateCopy();

        return new ClonnableGameUnit(id, description, characteristicsCopy, avatar);
    }


}
