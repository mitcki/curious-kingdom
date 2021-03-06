﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FTRuntime;
using FTRuntime.Yields;
public class TowerKing : MonoBehaviour
{
    int kingChance;
    bool hasReplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        kingChance = Random.Range(1, 3);
        Debug.Log("kingChance");
        Debug.Log(kingChance);
        StartCoroutine(prepAnimation());
    }
    IEnumerator prepAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        if(kingChance == 1){
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingAnimation.GetComponent<MeshRenderer>().enabled = false;

        } else {
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
            kingAnimation.GetComponent<MeshRenderer>().enabled = false;
        }
        GameObject replayKing = GameObject.Find("KING_REPLAY.fla.KING_REPLAY");
        replayKing.GetComponent<MeshRenderer>().enabled = false;

    }
    public void Jump()
    {
        AudioSource audioPlayer = GetComponent<AudioSource>();
        AudioSources clips = GetComponent<AudioSources>();

        if(kingChance == 1){
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
            kingAnimation.GetComponent<SwfClipController>().Play(false);

            GameObject kingAnimation2 = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingAnimation2.GetComponent<MeshRenderer>().enabled = false;

            audioPlayer.clip = clips.AudioFiles[0];
            audioPlayer.PlayDelayed(0.5f);

        } else {
            GameObject kingAnimation = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingAnimation.GetComponent<SwfClipController>().Play(false);

            GameObject kingAnimation2 = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
            kingAnimation2.GetComponent<MeshRenderer>().enabled = false;

            audioPlayer.clip = clips.AudioFiles[1];
            audioPlayer.PlayDelayed(0.5f);
        }
        
    }
    public void Replay()
    {
        if(hasReplayed == false){
            // ItemCount.badItemCount++;
            GameObject replay = GameObject.Find("Replay");
            replay.GetComponent<BoxCollider2D>().enabled = true;
            GameObject replayKing = GameObject.Find("KING_REPLAY.fla.KING_REPLAY");
            replayKing.GetComponent<MeshRenderer>().enabled = true;
            replayKing.GetComponent<SwfClipController>().Play(false);

            GameObject kingAnimation = GameObject.Find("KING_JUMP_V2.fla.KING_JUMP_V3");
            kingAnimation.GetComponent<MeshRenderer>().enabled = false;
            GameObject kingAnimation2 = GameObject.Find("KING_JUMP_V1.fla.KING_JUMP_V1");
            kingAnimation2.GetComponent<MeshRenderer>().enabled = false;

            replay.GetComponent<AudioSource>().Play();

            AudioSource voAudio = GameObject.Find("CastleAudio").GetComponent<AudioSource>();
            AudioSources clips = GameObject.Find("CastleAudio").GetComponent<AudioSources>();
            voAudio.clip = clips.AudioFiles[6];
            voAudio.Play();

            hasReplayed = true;

            StartCoroutine(PlayIdleVO());

        }
        
    }

    IEnumerator PlayIdleVO(){
        yield return new WaitForSeconds(10f);

        AudioSource voAudio = GameObject.Find("CastleAudio").GetComponent<AudioSource>();
        AudioSources clips = GameObject.Find("CastleAudio").GetComponent<AudioSources>();
        int IncorrectClip = Random.Range(7,10);

        voAudio.clip = clips.AudioFiles[IncorrectClip];
        voAudio.Play();

        StartCoroutine(PlayIdleVO());

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
