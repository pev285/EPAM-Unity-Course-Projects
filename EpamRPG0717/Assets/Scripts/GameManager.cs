using UnityEngine;

public class GameManager : MonoBehaviour {


    // * Singleton * //

    public static GameManager Instance = null;

    void Awake() {
//        print("GameManager is awake");
//
        if (Instance == null) {
            Instance = this;
        } else {
            if (Instance != this) {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    /////////////////////////////
    // GameObjects and Prefabs //
    /////////////////////////////

    [SerializeField]
    Canvas inventoryCanvas;


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


    private EquippedSpells spells;


////////////////////////////////////////////////////////////////////////////
// ###################################################################### //
////////////////////////////////////////////////////////////////////////////

    public enum GameMode {
        GamePlay,
        Inventory
    }

    KeyBinder gameModeKeyBinder;
    public KeyBinder GameModeKeyBinder {
        get {
            return gameModeKeyBinder;
        }
    }
    KeyBinder inventoryModeKeyBinder;
    KeyBinder InventoryModeKeyBinder {
        get {
            return inventoryModeKeyBinder;
        }
    }
//    KeyBinder currentKeyBinder;

    GameMode gameMode = GameMode.Inventory;
    public GameMode Mode {
        get {
            return gameMode;
        }
    }

    /** * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    Starting initiation * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
     ** * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    void InitGame() {

        InitiateGameModeKeyBinderEvents();
        InitiateInventoryModeKeyBinderEvents();
        SubscribeOnKeyboardEvents();


        GoToMode(GameMode.GamePlay);

        InitiateSpells();
    }

    private void InitiateSpells() {

        // PlayerModel??? //
        spells = player.GetComponent<EquippedSpells>();

        spells.AddSpell(new SimpleDistantSpell(new BowShotAction(arrowPrefab)));
        spells.AddSpell(new SimpleDistantSpell(new StoneThrowingAction(stonePrefab)));
        spells.AddSpell(new SimpleDistantSpell(new WindSpellAction()));
        spells.AddSpell(new SimpleDistantSpell(new MagnetoSpellAction(magnetPrefab)));


    }

    private void SubscribeOnKeyboardEvents() {
        inventoryModeKeyBinder.StartListening(KeyboardEventType.Pause, ChangeGameMode);
        gameModeKeyBinder.StartListening(KeyboardEventType.Pause, ChangeGameMode);

        // PlayerModel??? //

        gameModeKeyBinder.StartListening(KeyboardEventType.NextSpell, delegate  {
            spells.ShiftForward();
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.PreviousSpell, delegate  {
            spells.ShiftBackward();
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.PowerAttack, delegate  {
            spells.GetCurrentSpell().Cast(player, playerCamera, targetingPoint);
        });

    }

    private void InitiateGameModeKeyBinderEvents() {
        gameModeKeyBinder = gameObject.AddComponent<KeyBinder>();

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate { return Input.GetKeyDown(KeyCode.P); }, KeyboardEventType.Pause));




//        ThrowStone,
//        FireBow,
//        LowRangeWeaponHit,


        /////
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.LeftArrow); }, KeyboardEventType.PreviousSpell));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.RightArrow); }, KeyboardEventType.NextSpell));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.Mouse0); }, KeyboardEventType.PowerAttack));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  {
            return (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)) || Input.GetKey(KeyCode.D);
        }, KeyboardEventType.Walking));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  {
            return (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.D);
        }, KeyboardEventType.NotWalking));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKey(KeyCode.A); }, KeyboardEventType.WalkingLeft));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKey(KeyCode.D); }, KeyboardEventType.WalkingRight));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKey(KeyCode.S); }, KeyboardEventType.WalkingBackward));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKey(KeyCode.W); }, KeyboardEventType.RunningForward));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.A); }, KeyboardEventType.StartWalkLeft));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.D); }, KeyboardEventType.StartWalkRight));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.S); }, KeyboardEventType.StartWalkBackward));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.W); }, KeyboardEventType.StartRunForward));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyUp(KeyCode.A); }, KeyboardEventType.StopWalkLeft));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyUp(KeyCode.D); }, KeyboardEventType.StopWalkRight));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyUp(KeyCode.S); }, KeyboardEventType.StopWalkBackward));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyUp(KeyCode.W); }, KeyboardEventType.StopRunForward));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.Space); }, KeyboardEventType.Jump));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyDown(KeyCode.RightControl); }, KeyboardEventType.StopCharRotation));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetKeyUp(KeyCode.RightControl); }, KeyboardEventType.ResumeCharRotation));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  {
            return Input.GetKeyDown(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.Keypad5);
        }, KeyboardEventType.CameraDefaults));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse ScrollWheel") > 0; }, KeyboardEventType.CameraMoveNear));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse ScrollWheel") < 0; }, KeyboardEventType.CameraMoveAway));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse ScrollWheel") == 0; }, KeyboardEventType.CameraFixDistance));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse X") == 0; }, KeyboardEventType.StopHorizontalMouseMotion));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse X") > 0; }, KeyboardEventType.TurnRight));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse X") < 0; }, KeyboardEventType.TurnLeft));

        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse Y") == 0; }, KeyboardEventType.StopVerticalMouseMotion));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse Y") > 0; }, KeyboardEventType.TurnUp));
        gameModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate  { return Input.GetAxis("Mouse Y") < 0; }, KeyboardEventType.TurnDown));


//
//        mouseRotateHorizontalCommand = new TurnViewHorizontalCommand(characterModel, cameraModel);
//        mouseRotateVerticalCommand = new TurnViewVerticalCommand(characterModel, cameraModel);
//
//
//// Change distance from camera to character //
//        mouseWheelRotationCommand = new MouseWheelRotationCommand(cameraModel);

    }

    private void InitiateInventoryModeKeyBinderEvents() {
        inventoryModeKeyBinder = gameObject.AddComponent<KeyBinder>();

        inventoryModeKeyBinder.AddKeyEvent(new KeyboardDependentEvent(delegate { return Input.GetKeyDown(KeyCode.P); }, KeyboardEventType.Pause));
    }

    private void SelectKeyBinder() {
        if (IsPlaying) {
            gameModeKeyBinder.enabled = true;
            inventoryModeKeyBinder.enabled = false;
//            currentKeyBinder = gameModeKeyBinder;
        } else {
            gameModeKeyBinder.enabled = false;
            inventoryModeKeyBinder.enabled = true;
//            currentKeyBinder = inventoryModeKeyBinder;
        }
    }

    private void SetInventoryCanvasVisibility() {
        if (IsPlaying) {
            inventoryCanvas.enabled = false;
        } else {
            inventoryCanvas.enabled = true;
        }
    }


    public bool IsPlaying {
        get {
            return Mode == GameMode.GamePlay;
        }
    }

    private void ReinitiateSettingsForCurrentMode() {
        SelectKeyBinder();
        SetInventoryCanvasVisibility();
    }

    public void GoToMode(GameMode mode) {
        gameMode = mode;
        ReinitiateSettingsForCurrentMode();
    }


    void Update() {

    }

    // Event Methods ////////////////////////////////////////////////////

    public void ChangeGameMode() {
//        print("changeMode was invoked");

        if (IsPlaying) {
            gameMode = GameMode.Inventory;
        } else {
            gameMode = GameMode.GamePlay;
        }
        ReinitiateSettingsForCurrentMode();
    }


}
