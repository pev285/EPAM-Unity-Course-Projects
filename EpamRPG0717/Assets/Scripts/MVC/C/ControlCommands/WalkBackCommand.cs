public class WalkBackCommand : AbstractCommand {

    private CharacterModel cmodel;

    public WalkBackCommand(CharacterModel model) {
        this.cmodel = model;
    }

    public override void Execute() {
        cmodel.MoveBackward();
    }
}