using UnityEngine;

public class MouseWheelRotationCommand : AbstractCommand {

    private SatelliteModel camModel;

    public MouseWheelRotationCommand(SatelliteModel cameraModel) {
        this.camModel = cameraModel;
    }

    public override void Execute() {
        camModel.ChangeApproach(Input.GetAxis("Mouse ScrollWheel"));
    }

}