using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;

    [SerializeField]
    float moveSpeed = 5f;

    Vector2 minBounds, maxBounds;

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }

    void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x, maxBounds.x);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y, maxBounds.y);
        transform.position = newPos;
    }

    void InitBounds()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
