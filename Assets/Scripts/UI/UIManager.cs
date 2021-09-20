using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text collectableText;
    public Text lifePointText;
	public static int collectable;
    public static int lifePoint;

    // Start is called before the first frame update
    void Start()
    {
        collectable = 0;
        lifePoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        collectableText.text = $"{collectable}";
        lifePointText.text = $"{lifePoint}";        
    }
}
