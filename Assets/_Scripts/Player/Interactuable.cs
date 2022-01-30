using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    [SerializeField] protected bool interactionEnabled = true;
    [Header("Interaction area attributes")]
    [SerializeField] protected Transform interactionAreaPivot;
    [SerializeField] protected float interactionAreaRadio;

    private Collider2D[] overlapedColliders;
    private bool readyToInteract = false;

    private void Update()
    {
        overlapedColliders = Physics2D.OverlapCircleAll(interactionAreaPivot.position, interactionAreaRadio);
        if(overlapedColliders.Length > 0)
        {
            foreach (Collider2D objCollider in overlapedColliders)
            {
                if (objCollider.CompareTag(K.Tag.player))
                {
                    readyToInteract = true;
                }
            }
        }

        //DEBUG
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(K.Tag.player))
        {
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(interactionAreaPivot && interactionAreaRadio > 0f)
        Gizmos.DrawWireSphere(interactionAreaPivot.position, interactionAreaRadio);
    }

    public void Interact()
    {
        //Logic to interact and perform required actions
        if (!interactionEnabled || !readyToInteract)
            return;

        print("Interacting...");

    }

    protected void Dialog()
    {

    }
}
