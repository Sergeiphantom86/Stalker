using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public float DirectionX { get; private set; }
    public float DirectionZ { get; private set; }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        DirectionX = Input.GetAxis(Horizontal);
        DirectionZ = Input.GetAxis(Vertical);
    }
}