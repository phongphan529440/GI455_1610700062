using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemList : MonoBehaviour
{
    public Text searchInputField;

    public Text myText;

    public Text resultText;

    string display = ""; 


    public List<string> items = new List<string>();

    bool callMe;
    public void Start()
    {
        //var input = gameObject.GetComponent<InputField>();
        //var se = new InputField.SubmitEvent();
        //input.onEndEdit.AddListener(SubmitName);
        //input.onEndEdit = se;


        items = new List<string>();

        items.Add("Google");
        items.Add("Yahoo");
        items.Add("Hotmail");
        items.Add("Facebook");
        items.Add("Instagram");
        items.Add("Window");

        callMe = true;
        

    }

    private void Update()
    {
        //if(items.Contains())

        if (callMe)
        {
            ShowText();
            callMe = false;
        }
    }
    void ShowText()
    {
        foreach(string itemList in items)
        {
            display = display.ToString () + itemList.ToString() + "\n" ;
        }
        myText.text = display;
    }
    public void SearchItem()
    {
        
        //Debug.Log("Button has been clicked");
        if (items.Contains(searchInputField.text))
        {
            resultText.text = $"Result for [<color=Green>{searchInputField.text}</color>] Is found";

        }
        else
        {
            resultText.text = $"Result for[<color=red>{searchInputField.text}</color>]  Is not found";
        }


    }
   





}
