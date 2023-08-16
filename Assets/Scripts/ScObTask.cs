using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ScObTask : ScriptableObject
{
    public string KastenAntwort;

    [Header("Sprecher und Text")]
    public Anweisung[] anweisung;

    [Header("Antworten")]
    public ScriptableObject Antwort1;
    public ScriptableObject Antwort2;

    [Serializable]
    public struct Anweisung
    {
        public Sprite CharaterEmotion;
        [TextArea(3, 5)] public string Text;
    }
}
