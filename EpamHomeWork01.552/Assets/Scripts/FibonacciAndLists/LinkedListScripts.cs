using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LinkedListScripts : MonoBehaviour {

    public GameObject listItemTemplate;

    private Text outputText;
    private InputField indexField;
    private InputField valueField;

    private bool refreshNeeded = true;

    private float unitSize = 1.35f;

    private ListHolder listHolder;
    


    // Coords for relative positions //
    private Vector3 center = Vector3.zero;



    // Use this for initialization
    void Start () {

        outputText = GameObject.Find("output").GetComponent<Text>();
        indexField = GameObject.Find("IndexField").GetComponent<InputField>();
        valueField = GameObject.Find("ValueField").GetComponent<InputField>();

        
        listHolder = new ListHolder(null, unitSize);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Menu");
        }

        if (refreshNeeded)
        {
            LiList list = listHolder.GetList();

            float size = 0;
            if (list != null)
            {
                size = list.getSize();
            }

            Vector3 newPosition = new Vector3(center.x - (size-1f) * unitSize / 2f, center.y, center.z);

            listHolder.MoveListTo(newPosition);
            listHolder.Rearrange();

            string listString = listToString(list);

            
            outputText.text = listString;

            ///////////////////////////////////////////////
            refreshNeeded = false;
        }

    }


    public void DeleteClick()
    {

        string indexString = indexField.text;



        try
        {
            int index = int.Parse(indexString);

            GameObject o = listHolder.DeleteAt(index);

            Destroy(o);
        }
        catch (Exception e)
        {
            GameObject o = listHolder.DeleteLast();

            Destroy(o);
        }



        /////////////////////////////
        refreshNeeded = true;
    }


    public void InsertClick()
    {

        string value = valueField.text;
        string indexString = indexField.text;

        GameObject newObj = Instantiate(listItemTemplate);

        newObj.transform.position = Vector3.zero;

        setTextOnObj(newObj, value);


        try
        {
            int index = int.Parse(indexString);

            listHolder.AddAt(index, newObj);
        }
        catch (Exception e)
        {
            listHolder.AddLast(newObj);
        }


        //////////////////////////////////
        refreshNeeded = true;
    }


    public void FindClick()
    {
        string value = valueField.text;

        int index = -1;

        int size = listHolder.GetSize();

        int i = 0;
        while(i < size)
        {
            GameObject o = listHolder.GetObjectAt(i);
            string s = getTextOnObj(o);

            if (s == value)
            {
                index = i;
                break;
            }

            i++;
        }



        indexField.text = index.ToString();

        ///////////////////////////////////
        refreshNeeded = true;
    }



    private void setTextOnObj(GameObject go, string text)
    {
//        TextMesh text3d = GameObject.Find("ListItem/ValueText").GetComponent<TextMesh>();
//        text3d.text = "asd 1";

        TextMesh tm = go.transform.Find("ValueText").gameObject.GetComponent<TextMesh>();

        tm.text = text;
    }


    private string getTextOnObj(GameObject go)
    {
        TextMesh tm = go.transform.Find("ValueText").gameObject.GetComponent<TextMesh>();

        return tm.text;
    }



    private string listToString(LiList list)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("=>");

        if (list != null)
        {
            LiList cur = list.findHead();

            while (cur != null)
            {
                sb.Append("[").Append(getTextOnObj(cur.getData())).Append("]");
                sb.Append("+");

                cur = cur.getNext();
            }
        }
        return sb.ToString();
    }

}
