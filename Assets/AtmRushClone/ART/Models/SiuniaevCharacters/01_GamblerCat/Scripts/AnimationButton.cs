using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnimationButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [Header("Trigger settings")]
    [SerializeField] private string _name;
    [SerializeField] private AnimatorControllerParameterType _type;
    [SerializeField] private float _value;

    public Button Button { get; private set; }

    private void Awake() =>
        Button = GetComponent<Button>();

    private void Start() =>
        Button.onClick.AddListener(OnClick);

    private void OnClick()
    {
        ResetTriggers();
        InvokeTrigger();
    }

    private void InvokeTrigger()
    {
        switch (_type)
        {
            case AnimatorControllerParameterType.Trigger:
                _animator.SetTrigger(_name);
                break;

            case AnimatorControllerParameterType.Float:
                _animator.SetFloat(_name, _value);
                break;
        }
    }

    private void ResetTriggers()
    {
        foreach (var parameter in _animator.parameters)
        {
            switch (parameter.type)
            {
                case AnimatorControllerParameterType.Trigger:
                    _animator.ResetTrigger(parameter.name);
                    break;

                case AnimatorControllerParameterType.Float:
                    _animator.SetFloat(parameter.name, 0f);
                    break;
            }
        }
    }
}