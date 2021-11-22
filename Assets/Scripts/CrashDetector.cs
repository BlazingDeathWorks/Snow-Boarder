using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashEffect = null;
    [SerializeField] private AudioClip crashSFX = null;
    private bool hasCollided = false;

    private void Awake()
    {
        hasCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollided == false && collision.CompareTag("Ground"))
        {
            hasCollided = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", 1f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
