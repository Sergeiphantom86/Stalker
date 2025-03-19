using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Mover))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private Mover _mover;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
    }

    void Update()
    {
        _mover.Walk(_inputReader.DirectionX, _inputReader.DirectionZ);
        _mover.ApplyGravity();
    }
}