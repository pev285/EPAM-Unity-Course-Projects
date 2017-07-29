using UnityEngine;

public class TurnViewHorizontalCommand : AbstractCommand{

    private CharacterModel charModel;
    private SatelliteModel camModel;

    public TurnViewHorizontalCommand(CharacterModel model, SatelliteModel cameraModel) {
        this.charModel = model;
        this.camModel = cameraModel;
    }

    public override void Execute() {
        charModel.TurnHorizontal(Input.GetAxis("Mouse X"));
        camModel.TurnHorizontal(Input.GetAxis("Mouse X"));
    }


}