using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speaker System", menuName = "Scriptable Object/Speaker System")]
public class Speaker : ScriptableObject
{
    public int speakerID;
    public string speakerName;
    public string speakerDesc;
    public Sprite[] portraits;
}
