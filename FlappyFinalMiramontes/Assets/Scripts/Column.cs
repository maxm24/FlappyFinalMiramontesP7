using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public AudioClip score;
    private void OnTriggerEnter2D (Collider2D other)
    {
        Bird controller = other.GetComponent<Bird>();

        if (other.GetComponent<Bird> () != null)
        {
            GameControl.Instance.BirdScored();
            controller.PlaySound(score);
        }
    }
}
