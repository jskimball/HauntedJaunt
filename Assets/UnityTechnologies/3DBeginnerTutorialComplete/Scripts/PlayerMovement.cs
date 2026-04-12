using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    public AudioSource Footsteps;
    public AudioSource Heartbeat;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public TextMeshProUGUI distanceText;
    public GameEnding gameEnding;
    Vector3 endPoint;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        endPoint = GameObject.FindGameObjectWithTag("endPoint").transform.position;
        Footsteps.loop = true;
        Heartbeat.loop = true;
        Heartbeat.Play();
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!Footsteps.isPlaying)
            {
                Footsteps.Play();
            }
        }
        else
        {
            Footsteps.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

        SetDistanceText(FindDistance(m_Rigidbody.position, endPoint));
        SetPulse();
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    void SetDistanceText(float distanceToEnd)
    {
        distanceText.text = "Distance to End: " + Mathf.RoundToInt(distanceToEnd) + "m";
    }

    float FindDistance(Vector3 pos1, Vector3 pos2)
    {
        return (pos1 - pos2).magnitude;
    }

    GameObject findNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float smallestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = FindDistance(enemy.transform.position, m_Rigidbody.position);
            if (distance < smallestDistance) {
                smallestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    void SetPulse()
    {
        GameObject nearestEnemy = findNearestEnemy();
        float distanceToEnemy = FindDistance(nearestEnemy.transform.position, m_Rigidbody.position);

        if (distanceToEnemy < 3f)
        {
            Heartbeat.pitch = 2f;
        } 
        
        else if (distanceToEnemy < 4f)
        {
            Heartbeat.pitch = 1.7f;
        }
        
        else if (distanceToEnemy < 5f)
        {
            Heartbeat.pitch = 1.4f;
        }

        else
        {
            Heartbeat.pitch = 1f;
        }
    }
}