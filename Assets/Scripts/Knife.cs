using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
{
    left = 0,
    right = 1,
    up = 2,
    down = 3
}

public class Knife : MonoBehaviour
{
    public float Speed = 12.5f;
    public bool Moving;
    public Direction m_direction;
    public Vector3 directionTo;

    private void Awake()
    {
        m_direction = Direction.up;
    }


    void Start()
    {
        Moving = false;

        Move();
    }

    private void LateUpdate()
    {
        directionTo = Vector3.up;

        if (Moving)
        {
            switch (m_direction)
            {
                case Direction.left:
                    directionTo = Vector3.left;
                    break;
                case Direction.right:
                    directionTo = Vector3.right;
                    break;
                case Direction.up:
                    directionTo = Vector3.up;
                    break;
                case Direction.down:
                    directionTo = Vector3.down;
                    break;
            }

            transform.Translate(directionTo * Time.deltaTime * Speed,Space.World);

        }
    }

    public void Move()
    {
        Moving = true;

        switch (m_direction)
        {
            case Direction.left:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.right:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case Direction.up:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case Direction.down:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Moving = false;

        if (collision.gameObject.name.Equals("shield"))
            transform.SetParent(collision.gameObject.transform);
        else if (collision.gameObject.name.Equals("kunai"))
            Destroy(gameObject);
    }

}
