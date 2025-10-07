using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSpaceScript : MonoBehaviour
{
    [SerializeField] public Vector3 draggingPosition;
    [SerializeField] public bool withinValidSpace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (withinValidSpace)
        {
            draggingPosition = this.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InvalidSpace"))
        {
            withinValidSpace = false;
        }
        else if (collision.CompareTag("ValidSpace"))
        {
            withinValidSpace = true;
        }
    }
}
