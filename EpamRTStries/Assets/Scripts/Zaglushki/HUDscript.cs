using UnityEngine;
using UnityEngine.UI;

public static class HUDscript {


    private static Canvas miniMapPanel;
    private static Canvas commandsPanel;
    private static Canvas objectInfoPanel;
    private static Text objectInfoText;

    static HUDscript() {

        miniMapPanel = GameObject.Find("HUD Canvas/Minimap Panel").GetComponent<Canvas>();
        commandsPanel = GameObject.Find("HUD Canvas/Commands Panel").GetComponent<Canvas>();
        objectInfoPanel = GameObject.Find("HUD Canvas/ObjectInfo Panel").GetComponent<Canvas>();
        objectInfoText = GameObject.Find("HUD Canvas/ObjectInfo Panel/InfoText").GetComponent<Text>();
    }


    public static void Message(string str) {
        //Text txt = objectInfoPanel.gameObject.AddComponent<Text>();

        objectInfoText.text = str;
    }


}
