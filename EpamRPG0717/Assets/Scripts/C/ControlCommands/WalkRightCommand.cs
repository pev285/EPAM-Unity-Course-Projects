public class WalkRightCommand : AbstractCommand{

    private CharacterModel cmodel;

    public WalkRightCommand(CharacterModel model) {
        this.cmodel = model;
    }

    public override void Execute() {
        cmodel.MoveRight();
    }
}