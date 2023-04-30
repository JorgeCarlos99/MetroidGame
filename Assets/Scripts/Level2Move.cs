using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Level2Move : MonoBehaviour
{
    [SerializeField] private string newLevel;
    public GameObject player;
    public CinemachineVirtualCamera vcam;
    public Animator transition;

    private void Start()
    {
        //var cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(newLevel));
        }
    }

    IEnumerator LoadLevel(string levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
