using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderResize : MonoBehaviour
{
    public BoxCollider2D thisCollider;
    public Transform thisColliderHolder;
    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<BoxCollider2D>();
        thisColliderHolder = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        thisCollider.size = new Vector2(thisColliderHolder.GetComponent<RectTransform>().rect.width, thisColliderHolder.GetComponent<RectTransform>().rect.height);
    }
}
