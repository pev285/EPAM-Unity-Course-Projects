
using System;
using UnityEngine;

public class GameManager20170804 : MonoBehaviour {


    // * Singleton * //

    public static GameManager20170804 Instance = null;

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


    // ###################################################
    
    [SerializeField]
    private GameObject enemyObject;
    private EquippedSpells enemySpells;


    private CharacterController enemyController;

    ////////////////////////////////////////////////////////////////////////////
    // ###################################################################### //
    ////////////////////////////////////////////////////////////////////////////

    public enum GameMode {
        GamePlay,
        Inventory
    }


    Dispatcher enemyKeyBinder;
    public Dispatcher EnemyKeyBinder {
        get {
            return enemyKeyBinder;
        }
    }

    Dispatcher gameModeKeyBinder;
    public Dispatcher GameModeKeyBinder {
        get {
            return gameModeKeyBinder;
        }
    }
    Dispatcher inventoryModeKeyBinder;
    Dispatcher InventoryModeKeyBinder {
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

        ////////////////

        InitiateEnemyKeyBinder();
        InitiateEnemySpells();
        enemyController = enemyObject.GetComponent<CharacterController>();

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
        inventoryModeKeyBinder.StartListening(DispatcherEventType.Pause, ChangeGameMode);
        gameModeKeyBinder.StartListening(DispatcherEventType.Pause, ChangeGameMode);

        // PlayerModel??? //

        gameModeKeyBinder.StartListening(DispatcherEventType.NextSpell, delegate  {
            spells.ShiftForward();
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.PreviousSpell, delegate  {
            spells.ShiftBackward();
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.PowerAttack, delegate  {
            spells.GetCurrentSpell().Cast(player, player.transform.rotation);
        });

    }

    private void InitiateGameModeKeyBinderEvents() {
        gameModeKeyBinder = gameObject.AddComponent<Dispatcher>();

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return Input.GetKeyDown(KeyCode.P); }, DispatcherEventType.Pause));




//        ThrowStone,
//        FireBow,
//        LowRangeWeaponHit,


        /////
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.LeftArrow); }, DispatcherEventType.PreviousSpell));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.RightArrow); }, DispatcherEventType.NextSpell));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.Mouse0); }, DispatcherEventType.PowerAttack));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  {
            return (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)) || Input.GetKey(KeyCode.D);
        }, DispatcherEventType.Walking));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  {
            return (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.D);
        }, DispatcherEventType.NotWalking));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKey(KeyCode.A); }, DispatcherEventType.WalkingLeft));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKey(KeyCode.D); }, DispatcherEventType.WalkingRight));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKey(KeyCode.S); }, DispatcherEventType.WalkingBackward));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKey(KeyCode.W); }, DispatcherEventType.RunningForward));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.A); }, DispatcherEventType.StartWalkLeft));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.D); }, DispatcherEventType.StartWalkRight));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.S); }, DispatcherEventType.StartWalkBackward));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.W); }, DispatcherEventType.StartRunForward));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyUp(KeyCode.A); }, DispatcherEventType.StopWalkLeft));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyUp(KeyCode.D); }, DispatcherEventType.StopWalkRight));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyUp(KeyCode.S); }, DispatcherEventType.StopWalkBackward));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyUp(KeyCode.W); }, DispatcherEventType.StopRunForward));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.Space); }, DispatcherEventType.Jump));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyDown(KeyCode.RightControl); }, DispatcherEventType.StopCharRotation));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetKeyUp(KeyCode.RightControl); }, DispatcherEventType.ResumeCharRotation));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  {
            return Input.GetKeyDown(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.Keypad5);
        }, DispatcherEventType.CameraDefaults));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse ScrollWheel") > 0; }, DispatcherEventType.CameraMoveNear));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse ScrollWheel") < 0; }, DispatcherEventType.CameraMoveAway));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse ScrollWheel") == 0; }, DispatcherEventType.CameraFixDistance));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse X") == 0; }, DispatcherEventType.StopHorizontalMouseMotion));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse X") > 0; }, DispatcherEventType.TurnRight));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse X") < 0; }, DispatcherEventType.TurnLeft));

        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse Y") == 0; }, DispatcherEventType.StopVerticalMouseMotion));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse Y") > 0; }, DispatcherEventType.TurnUp));
        gameModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate  { return Input.GetAxis("Mouse Y") < 0; }, DispatcherEventType.TurnDown));


//
//        mouseRotateHorizontalCommand = new TurnViewHorizontalCommand(characterModel, cameraModel);
//        mouseRotateVerticalCommand = new TurnViewVerticalCommand(characterModel, cameraModel);
//
//
//// Change distance from camera to character //
//        mouseWheelRotationCommand = new MouseWheelRotationCommand(cameraModel);

    }

    private void InitiateInventoryModeKeyBinderEvents() {
        inventoryModeKeyBinder = gameObject.AddComponent<Dispatcher>();

        inventoryModeKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return Input.GetKeyDown(KeyCode.P); }, DispatcherEventType.Pause));
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




    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //





    private void InitiateEnemySpells()
    {
        enemySpells = enemyObject.GetComponent<EquippedSpells>();

        enemySpells.AddSpell(new SimpleDistantSpell(new StoneThrowingAction(stonePrefab)));
        enemySpells.AddSpell(new SimpleDistantSpell(new BowShotAction(arrowPrefab)));
        enemySpells.AddSpell(new SimpleDistantSpell(new WindSpellAction()));
        enemySpells.AddSpell(new SimpleDistantSpell(new MagnetoSpellAction(magnetPrefab)));

    }

    private void InitiateEnemyKeyBinder()
    {
        enemyKeyBinder = enemyObject.AddComponent<Dispatcher>();

        /*
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.WalkingLeft));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.WalkingRight));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.WalkingBackward));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return enemyController.MovingForward(); }, DispatcherEventType.RunningForward));

        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StartWalkLeft));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StartWalkRight));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StartWalkBackward));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return enemyController.MovingForward(); }, DispatcherEventType.StartRunForward));

        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StopWalkLeft));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StopWalkRight));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StopWalkBackward));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StopRunForward));


        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.PreviousSpell));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.NextSpell));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.PowerAttack));

        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return enemyController.TurnLeft(); }, DispatcherEventType.StopHorizontalMouseMotion));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return enemyController.TurnRight(); }, DispatcherEventType.TurnRight));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.TurnLeft));

        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.Jump));


        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate {
            return false;
        }, DispatcherEventType.Walking));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate {
            return false;
        }, DispatcherEventType.NotWalking));



        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StopCharRotation));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.ResumeCharRotation));

        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate {
            return false;
        }, DispatcherEventType.CameraDefaults));

        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.CameraMoveNear));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.CameraMoveAway));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.CameraFixDistance));


        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.StopVerticalMouseMotion));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.TurnUp));
        enemyKeyBinder.AddKeyEvent(new DispatcherEvent(delegate { return false; }, DispatcherEventType.TurnDown));

        */
    }

    // ############################################################################ //
    // $###################


        

    void Update()
    {
        /*
        if (enemyController.NearEnough(player))
        {
            Vector3 e2pDistance = enemyController.FindDirection(player);

            
        } else
        {
            enemyController.MoveDirection = 0;
            enemyController.TurnDirection = 0;
        }
        */
    }

}
