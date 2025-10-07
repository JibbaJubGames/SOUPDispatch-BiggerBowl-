using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameTagCharacterLimiter : MonoBehaviour
{
    private TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        nameInput   = GetComponent<TMP_InputField>();
        nameInput.characterLimit = 12;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
