using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class TalkSystem : MonoBehaviour
{
    public static TalkSystem instance;
    public int sessionId;

    [SerializeField]
    Talk talk;

    [SerializeField]
    Text textName;

    [SerializeField]
    Text textDesc;

    [SerializeField]
    Text textMsg;

    [SerializeField]
    Image ImagePortrait;

    [SerializeField]
    Speaker speaker1;

    [SerializeField]
    Speaker speaker2;

    List<Speaker> speakers;
    WaitForSeconds wait;
    bool isTalk;
    int currentTalkId = 0;

    void Awake()
    {
        instance = this;
        wait = new WaitForSeconds(1F);
    }

    void  Start ()
    {
        speakers = new List<Speaker>();

        speakers.Add(speaker1);
        speakers.Add(speaker2);
        TalkGroup(sessionId, currentTalkId);
    }

    public void TalkGroup(int sessionId, int talkId)
    {
        if (talk == null) return;

        MsgData data = talk.GetTalk(sessionId, talkId);
        if (data == null) return;

        Speaker speaker = speakers[data.speakerId];

        textName.text = speaker.speakerName;
        textDesc.text = speaker.speakerDesc;
        ImagePortrait.sprite = speaker.portraits[data.portraitId];

        StartCoroutine(talkRoutine(data.msg, sessionId, talkId));
    }

    IEnumerator talkRoutine(string msg, int sessionId, int talkId)
    {
        yield return wait;

        textMsg.text = "";

        foreach (char letter in msg)
        {
            textMsg.text += letter;
        }

        currentTalkId++;

        if (sessionId == 0)
        {
            if (currentTalkId >= talk.talkSession0.Length)
            {
                sessionId++;
                currentTalkId = 0;
                TalkGroup(sessionId, currentTalkId);
            }
            else
            {
                TalkGroup(sessionId, currentTalkId);
            }
        }
        else if (sessionId == 1)
        {
            if (currentTalkId >= talk.talkSession1.Length)
            {
                currentTalkId = 0;
            }
            else
            {
                TalkGroup(sessionId, currentTalkId);
            }
        }
    }
}
