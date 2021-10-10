using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]
    private Sprite[] frames;
    private int currentFrame;
    private Sequencer sequencer;
    
    [Range(0.1f, 1f)]
    public float SecondsPerFrame = 0.25f;

    private void Start() 
    {
        sequencer = new Sequencer(SecondsPerFrame);
        sequencer.InitiateStart();
    }

    private void Update() 
    {
        sequencer.tLapseRepeat();
    }

}
