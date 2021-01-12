using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    private Vector3 _guardPosition;
    private Animator _animator;
    private int _playerOnSightHash;
    private int _reachedGuardPointHash;
    private AudioSource audio;

    public GameObject m_game;
    public GameObject m_gameover;
    public AudioClip gameover_song;

    public float lookRadius=10f;
    public float deadRadius = 3f;
    public GameObject player;

    // Properties used by behaviors
    public Vector3 GuardPosition { get { return _guardPosition; } }
    public int ReachedGuardPointHash { get { return _reachedGuardPointHash; } }
    private void Start()
    {
        _guardPosition = transform.position;
        _animator = GetComponent<Animator>();
        _playerOnSightHash = Animator.StringToHash("PlayerOnSight");
        _reachedGuardPointHash = Animator.StringToHash("ReachedGuardPoint");
    }

    public void Update()
    {
        if ((player.transform.position - transform.position).magnitude < deadRadius)
        {
            Debug.Log("GAME OVER !!!!");

            m_gameover.SetActive(true);
            m_game.SetActive(false);

            audio = Camera.main.GetComponent<AudioSource>();
            audio.clip = gameover_song;
            audio.Play();
        }

        if ((player.transform.position-transform.position).magnitude < lookRadius)
            _animator.SetBool(_playerOnSightHash, true);
        else
            _animator.SetBool(_playerOnSightHash, false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool(_playerOnSightHash, true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool(_playerOnSightHash, false);
        }
    }

    /*
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    */
}
