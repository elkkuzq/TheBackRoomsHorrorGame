using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public static int pillsEaten { get; private set; }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null) {
                interactable.Interact(transform);
                if (interactable.GetTransform().TryGetComponent(out PillBottleInteractable pillBottle)){
                    pillsEaten++;
                }
            }
        }
    }

    public IInteractable GetInteractableObject() {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 1f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if (collider.TryGetComponent(out IInteractable interactable)) {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList) {
            if (closestInteractable == null) {
                closestInteractable = interactable;
            } else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position)) {
                    // Closer
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }

}