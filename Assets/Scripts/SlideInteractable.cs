using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SlideInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int sceneBuildIndex = 1;
    public void Interact(Transform interactorTransform)
    {
        playerController.enabled = false;
        GetComponent<PlayableDirector>().Play();
        GetComponent<PlayableDirector>().stopped += SlideInteractable_played;
    }

    private void SlideInteractable_played(PlayableDirector obj)
    {
        Debug.Log("Load scene");
        SceneManager.LoadScene(sceneBuildIndex);
        GetComponent<PlayableDirector>().played -= SlideInteractable_played;
    }

    public string GetInteractText()
    {
        return "Go To The Slide";
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
