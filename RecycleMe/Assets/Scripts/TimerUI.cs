using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Color lowRate;
    public Color midRate;
    public Color highRate;
    public Image fill;

    Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();


    }

    // Update is called once per frame
    void Update()
    {
        float remain = GameManager.maxTime - GameManager.playTime;
        float rate = remain / GameManager.maxTime;
        mySlider.value = rate;

        if (rate > 0.7f)
        {
            fill.color = highRate;
        }
        else if (rate > 0.4f)
        {
            fill.color = midRate;
        }
        else
        {
            fill.color = lowRate;
        }

    }
}
