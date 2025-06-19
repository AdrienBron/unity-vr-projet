using UnityEngine;


public class AutoGrabParchment : MonoBehaviour
{
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor;
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    void Start()
    {
        if (interactor != null && interactable != null)
        {
            // Correction pour StartManualInteraction
            interactor.StartManualInteraction(interactable as UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable);
        }
    }

    void OnDestroy()
    {
        if (interactor != null && interactable != null)
        {
            // Option 1: Essayez EndManualInteraction au lieu de StopManualInteraction
            interactor.EndManualInteraction();
            
            // Option 2: Si EndManualInteraction n'existe pas non plus, utilisez :
            // if (interactor.hasSelection)
            // {
            //     interactor.EndManualInteraction();
            // }
            
            // Option 3: Pour les versions plus récentes, essayez :
            // interactor.ClearSelection();
        }
    }
}