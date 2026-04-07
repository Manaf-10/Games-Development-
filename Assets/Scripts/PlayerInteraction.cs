using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2f;
    public LayerMask interactableLayer;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
    
            if (interactable != null && interactable.isInteractable)
            {
                UIManager.Instance.ShowHoverText(interactable.InteractionText, interactable.LabelAnchor.position);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        else
        {
            UIManager.Instance.HideHoverText();
        }
    }
}