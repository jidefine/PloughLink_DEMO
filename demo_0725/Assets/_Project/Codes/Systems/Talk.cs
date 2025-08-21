using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Talk System", menuName = "Scriptable Object/Talk System")]
public class Talk : ScriptableObject
{
    public MsgData[] talkSession0;
    public MsgData[] talkSession1;

    public MsgData GetTalk(int sessionId, int talkId)
    {
        MsgData[] targetSession = null;

        switch (sessionId)
        {
            case 0:
                targetSession = talkSession0;
                break;
            case 1:
                targetSession = talkSession1;
                break;
        }

        if (talkId < targetSession.Length)
            return targetSession[talkId];
        else
            return null;
    }
}
