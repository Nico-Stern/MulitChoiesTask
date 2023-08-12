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


    // Start is called before the first frame update
    void Start()
    {
        changeText();
        btnFertig.SetActive(false);
    }

    void changeText()
    {
        Textbox.text = CurrentText.anweisung[1].Text;

        try
        {
            Ant1 = CurrentText.Antwort1 as ScObTask;
            Button1.text = Ant1.anweisung[0].Text;

            Ant2 = CurrentText.Antwort2 as ScObTask;
            Button2.text = Ant2.anweisung[0].Text;
        }
        catch 
        {
            btnAntwort1.SetActive(false);
            btnAntwort2.SetActive(false);
            btnFertig.SetActive(true);
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

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
