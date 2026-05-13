using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastScript : MonoBehaviour
{
    public float raycastDistance = 5f;
    bool holdingItem = false;
    GameObject heldObject;

    public GameObject Player;


    public Rigidbody rb;
    public FallingFix fallingFix;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
    }

    public void PickUpItem(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("PickupItem"))
                {
                    hit.collider.GetComponent<PickupObject>().PickUp();
                    holdingItem = true;
                    heldObject = hit.collider.gameObject;
                    rb = heldObject.GetComponent<Rigidbody>();
                    rb.excludeLayers = LayerMask.GetMask("Player");
                    fallingFix = heldObject.GetComponent<FallingFix>();
                    fallingFix.enabled = false;
                    //hit.collider.tag = "Untagged";
                }
            }
        }
        if (ctx.canceled)
        {
            if (holdingItem)
            {
                heldObject.GetComponent<PickupObject>().PickUp();
                holdingItem = false;
                rb.excludeLayers = 0;
                heldObject = null;
                fallingFix.enabled = true;
                fallingFix.ResetPosition();
            }
        }
    }


}
