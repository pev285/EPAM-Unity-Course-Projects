public abstract class AbstractCommand {

    public static ThereIsNoCommand noCommand = new ThereIsNoCommand();

    public abstract void Execute();

}
