using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask layerMask;
    public bool isGrounded = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
