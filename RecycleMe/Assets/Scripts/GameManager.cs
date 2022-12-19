using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public static float score;
    public static int hit;
    public static int combo;

    static GameManager instance;

    void Start()
    {
     //   Application.targetFrameRate = 60;
        instance = this;

    }

    public static void Success()
    {
        hit++;
        combo++;
        score += 1 + (combo * 0.1f);
        instance.StopCoroutine(instance.OffCombo());
        instance.StartCoroutine(instance.OffCombo());

    }

    public static void Fail()
    {
        combo = 0;

    }

    IEnumerator OffCombo()
    {
        yield return new WaitForSeconds(3f);
        combo = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
