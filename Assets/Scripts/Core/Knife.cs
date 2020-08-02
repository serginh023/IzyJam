using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
    public float Speed = 12.5f;
    public bool IsMoving;
    public bool IsAwaking;
    public bool isActive = true;
    Vector3 m_startPosition;

    public delegate void KnifeHitEventHandler(HitType hitType);
    public static event KnifeHitEventHandler HitEvent;
    public delegate void KnifeCrashEventHandler();
    public static event KnifeCrashEventHandler CrashEvent;


    void Start()
    {
        IsMoving = false;
        IsAwaking = true;
    }

    private void Update()
    {
        if (IsMoving)
            transform.Translate(Vector3.up * Time.deltaTime * Speed,Space.World);

        if (IsAwaking)
        {
            transform.position = Vector3.Lerp(transform.position, m_startPosition, .05f);
        }
            

    }

    public void Awaking(Vector3 targetPosition)
    {
        m_startPosition = targetPosition;
    }

    public void Throw()
    {
        IsMoving = true;
        IsAwaking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            if (collision.gameObject.tag == "target")
            {
                IsMoving = false;
                transform.SetParent(collision.gameObject.transform);
                if (HitEvent != null)
                    HitEvent(HitType.simpleHit);
                isActive = false;
            }
            else if (collision.gameObject.tag == "knife")
            {
                if (HitEvent != null)
                    CrashEvent();
                gameObject.SetActive(false);
            }else if (collision.gameObject.tag == "apple")
            {
                if (HitEvent != null)
                    HitEvent(HitType.appleHit);
            }
                
        }
            
    }

}
