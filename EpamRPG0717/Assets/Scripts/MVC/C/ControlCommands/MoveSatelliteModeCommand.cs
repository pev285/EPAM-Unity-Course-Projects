public class MoveSatelliteModeCommand : AbstractCommand{

    private SatelliteModel smodel;

    public MoveSatelliteModeCommand(SatelliteModel model) {
        this.smodel = model;
    }

    public override void Execute() {
        smodel.SatelliteMovementOn();
    }
}