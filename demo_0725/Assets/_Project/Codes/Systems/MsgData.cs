using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MsgData
{
    public int speakerId;
    public int portraitId;

    [TextArea]
    public string msg;
}
