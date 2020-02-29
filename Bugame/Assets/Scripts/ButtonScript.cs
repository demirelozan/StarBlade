using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask PlayerLayer;
    private CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    public bool IsClicked()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.up, circleCollider.bounds.extents.y - 0.1f,PlayerLayer );
        Color rayColor;
        bool __state = (raycastHit.collider != null);
        rayColor = (__state) ? Color.green : Color.red;
        Debug.DrawRay(circleCollider.bounds.center, Vector2.up, rayColor);
        return __state;
    }
}
