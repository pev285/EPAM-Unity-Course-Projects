using System.Text;
using UnityEngine;

public class InputReader : MonoBehaviour {

//    [SerializeField]
//    private GameObject player;
//
//    [SerializeField]
//    private GameObject playerCamera;
//
//    [SerializeField]
//    private GameObject targetingPoint;
//
//    private CharacterModel characterModel;
//    private SatelliteModel cameraModel;


    ////////////////////////////////////////////////////////////




//    [SerializeField]
//    private float moveAmount = 0;
//    [SerializeField]
//    private float rotationAmount = 0;
//    [SerializeField]
//    private float cameraAloneRotationAmount = 0;
//    [SerializeField]
//    private float cameraVerticalRotationAmount = 0;
//    [SerializeField]
//    private float stepAside = 0;
//

//    private AbstractCommand spellCommand;
//    private EquippedSpells spells;

//    private AbstractCommand rightArrowCommand = AbstractCommand.noCommand;
//    private AbstractCommand leftArrowCommand = AbstractCommand.noCommand;
//    private AbstractCommand upArrowCommand = AbstractCommand.noCommand;
//    private AbstractCommand downArrowCommand = AbstractCommand.noCommand;
//
//    private AbstractCommand mouse0Command = AbstractCommand.noCommand;
//    private AbstractCommand mouse1Command = AbstractCommand.noCommand;
//    private AbstractCommand mouse2Command = AbstractCommand.noCommand;
//    private AbstractCommand mouseWheelRotationCommand = AbstractCommand.noCommand;
//
//    private AbstractCommand mouseRotateHorizontalCommand = AbstractCommand.noCommand;
//    private AbstractCommand mouseRotateVerticalCommand = AbstractCommand.noCommand;
//
//    private AbstractCommand keyACommand = AbstractCommand.noCommand;
//    private AbstractCommand keySCommand = AbstractCommand.noCommand;
//    private AbstractCommand keyDCommand = AbstractCommand.noCommand;
//    private AbstractCommand keyWCommand = AbstractCommand.noCommand;
//    private AbstractCommand spaceCommand = AbstractCommand.noCommand;
//
//    private AbstractCommand digit1Command = AbstractCommand.noCommand;
//    private AbstractCommand digit2Command = AbstractCommand.noCommand;
//    private AbstractCommand digit3Command = AbstractCommand.noCommand;
//    private AbstractCommand digit4Command = AbstractCommand.noCommand;
//    private AbstractCommand digit5Command = AbstractCommand.noCommand;
//    private AbstractCommand digit6Command = AbstractCommand.noCommand;
//    private AbstractCommand digit7Command = AbstractCommand.noCommand;
//    private AbstractCommand digit8Command = AbstractCommand.noCommand;
//    private AbstractCommand digit9Command = AbstractCommand.noCommand;
//    private AbstractCommand digit0Command = AbstractCommand.noCommand;
//
//    private AbstractCommand keypad1Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad2Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad3Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad4Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad5Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad6Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad7Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad8Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad9Command = AbstractCommand.noCommand;
//    private AbstractCommand keypad0Command = AbstractCommand.noCommand;
//
//    private AbstractCommand leftControlCommand = AbstractCommand.noCommand;
//    private AbstractCommand rightControlCommand = AbstractCommand.noCommand;
//    private AbstractCommand leftShiftCommand = AbstractCommand.noCommand;
//    private AbstractCommand rightShiftCommand = AbstractCommand.noCommand;
//    private AbstractCommand leftAltCommand = AbstractCommand.noCommand;
//    private AbstractCommand rightAltCommand = AbstractCommand.noCommand;


//    [SerializeField]
//    private GameObject stonePrefab;
//    [SerializeField]
//    private GameObject arrowPrefab;
//    [SerializeField]
//    private GameObject magnetPrefab;

// Use this for initialization
	void Start () {
//		characterModel = player.GetComponent<CharacterModel>();
//        cameraModel = playerCamera.GetComponent<SatelliteModel>();
//
//
//        /////////////////////////////
////        AbstractSpell spell = player.GetComponent<AbstractSpell>();
//
//        spells = player.GetComponent<EquippedSpells>();
//
//        spells.AddSpell(new SimpleDistantSpell(new BowShotAction(arrowPrefab)));
//        spells.AddSpell(new SimpleDistantSpell(new StoneThrowingAction(stonePrefab)));
//        spells.AddSpell(new SimpleDistantSpell(new WindSpellAction()));
//        spells.AddSpell(new SimpleDistantSpell(new MagnetoSpellAction(magnetPrefab)));
        ///////


//        InitiateGameCommands();
	}

//    private void InitiateGameCommands() {
//
//        // Spell choose and cast //
//        leftArrowCommand = new PreviousSpellCommand(spells);
//        rightArrowCommand = new NextSpellCommand(spells);
//        mouse0Command = new CastCurrentSpellCommand(player, playerCamera, targetingPoint, spells);
//
//        // Character movement //
//        keyACommand = new WalkLeftCommand(characterModel);
//        keyDCommand = new WalkRightCommand(characterModel);
//        keySCommand = new WalkBackCommand(characterModel);
//        keyWCommand = new RunForwardCommand(characterModel);
//
//        spaceCommand = new JumpCommand(characterModel);
//
//        // Horizontal and vertical rotation //
//        mouseRotateHorizontalCommand = new TurnViewHorizontalCommand(characterModel, cameraModel);
//        mouseRotateVerticalCommand = new TurnViewVerticalCommand(characterModel, cameraModel);
//
//        // Rotate camera but not character //
//        rightControlCommand = new MoveSatelliteModeCommand(cameraModel);
//
//        // Set camera default position //
//        keypad5Command = new CameraDefaultPositionCommand(cameraModel);
//        mouse2Command = keypad5Command;
//
//        // Change distance from camera to character //
//        mouseWheelRotationCommand = new MouseWheelRotationCommand(cameraModel);
//
//        digit0Command = new PauseGameCommand();
//    }


	// Update is called once per frame
	void Update () {

//        // -----------------------------------------------------------
//        Component[] spells = GetComponents(typeof(AbstractSpell));
//        StringBuilder sb = new StringBuilder();
//        foreach(Component spl in spells) {
//            sb.Append(spl.GetType().Name).Append(", ");
//        }
//        Messaging.SetTopText(sb.ToString());
//        //----------------------------------------------------



        InputProccessing();


	}


    private void InputProccessing() {



        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            GlobalGameSettings.Instance.KeyboardCommands.mouse0Command.Execute();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            GlobalGameSettings.Instance.KeyboardCommands.mouse1Command.Execute();
        }
        if (Input.GetKeyDown(KeyCode.Mouse2)) {
            GlobalGameSettings.Instance.KeyboardCommands.mouse2Command.Execute();
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            GlobalGameSettings.Instance.KeyboardCommands.leftArrowCommand.Execute();
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            GlobalGameSettings.Instance.KeyboardCommands.rightArrowCommand.Execute();
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            GlobalGameSettings.Instance.KeyboardCommands.upArrowCommand.Execute();
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            GlobalGameSettings.Instance.KeyboardCommands.downArrowCommand.Execute();
        }
        if (Input.GetKey(KeyCode.W)) {
            GlobalGameSettings.Instance.KeyboardCommands.keyWCommand.Execute();
        }
        if (Input.GetKey(KeyCode.A)) {
            GlobalGameSettings.Instance.KeyboardCommands.keyACommand.Execute();
        }
        if (Input.GetKey(KeyCode.S)) {
            GlobalGameSettings.Instance.KeyboardCommands.keySCommand.Execute();
        }
        if (Input.GetKey(KeyCode.D)) {
            GlobalGameSettings.Instance.KeyboardCommands.keyDCommand.Execute();
        }
        if (Input.GetKey(KeyCode.Space)) {
            GlobalGameSettings.Instance.KeyboardCommands.spaceCommand.Execute();
        }

        if (Input.GetKey(KeyCode.Alpha0)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit0Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha1)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit1Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha2)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit2Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha3)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit3Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha4)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit4Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha5)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit5Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha6)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit6Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha7)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit7Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha8)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit8Command.Execute();
        }
        if (Input.GetKey(KeyCode.Alpha9)) {
            GlobalGameSettings.Instance.KeyboardCommands.digit9Command.Execute();
        }

        if (Input.GetKey(KeyCode.Keypad0)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad0Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad1)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad1Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad2)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad2Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad3)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad3Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad4)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad4Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad5)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad5Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad6)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad6Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad7)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad7Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad8)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad8Command.Execute();
        }
        if (Input.GetKey(KeyCode.Keypad9)) {
            GlobalGameSettings.Instance.KeyboardCommands.keypad9Command.Execute();
        }

        if (Input.GetKey(KeyCode.LeftAlt)) {
            GlobalGameSettings.Instance.KeyboardCommands.leftAltCommand.Execute();
        }
        if (Input.GetKey(KeyCode.RightAlt)) {
            GlobalGameSettings.Instance.KeyboardCommands.rightAltCommand.Execute();
        }
        if (Input.GetKey(KeyCode.LeftControl)) {
            GlobalGameSettings.Instance.KeyboardCommands.leftControlCommand.Execute();
        }
        if (Input.GetKey(KeyCode.RightControl)) {
            GlobalGameSettings.Instance.KeyboardCommands.rightControlCommand.Execute();
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            GlobalGameSettings.Instance.KeyboardCommands.leftShiftCommand.Execute();
        }
        if (Input.GetKey(KeyCode.RightShift)) {
            GlobalGameSettings.Instance.KeyboardCommands.rightShiftCommand.Execute();
        }






//        print(Input.GetAxis("Mouse X") + "---" + Input.GetAxis("Mouse X") + "---" + Input.GetAxis("Mouse X"));
//        if (Input.GetAxis("Mouse X") != 0) {
        GlobalGameSettings.Instance.KeyboardCommands.mouseRotateHorizontalCommand.Execute();
//        }
//        if(Input.GetAxis("Mouse Y") != 0) {
        GlobalGameSettings.Instance.KeyboardCommands.mouseRotateVerticalCommand.Execute();
//        }

        GlobalGameSettings.Instance.KeyboardCommands.mouseWheelRotationCommand.Execute();

    } // InputProcessing() //



} // InputReader //


