using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask PlayerLayer;
    public bool IsClicked()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.up, circleCollider.bounds.extents.y - 0.1f,PlayerLayer );
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;

        }
        else
        {
            rayColor = Color.red;

        }
        Debug.DrawRay(circleCollider.bounds.center, Vector2.up, rayColor);

        return raycastHit.collider != null;
    }

    private CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        
    }
    
}
