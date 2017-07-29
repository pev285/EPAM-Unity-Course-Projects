using UnityEngine;

public class TurnViewVerticalCommand : AbstractCommand {

    private CharacterModel charModel;
    private SatelliteModel camModel;

    public TurnViewVerticalCommand(CharacterModel model, SatelliteModel cameraModel) {
        this.charModel = model;
        this.camModel = cameraModel;
    }

    public override void Execute() {
        charModel.TurnVertical(Input.GetAxis("Mouse Y"));
        camModel.TurnVertical(Input.GetAxis("Mouse Y"));
    }

}