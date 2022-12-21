using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    public KeyCode mappingKey;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameOver)
            return;

        if(Input.GetKeyDown(mappingKey))
        {
            button.onClick.Invoke();
        }
    }
}
