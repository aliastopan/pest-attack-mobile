using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private AnimationPack defaultPack;
    [SerializeField] private AnimationPack attackPack;
    private AnimationPack animationPack;

    private int currentFrame = 0;
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
        sequencer.tCalibrate(SecondsPerFrame);
        sequencer.tLapseRepeat();
        if(sequencer.tValue() > 1)
        {
            //Debug.Log($"Frame...");
            if(currentFrame >= defaultPack.FrameSeries.Length - 1)
                currentFrame = 0;
            else
                currentFrame++;
        }

        Play();

    }

    public void Play()
    {
        Image actor = GetComponent<Image>(); 
        actor.sprite = defaultPack.FrameSeries[currentFrame];
    }

}
