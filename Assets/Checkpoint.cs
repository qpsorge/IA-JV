using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject m_game;
    public GameObject m_win;
    public AudioClip victory_song;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            m_win.SetActive(true);
            m_game.SetActive(false);

            audio = Camera.main.GetComponent<AudioSource>();
            audio.clip = victory_song;
            audio.Play();
        }
    }
}
