public class PauseGameCommand : AbstractCommand {



    public override void Execute() {
        GlobalGameSettings.Instance.Pause();
    }
}