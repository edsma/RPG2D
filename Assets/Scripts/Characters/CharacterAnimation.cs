using Assets.Scripts;
using Assets.Scripts.Common;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerWalking;
    [SerializeField] private string layerAttack;

    private Animator _animator;
    private MovementCharacter _characterMovement;
    private CharacterAttack _characterAttack;
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _characterMovement = GetComponent<MovementCharacter>();
        _characterAttack = GetComponent<CharacterAttack>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateLayer();
        if (!_characterMovement.isMoving)
        {
            return;
        }
        _animator.SetFloat(Constants.ParamsAnimations.x, _characterMovement.MovementDirection.x);
        _animator.SetFloat(Constants.ParamsAnimations.y, _characterMovement.MovementDirection.y);
    }

    void ActivateLayer(string layer)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i,0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(layer ),1);
    }

    void UpdateLayer()
    {

        if (_characterAttack.isAttacking)
        {
            ActivateLayer(layerAttack);
        }else if (_characterMovement.isMoving)
        {
            ActivateLayer(layerWalking);
        }
        else
        { 
            ActivateLayer(layerIdle);
        }    
    }

    private void CharacterIsDefeatedAnswer()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)).Equals(1))
        {
            _animator.SetBool(Constants.ParamsAnimations.death,true);
        }
    }

    public void RestartCharacter()
    {
        ActivateLayer(layerIdle);
        _animator.SetBool(Constants.ParamsAnimations.death,false);
    }

    private void OnEnable()
    {
        CharacterHealth.EventCharacterDefeated += CharacterIsDefeatedAnswer;
    }

    private void OnDisable()
    {
        CharacterHealth.EventCharacterDefeated -= CharacterIsDefeatedAnswer;
    }
}
