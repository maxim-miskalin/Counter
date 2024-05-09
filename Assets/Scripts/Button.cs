using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action Switching;

    public bool IsMouseClick { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Toggle();
            Switching?.Invoke();
        }
    }

    private void Toggle()
    {
        if (IsMouseClick)
            IsMouseClick = false;
        else
            IsMouseClick = true;
    }
}
