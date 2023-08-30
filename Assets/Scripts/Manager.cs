using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public float Timer;
    private bool TimerRun = false;
    private bool TimerChecked = false;
    public TMP_Text Timertext;
    
    public ScObCharacter emoCharacter;
    public Image CharacterImage;

    public ScObTask CurrentAntwort;

    public ScObTask Ant1;
    public ScObTask Ant2;
    public ScObCharacter CurrentCharacter;

    public GameObject btnAntwort1;
    public GameObject btnAntwort2;
    public GameObject btnFertig;

    public TMP_Text Textbox;
    public TMP_Text Button1;
    public TMP_Text Button2;

    int currentindex = 0;
    bool ispressed=false;


    // Alle Buttons ausschalten
    void Start()
    {
        changeText();
        btnFertig.SetActive(false);
        btnAntwort1.SetActive(false);
        btnAntwort2.SetActive(false);
    }

    //Neue Task als CurrentTask setzten
    void changeText()
    {
        TimerChecked = false;
        currentindex = 0;
        try
        {
            chancePic();
        }
        catch
        {

        }
        btnAntwort1.SetActive(false);
        btnAntwort2.SetActive(false);
        Textbox.text = CurrentAntwort.anweisung[0].Text;
        try
        {
            Ant1 = CurrentAntwort.Antwort1 as ScObTask;
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
            Ant2 = CurrentAntwort.Antwort2 as ScObTask;
            Button2.text = Ant2.KastenAntwort;
        }
        catch 
        {
            //animation
            Button2.text = "";
            //Inaktiv setzten
        }
    }

    //Textbox Aktualisieren mit dem Charaterbild
    void newTextbox()
    {
        if (CurrentAntwort.anweisung.Length-1 > currentindex) 
        {
            currentindex++;
            Textbox.text = CurrentAntwort.anweisung[currentindex].Text;
            
            //Test
            chancePic();

            btnAntwort1.SetActive(false);
            btnAntwort2.SetActive(false);
        }
        else
        {
            if(CurrentAntwort.Antwort1==true|| CurrentAntwort.Antwort1 == true)
            {
                btnAntwort1.SetActive(true);
                btnAntwort2.SetActive(true);
                if (CurrentAntwort.Quicktime&!TimerChecked)
                {
                    TimerChecked = true;
                    Timer= CurrentAntwort.QuicktimeSettings.Timer;
                    TimerRun = true;
                }
            }
            else
            {
                btnFertig.SetActive(true);
            }
        }
    }

    //Welcher Button wurde gedrückt + Chieme
    public void OnButten(int Button)
    {
        TimerRun = false;
        if(Button == 0)
        {
            for(int i = 1; i <= CurrentAntwort.Chemie1.Length; i++)
            {   
                emoCharacter = CurrentAntwort.Chemie1[i-1].Character;
                emoCharacter.Love += CurrentAntwort.Chemie1[i-1].PlusLove;
                if (emoCharacter.Love < 0)
                {
                    emoCharacter.Love = 0;
                }

                if (emoCharacter.Love > 100)
                {
                    emoCharacter.Love = 100;
                }
            }
            CurrentAntwort = Ant1;
        }
        else
        {
            for (int i = 1; i <= CurrentAntwort.Chemie2.Length; i++)
            {
                emoCharacter = CurrentAntwort.Chemie2[i-1].Character;
                emoCharacter.Love += CurrentAntwort.Chemie2[i-1].PlusLove;
                if (emoCharacter.Love < 0)
                {
                    emoCharacter.Love = 0;
                }

                if (emoCharacter.Love > 100)
                {
                    emoCharacter.Love = 100;
                }
            }
            CurrentAntwort = Ant2;
        }
        changeText();
    }

    private void Update()
    {
        //Aktualisiert Textbox

        if (Input.GetKeyDown(KeyCode.Space)&!ispressed)
        {
            ispressed = true;
            newTextbox();
        }
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            ispressed = false;
        }

        if (TimerRun)
        {
            Timertext.text = Timer.ToString("0.00");
            Timer = Timer - Time.deltaTime;
        }
        else
        {
            Timertext.text = "";
        }

        if (Timer <= 0)
        {
            switch (CurrentAntwort.QuicktimeSettings.QuicktimeAntwort)
            {
                case   ScObTask.AutoAntwort.Antwort1:
                    OnButten(0);
                    break;
                case ScObTask.AutoAntwort.Antwort2:
                    OnButten(1);
                    break;
                case ScObTask.AutoAntwort.Zufall:
                    int index = Random.Range(0, 2);
                    OnButten(index);
                    break;
            }
            Timer = 1;
        }
    }


    //Tauscht den Character Pic im Game
    void chancePic()
    {
        print(CurrentAntwort.anweisung[currentindex].emotion);

        CurrentCharacter = CurrentAntwort.anweisung[currentindex].Charater as ScObCharacter;

        switch (CurrentAntwort.anweisung[currentindex].emotion)
        {
            case ScObTask.Emotion.Sad:
                CharacterImage.sprite = CurrentCharacter.Sad;
                break;
            case ScObTask.Emotion.Idle:
                CharacterImage.sprite = CurrentCharacter.Idle;
                break;
            case ScObTask.Emotion.Angry:
                CharacterImage.sprite = CurrentCharacter.Angry;
                break;
            case ScObTask.Emotion.Fear:
                CharacterImage.sprite = CurrentCharacter.Fear;
                break;
            case ScObTask.Emotion.Happy:
                CharacterImage.sprite = CurrentCharacter.Happy;
                break;
            case ScObTask.Emotion.Shadow:
                CharacterImage.sprite = CurrentCharacter.Shadow;
                break;
        }
    }
}
