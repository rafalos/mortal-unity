using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openSprite;
    [SerializeField] BloodGlobe bloodGlobe;
    bool isOpen = false;

    private void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseDown() {
        Interact();
    }

    private void DropItems() {
        float random = Utils.GetRandomIntInRange(3, 6);
        for (int i = 0; i < random; i++) {
            var newPos = transform.position + Random.insideUnitSphere * 2;
            Instantiate(bloodGlobe, newPos, Quaternion.identity);
        }
    }

    public void Interact() {
        if(!isOpen) {
            spriteRenderer.sprite = openSprite;
            isOpen = true;
            DropItems();
        }  
    }
}
