using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public Transform player;

    [SerializeField] Transform interactionPoint;
    [SerializeField] float interactionRange = 1f;

    [SerializeField] LayerMask interactionLayers;

    void Update()
    {
        Interact();
    }

    void Interact()
    {
        Collider2D interactable = Physics2D.OverlapCircle(interactionPoint.position, interactionRange, interactionLayers);

        if(interactable != null)
        {
            Transform hidingSpot = interactable.transform;
            Transform botao = interactable.transform.GetChild(0);
            botao.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if(Input.GetButtonDown("Fire3"))
            {
                if(interactable.gameObject.CompareTag("HidingSpot"))
                {
                    if (player.GetComponent<SpriteRenderer>().enabled == false && player.position.x == hidingSpot.position.x)
                    {
                        player.GetComponent<SpriteRenderer>().enabled = true;
                        player.GetComponent<PlayerMovement>().enabled = true;
                        player.GetComponent<BoxCollider2D>().enabled = true;
                    }
                    else
                    {
                        Vector2 hidingPos = new Vector2(hidingSpot.position.x, player.position.y);

                        player.GetComponent<SpriteRenderer>().enabled = false;
                        player.GetComponent<PlayerMovement>().enabled = false;
                        player.GetComponent<BoxCollider2D>().enabled = false;

                        player.position = hidingPos;
                    }
                }
                if (interactable.gameObject.CompareTag("NextLevel"))
                {
                    interactable.GetComponent<ChangeScenee>().ChangeSc();
                }
            }
        }
        else
        {
            DisableButton();
        }
    }

    void DisableButton()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach(GameObject button in buttons)
        {
            button.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(interactionPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    }
}
