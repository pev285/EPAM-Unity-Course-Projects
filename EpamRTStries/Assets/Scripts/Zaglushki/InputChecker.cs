using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour {


    private float mouseSpeed = 1;
    private float mouseWheelSpeed = 3;


	// Use this for initialization
	void Start () {
	}

    [SerializeField]
    private CameraMover cameraMover;

    [SerializeField]
    private int currentUnitTypeIndex = 0;

	// Update is called once per frame
	void Update () {

        cameraMover.ShiftX( Input.GetAxis( "Mouse X") * mouseSpeed );
        cameraMover.ShiftZ( Input.GetAxis( "Mouse Y") * mouseSpeed );
        cameraMover.ShiftY( -Input.GetAxis("Mouse ScrollWheel") * mouseWheelSpeed );



        if (Input.GetMouseButtonDown(0))
        {
            CreateCurrentUnit(GameManager.Instance.HumanArmyManager);
        }



        if (Input.GetMouseButtonDown(1))
        {
            CreateCurrentUnit(GameManager.Instance.OrcArmyManager);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            currentUnitTypeIndex = (currentUnitTypeIndex + 1) % 5;
        }

    } // Update //


    private void CreateCurrentUnit(ArmyManager armyManager) {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            GameUnitID unitId = hit.collider.gameObject.GetComponent<GameUnitID>();

            if (unitId != null) {
                if (unitId.Army == Identification.Army.Humans) {
                    AbstractGameUnit unit = GameManager.Instance.HumanArmyManager.FindGameUnit(unitId.PersonalID);
                    HUDscript.Message("You clicked:: " + unit.Description);
                } else {

                }

            } else {

                print("Hitpoint=" + hit.point);

                AbstractGameUnit unit = null;

                switch (currentUnitTypeIndex) {
                    case 0:
                        unit = armyManager.CreateWarrior(Identification.UnitType.Archer, hit.point);
                        break;
                    case 1:
                        unit = armyManager.CreateWarrior(Identification.UnitType.Swordsman, hit.point);
                        break;
                    case 2:
                        unit = armyManager.CreateWarrior(Identification.UnitType.Horseman, hit.point);
                        break;
                    case 3:
                        unit = armyManager.CreateBuilding(Identification.UnitType.Palace, hit.point);
                        break;
                    case 4:
                        unit = armyManager.CreateBuilding(Identification.UnitType.Barrack, hit.point);
                        break;
                }


                HUDscript.Message("Created: " + unit.Description);
            }



        } // if raycast //

    } // Create current unit //

}
