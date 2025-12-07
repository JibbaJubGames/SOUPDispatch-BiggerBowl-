using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyButtonScreen : MonoBehaviour
{
    private Image startScreen;
    private bool pressedAButton = false;
    public float changeSpeed;
    private Color lerpedColor;
    // Start is called before the first frame update
    void Start()
    {
        startScreen = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            pressedAButton = true;
        }
        if (pressedAButton)
        {
            changeSpeed += Time.deltaTime;
            lerpedColor = Color.Lerp(Color.white, Color.clear, changeSpeed/2);
            startScreen.color = lerpedColor;
        }
        if (startScreen.color == Color.clear)
        {
            pressedAButton = false;
            Destroy(this.gameObject);
        }
    }
}
