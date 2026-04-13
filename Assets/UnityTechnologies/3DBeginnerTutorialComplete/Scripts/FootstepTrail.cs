using UnityEngine;

public class FootstepTrail : MonoBehaviour
{
    public ParticleSystem ps;
    private Animator _animator;

    void Awake() => _animator = GetComponent<Animator>();

    void Update()
    {
        bool moving = _animator.GetBool("IsWalking");

        if (moving && !ps.isEmitting) ps.Play();
        if (!moving && ps.isEmitting) ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}