using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ScObTask : ScriptableObject
{
    public string KastenAntwort;

    public enum Emotion
    {
        Idle,
        Sad,
        Happy,
        Angry,
        Fear,
        Shadow
    }

    public enum AutoAntwort
    {
        Antwort1,
        Antwort2,
        Zufall
    }

    [Header("Sprecher und Text")]
    public Anweisung[] anweisung;

    [Header(("QuickTime?"))] 
    public bool Quicktime;
    public QuicktimeStruct QuicktimeSettings;
    
    [Header("Antworten")]
    public ScriptableObject Antwort1;
    public Chemie[] Chemie1;

    public ScriptableObject Antwort2;
    public Chemie[] Chemie2;

    [Serializable]
    public struct Anweisung
    {
        public ScObCharacter Charater;
        public Emotion emotion;
        [TextArea(3, 5)] public string Text;
    }

    [Serializable]
    public struct Chemie
    {
        public ScObCharacter Character;
        public int PlusLove;
    }
    
    [Serializable]
    public struct QuicktimeStruct
    {
        public float Timer;
        public AutoAntwort QuicktimeAntwort;
    }
}
