public class WalkLeftCommand : AbstractCommand {

    private CharacterModel cmodel;

    public WalkLeftCommand(CharacterModel model) {
        this.cmodel = model;
    }

    public override void Execute() {
        cmodel.MoveLeft();
    }
}