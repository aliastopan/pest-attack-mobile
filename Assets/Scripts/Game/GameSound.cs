using UnityEngine;
using UnityEngine.UI;

public class GameSound : MonoBehaviour 
{
    public Sprite SoundOn;
    public Sprite SoundOff;

    private Image image;

    private void Awake() 
    {
        image = GetComponent<Image>();    
    }

    private void Update() 
    {
        if(GameData.IsMute)
            image.sprite = SoundOff;
        else
            image.sprite = SoundOn;

    }

    public void OnSoundToggle()
    {
        GameData.IsMute = !GameData.IsMute;
    }
}