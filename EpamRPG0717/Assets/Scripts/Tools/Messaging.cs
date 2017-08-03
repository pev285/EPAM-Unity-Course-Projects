using UnityEngine;
using UnityEngine.UI;

public class Messaging {


    private static Text topText;
    private static Text centerText;
    private static Text bottomText;
    private static Text techInfoText;

    static Messaging() {

        topText = GameObject.Find("MessageBoardCanvas/TopCenterText").GetComponent<Text>();
        centerText = GameObject.Find("MessageBoardCanvas/CenterCenterText").GetComponent<Text>();
        bottomText = GameObject.Find("MessageBoardCanvas/BottomCenterText").GetComponent<Text>();
        techInfoText = GameObject.Find("MessageBoardCanvas/TechInfoText").GetComponent<Text>();
    }

    public static void SetTopTextFor(float seconds, string str) {
        SetTopText(str);
        Timer t = new Timer(topText.gameObject, delegate  {
            SetTopText("");
        }, seconds);
    }
    public static void SetCenterTextFor(float seconds, string str) {
        SetCenterText(str);
        Timer t = new Timer(centerText.gameObject, delegate  {
            SetCenterText("");
        }, seconds);
    }
    public static void SetBottomTextFor(float seconds, string str) {
        SetBottomText(str);
        Timer t = new Timer(topText.gameObject, delegate  {
            SetBottomText("");
        }, seconds);
    }


    public static void SetTechInfoTextFor(float seconds, string str) {
        SetTechInfoText(str);
        Timer t = new Timer(topText.gameObject, delegate  {
            SetTechInfoText("");
        }, seconds);
    }

    public static void SetTopText(string str) {
        topText.text = str;
    }

    public static void SetCenterText(string str) {
        centerText.text = str;
    }

    public static void SetBottomText(string str) {
        bottomText.text = str;
    }

    public static void SetTechInfoText(string str) {
        techInfoText.text = str;
    }

}