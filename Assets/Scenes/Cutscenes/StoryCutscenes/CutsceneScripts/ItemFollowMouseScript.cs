using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowMouseScript : MonoBehaviour
{
    private Transform objectFollowingMouse;
    // Start is called before the first frame update
    void Start()
    {
        objectFollowingMouse = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        objectFollowingMouse.position = Input.mousePosition;
    }
}
