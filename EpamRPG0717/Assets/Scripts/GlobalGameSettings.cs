using UnityEngine;

public class GlobalGameSettings : ScriptableObject {

    [SerializeField]
    private static GlobalGameSettings _instance;

    public static GlobalGameSettings Instance {
        get {
            if (_instance == null) {
                _instance = new GlobalGameSettings();
            }
            return _instance;
        }
    }

    // *********************************************************************** //

    private EquippedSpells spells;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject playerCamera;

    [SerializeField]
    private GameObject targetingPoint;

    private CharacterModel characterModel;
    private SatelliteModel cameraModel;


    [SerializeField]
    private GameObject stonePrefab;
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private GameObject magnetPrefab;


    private GlobalGameSettings() {

        // ***
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("PlayerCamera");
        targetingPoint = GameObject.Find("TargetPoint");
        stonePrefab = GameObject.Find("StonePrefab");
        arrowPrefab = GameObject.Find("ArrowPrefab");
        magnetPrefab = GameObject.Find("MagnetPrefab");
        // ***

        characterModel = player.GetComponent<CharacterModel>();
        cameraModel = playerCamera.GetComponent<SatelliteModel>();


/////////////////////////////
//        AbstractSpell spell = player.GetComponent<AbstractSpell>();

        spells = player.GetComponent<EquippedSpells>();

        spells.AddSpell(new SimpleDistantSpell(new BowShotAction(arrowPrefab)));
        spells.AddSpell(new SimpleDistantSpell(new StoneThrowingAction(stonePrefab)));
        spells.AddSpell(new SimpleDistantSpell(new WindSpellAction()));
        spells.AddSpell(new SimpleDistantSpell(new MagnetoSpellAction(magnetPrefab)));


        gameInActionLayout = new KeyboardCommandsLayout();
        gamePausedLayout = new KeyboardCommandsLayout();

        InitiateGameCommands();
        InitiatePauseCommands();

        currentLayout = gameInActionLayout;
    }





    private KeyboardCommandsLayout gameInActionLayout;
    private KeyboardCommandsLayout gamePausedLayout;
    private KeyboardCommandsLayout currentLayout;

    public KeyboardCommandsLayout KeyboardCommands {
        get {
            return currentLayout;
        }
    }

    [SerializeField]
    private bool isPaused = false;
    public bool IsPaused {
        get {
            return isPaused;
        }
    }

    public void Pause() {
        if (isPaused) {
            currentLayout = gameInActionLayout;
        } else {
            currentLayout = gamePausedLayout;
        }

        isPaused = !isPaused;

    }



    private void InitiatePauseCommands() {

// Spell choose and cast //
        gamePausedLayout.digit0Command = new PauseGameCommand();
    }




    private void InitiateGameCommands() {

// Spell choose and cast //
        gameInActionLayout.leftArrowCommand = new PreviousSpellCommand(spells);
        gameInActionLayout.rightArrowCommand = new NextSpellCommand(spells);
        gameInActionLayout.mouse0Command = new CastCurrentSpellCommand(player, playerCamera, targetingPoint, spells);

// Character movement //
        gameInActionLayout.keyACommand = new WalkLeftCommand(characterModel);
        gameInActionLayout.keyDCommand = new WalkRightCommand(characterModel);
        gameInActionLayout.keySCommand = new WalkBackCommand(characterModel);
        gameInActionLayout.keyWCommand = new RunForwardCommand(characterModel);

        gameInActionLayout.spaceCommand = new JumpCommand(characterModel);

// Horizontal and vertical rotation //
        gameInActionLayout.mouseRotateHorizontalCommand = new TurnViewHorizontalCommand(characterModel, cameraModel);
        gameInActionLayout.mouseRotateVerticalCommand = new TurnViewVerticalCommand(characterModel, cameraModel);

// Rotate camera but not character //
        gameInActionLayout.rightControlCommand = new MoveSatelliteModeCommand(cameraModel);

// Set camera default position //
        gameInActionLayout.keypad5Command = new CameraDefaultPositionCommand(cameraModel);
        gameInActionLayout.mouse2Command = gameInActionLayout.keypad5Command;

// Change distance from camera to character //
        gameInActionLayout.mouseWheelRotationCommand = new MouseWheelRotationCommand(cameraModel);

        gameInActionLayout.digit0Command = new PauseGameCommand();
    }

}
