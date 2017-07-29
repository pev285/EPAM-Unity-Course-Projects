public class JumpCommand : AbstractCommand {

    private CharacterModel cmodel;

    public JumpCommand(CharacterModel model) {
        this.cmodel = model;
    }

    public override void Execute() {
        cmodel.Jump();
    }

}