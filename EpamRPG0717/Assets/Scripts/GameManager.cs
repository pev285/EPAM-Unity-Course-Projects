using System.Collections.Generic;
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


        ////////////////////////////

        InitGame();
    }


    /////////////////////////////////////////////////////////////////////
    

    /////////////////////////////
    // GameObjects and Prefabs //
    /////////////////////////////

//    GameObject inventoryCanvas;
    Canvas inventoryCanvas;


    private GameObject player = null;

    private GameObject playerCamera = null;

    private GameObject targetingPoint = null;
    private GameObject characterFace = null;


    [SerializeField]
    private GameObject cameraInitiator;
    [SerializeField]
    private GameObject stoneInitiator;
    [SerializeField]
    private GameObject arrowInitiator;
    [SerializeField]
    private GameObject magnetInitiator;


    private GameObject playerCameraPrefab = null;
    private GameObject stonePrefab = null;
    private GameObject arrowPrefab = null;
    private GameObject magnetPrefab = null;


    private ConsoleReaderController consoleReader;

    private ControllerEventSystem gameModeConsoleEventSystem;
    private ControllerEventSystem pauseModeConsoleEventSystem;

    private List<AbstractAIController> enemyAIsList = new List<AbstractAIController>();

    ////////////////////////////////////////////////////////////////////////////
    // ###################################################################### //
    ////////////////////////////////////////////////////////////////////////////

    public enum GameMode {
        GamePlay,
        Inventory
    }



    GameMode currentMode = GameMode.GamePlay;
    public GameMode Mode {
        get {
            return currentMode;
        }
    }

    public Vector3 GetCharacterFacePosition() {
        return characterFace.transform.position;
    }

    public Quaternion GetCharacterFaceRotation() {
        return characterFace.transform.rotation;
    }

    public Quaternion GetPlayerCameraRotation() {
        return playerCamera.transform.rotation;
    }

    /** * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    Starting initiation * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
     ** * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    void InitGame() {
        FindGameObjectsAndPrefabs();

        consoleReader = GetComponent<ConsoleReaderController>();
        gameModeConsoleEventSystem = new ControllerEventSystem();
        pauseModeConsoleEventSystem = new ControllerEventSystem();
        SubscribeOnConsoleEvents();

        GoToMode(GameMode.GamePlay);
    }

    private void FindGameObjectsAndPrefabs() {
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        if (inventoryCanvas == null) {
            print("Inventory Canvas is null");
        }


        stonePrefab = stoneInitiator;
        arrowPrefab = arrowInitiator;
        magnetPrefab = magnetInitiator;
        playerCameraPrefab = cameraInitiator;

//        stonePrefab = GameObject.Find("StonePrefab");
//        arrowPrefab = GameObject.Find("ArrowPrefab");
//        magnetPrefab = GameObject.Find("MagnetPrefab");
//        playerCameraPrefab = GameObject.Find("PlayerCameraPrefab");
//
//        if (arrowPrefab == null) {
//            print("arrowPrefab is null");
//        }
//        if (stonePrefab == null) {
//            print("stonePrefab is null");
//        }
//        if (magnetPrefab == null) {
//            print("magnetPrefab is null");
//        }
//        if (playerCameraPrefab == null) {
//            print("playerCameraPrefab is null");
//        }

    }

    private void SubscribeOnConsoleEvents() {
        gameModeConsoleEventSystem.pauseModeEvent += SwitchGameMode;

        pauseModeConsoleEventSystem.pauseModeEvent += SwitchGameMode;
    }




    // *****************************************************************
    // *****************************************************************
    // *****************************************************************


    private void SelectAppropriateConsoleEventSystem() {
        if (IsPlaying) {
            consoleReader.SetControllerEventSystem(gameModeConsoleEventSystem);
        } else {
            consoleReader.SetControllerEventSystem(pauseModeConsoleEventSystem);
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



    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //
    // ############################################################################ //



    private void ReinitiateSettingsForCurrentMode()
    {
        SelectAppropriateConsoleEventSystem();
        SetInventoryCanvasVisibility();
    }

    public void GoToMode(GameMode mode)
    {
        currentMode = mode;
        ReinitiateSettingsForCurrentMode();
    }


    public void SwitchGameMode()
    {

        if (IsPlaying)
        {
            currentMode = GameMode.Inventory;
        }
        else
        {
            currentMode = GameMode.GamePlay;
        }
        ReinitiateSettingsForCurrentMode();
    }



    public void HereIAm(GameObject gob)
    {
        TeamID tid= gob.GetComponent<TeamID>();

        if (tid != null)
        {
            // It is a character //

            InitiateSpells(gob, new AbstractSpell[] {
                    new SimpleDistantSpell(new BowShotAction(arrowPrefab)),
                    new SimpleDistantSpell(new StoneThrowingAction(stonePrefab)),
                    new SimpleDistantSpell(new WindSpellAction()),
                    new SimpleDistantSpell(new MagnetoSpellAction(magnetPrefab)),
                });

            if (tid.ThisTeam == TeamID.Teams.A)
            {
                // This is a player controlled character //
                player = gob;
                targetingPoint = player.transform.Find("HeadTop/TargetPoint").gameObject;
                characterFace = player.transform.Find("CharacterFace").gameObject;

                // Init Controller //
                player.GetComponent<CharacterModel>().SetEventsSystem(gameModeConsoleEventSystem);

                GetComponent<PlayerStateInfo>().SetInfoSource(player);

                InitCamera();

            } else
            {
                // This is NPC //

                // Init Controller //
                ControllerEventSystem ces = new ControllerEventSystem();
                gob.GetComponent<CharacterModel>().SetEventsSystem(ces);
                AbstractAIController cAI = gob.AddComponent<TeamBAIController>();
                cAI.SetControllerEventSystem(ces);

                enemyAIsList.Add(cAI);

            }
        } else
        {
            // it is not a character //

        }
    }





    private void InitiateSpells(GameObject go, AbstractSpell[] spellsArray)
    {
        EquippedSpells spells = go.AddComponent<EquippedSpells>();

        foreach (AbstractSpell abSpell in spellsArray)
        {
            spells.AddSpell(abSpell);
        }

        go.GetComponent<CharacterModel>().SetSpells(spells);
    }


    private void InitCamera() {

        playerCamera = Instantiate(playerCameraPrefab, targetingPoint.transform.position, targetingPoint.transform.rotation);

        playerCamera.GetComponent<SatelliteModel>().SetEventsSystem(gameModeConsoleEventSystem);

        CharacterCameraMover mover = playerCamera.GetComponent<CharacterCameraMover>();

        mover.ViewTargetObject = targetingPoint;
        mover.PlayerFace = characterFace;
    }




    /// /////////////////////////////////////////////////////////////////////
    void Update()
    {
    }


}
