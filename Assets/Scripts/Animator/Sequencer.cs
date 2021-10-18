using UnityEngine;

public class Sequencer {
    public float tMax { get; private set; }
    public float t = 0f;
    public float tError { get { return 0.05f; } }
    public bool CanBegin { get; set; }
    public bool IsFinished { get{ return t >= tMax; } }

    public Sequencer(float tMax)
        => this.tMax = tMax;

    public void Start()
        => CanBegin = true;

    public float tValue() => (t - 0f)/(tMax - 0f); 
    public void tReset() => t = 0f;
    public void tLapse()
    {
        if(!IsFinished && CanBegin)
            t += Time.deltaTime;
    }    

    public void tLapseOnce()
    {
        if(!IsFinished && CanBegin)
            t += Time.deltaTime;
        
        if(IsFinished)
        {
            CanBegin = false;
            tReset();
        }
    }

    public void tLapseRepeat()
    {
        if(CanBegin)
        {
            if(!IsFinished)
                t += Time.deltaTime;
            else
                tReset();
        }
    }

    public void tCalibrate(float t)
        => tMax = t;
}