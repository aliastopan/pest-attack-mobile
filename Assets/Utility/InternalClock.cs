using UnityEngine;

public class InternalClock
{
    public float tMax { get; }
    public float t = 0f;
    public float tError { get { return 0.05f; } }
    public bool CanBegin { get; set; }
    public bool IsFinished { get{ return t >= tMax; } }

    public InternalClock(float tMax)
        => this.tMax = tMax;

    public float tValueInterpolate() => (t - 0f)/(tMax - 0f);
    public float tValue() => t;

    public void tReset() => t = 0f;
    public void tLapse()
    {
        if(!IsFinished && CanBegin)
            t += Time.deltaTime;
    }    

    public void tLapseRepeat()
    {
        if(CanBegin)
        {
            if(!IsFinished)
                t += Time.deltaTime;
            else
                t = 0f;
        }
        
    }

}