public class RunForwardCommand : AbstractCommand{

    private CharacterModel cmodel;

    public RunForwardCommand(CharacterModel model) {
        this.cmodel = model;
    }

    public override void Execute() {
        cmodel.MoveForward();
    }
}