using UnityEngine;

public class KeyboardCommandsLayout : ScriptableObject {


    [SerializeField]
    public AbstractCommand rightArrowCommand = AbstractCommand.noCommand;
    [SerializeField]
    public AbstractCommand leftArrowCommand = AbstractCommand.noCommand;
    [SerializeField]
    public AbstractCommand upArrowCommand = AbstractCommand.noCommand;
    [SerializeField]
    public AbstractCommand downArrowCommand = AbstractCommand.noCommand;

    public AbstractCommand mouse0Command = AbstractCommand.noCommand;
    public AbstractCommand mouse1Command = AbstractCommand.noCommand;
    public AbstractCommand mouse2Command = AbstractCommand.noCommand;
    public AbstractCommand mouseWheelRotationCommand = AbstractCommand.noCommand;

    public AbstractCommand mouseRotateHorizontalCommand = AbstractCommand.noCommand;
    public AbstractCommand mouseRotateVerticalCommand = AbstractCommand.noCommand;

    public AbstractCommand keyACommand = AbstractCommand.noCommand;
    public AbstractCommand keySCommand = AbstractCommand.noCommand;
    public AbstractCommand keyDCommand = AbstractCommand.noCommand;
    public AbstractCommand keyWCommand = AbstractCommand.noCommand;
    public AbstractCommand spaceCommand = AbstractCommand.noCommand;

    public AbstractCommand digit1Command = AbstractCommand.noCommand;
    public AbstractCommand digit2Command = AbstractCommand.noCommand;
    public AbstractCommand digit3Command = AbstractCommand.noCommand;
    public AbstractCommand digit4Command = AbstractCommand.noCommand;
    public AbstractCommand digit5Command = AbstractCommand.noCommand;
    public AbstractCommand digit6Command = AbstractCommand.noCommand;
    public AbstractCommand digit7Command = AbstractCommand.noCommand;
    public AbstractCommand digit8Command = AbstractCommand.noCommand;
    public AbstractCommand digit9Command = AbstractCommand.noCommand;
    public AbstractCommand digit0Command = AbstractCommand.noCommand;

    public AbstractCommand keypad1Command = AbstractCommand.noCommand;
    public AbstractCommand keypad2Command = AbstractCommand.noCommand;
    public AbstractCommand keypad3Command = AbstractCommand.noCommand;
    public AbstractCommand keypad4Command = AbstractCommand.noCommand;
    public AbstractCommand keypad5Command = AbstractCommand.noCommand;
    public AbstractCommand keypad6Command = AbstractCommand.noCommand;
    public AbstractCommand keypad7Command = AbstractCommand.noCommand;
    public AbstractCommand keypad8Command = AbstractCommand.noCommand;
    public AbstractCommand keypad9Command = AbstractCommand.noCommand;
    public AbstractCommand keypad0Command = AbstractCommand.noCommand;

    public AbstractCommand leftControlCommand = AbstractCommand.noCommand;
    public AbstractCommand rightControlCommand = AbstractCommand.noCommand;
    public AbstractCommand leftShiftCommand = AbstractCommand.noCommand;
    public AbstractCommand rightShiftCommand = AbstractCommand.noCommand;
    public AbstractCommand leftAltCommand = AbstractCommand.noCommand;
    public AbstractCommand rightAltCommand = AbstractCommand.noCommand;


}
