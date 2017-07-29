public class CameraDefaultPositionCommand : AbstractCommand {

    private SatelliteModel camModel;

    public CameraDefaultPositionCommand(SatelliteModel cameraModel) {
        this.camModel = cameraModel;
    }

    public override void Execute() {
        camModel.SetSatelliteDefaults();
    }

}