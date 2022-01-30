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
    protected bool readyToInteract = false;

    protected virtual void Update()
    {
        overlapedColliders = Physics2D.OverlapCircleAll(interactionAreaPivot.position, interactionAreaRadio);

        readyToInteract = false;
        if (overlapedColliders.Length > 0)
        {
            foreach (Collider2D objCollider in overlapedColliders)
            {
                readyToInteract = objCollider.CompareTag(K.Tag.player);
            }
        }
        
        print(readyToInteract);
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

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(interactionAreaPivot && interactionAreaRadio > 0f)
        Gizmos.DrawWireSphere(interactionAreaPivot.position, interactionAreaRadio);
    }

    public virtual void Interact()
    {
        
        print("Interacting...");

    }

    protected void Dialog()
    {

    }
}
