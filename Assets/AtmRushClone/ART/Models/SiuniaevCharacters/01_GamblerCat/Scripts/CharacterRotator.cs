using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterRotator : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Transform _character;
    [SerializeField] private float _rotationSpeed;

    private bool _isRotating;
    private Vector3 _targetPoint;

    private void Update()
    {
        if (_isRotating)
            Rotate();
    }

    public void OnPointerDown(PointerEventData _)
    {
        _targetPoint = Input.mousePosition;
        _isRotating = true;
    }

    public void OnPointerUp(PointerEventData _) =>
        _isRotating = false;

    private void Rotate()
    {
        if (!_character)
            return;

        var targetPoint = Input.mousePosition;
        _character.Rotate(Vector3.up * (_rotationSpeed * (_targetPoint - targetPoint).x * Time.deltaTime));
        _targetPoint = targetPoint;
    }
}