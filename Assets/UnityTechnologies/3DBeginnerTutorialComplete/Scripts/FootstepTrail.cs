using UnityEngine;

public class FootstepTrail : MonoBehaviour
{
    public ParticleSystem ps;
    private Animator _animator;

    void Awake() => _animator = GetComponent<Animator>();

    void Update()
    {
        bool moving = _animator.GetBool("IsWalking");

        if (moving && !ps.isPlaying) ps.Play();
        if (!moving && ps.isPlaying) ps.Stop();

        Debug.Log("isPlaying: " + ps.isPlaying + " | particles: " + ps.particleCount);
    }
}