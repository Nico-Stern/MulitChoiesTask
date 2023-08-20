using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public ScObTask CurrentText;

    public ScObTask Ant1;
    public ScObTask Ant2;

    public GameObject btnAntwort1;
    public GameObject btnAntwort2;
    public GameObject btnFertig;

    public TMP_Text Textbox;
    public TMP_Text Button1;
    public TMP_Text Button2;

    int currentindex = 0;
    bool ispressed=false;


    // Start is called before the first frame update
    void Start()
    {
        changeText();
        btnFertig.SetActive(false);
        btnAntwort1.SetActive(false);
        btnAntwort2.SetActive(false);
    }

    void changeText()
    {
        currentindex = 0;
        btnAntwort1.SetActive(false);
        btnAntwort2.SetActive(false);
        Textbox.text = CurrentText.anweisung[0].Text;
        try
        {
            Ant1 = CurrentText.Antwort1 as ScObTask;
            Button1.text = Ant1.KastenAntwort;
        }
        catch 
        {
            //animation
            Button1.text = "";
            //Inaktiv setzten
        }
        try
        {

            Ant2 = CurrentText.Antwort2 as ScObTask;
            Button2.text = Ant2.KastenAntwort;
        }
        catch 
        {
            //animation
            Button2.text = "";
            //Inaktiv setzten
        }
    }
    void newTextbox()
    {
        if (CurrentText.anweisung.Length-1 > currentindex) 
        {
            currentindex++;
            Textbox.text = CurrentText.anweisung[currentindex].Text;
            btnAntwort1.SetActive(false);
            btnAntwort2.SetActive(false);
        }
        else
        {
            if(CurrentText.Antwort1==true|| CurrentText.Antwort1 == true)
            {
                btnAntwort1.SetActive(true);
                btnAntwort2.SetActive(true);
            }
            else
            {
                btnFertig.SetActive(true);
            }
        }
    }

    public void OnButten(int Button)
    {
        if(Button == 0)
        {
            CurrentText = Ant1;
        }
        else
        {
            CurrentText = Ant2;
        }
        changeText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&!ispressed)
        {
            ispressed = true;
            newTextbox();
        }
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            ispressed = false;
        }
    }
}
