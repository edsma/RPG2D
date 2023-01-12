using Assets.Scripts;
using UnityEngine;

public class ManaCharacter : MonoBehaviour
{
    [SerializeField] private float initialMana;
    [SerializeField] private float maxMana;
    [SerializeField] private float regenerationForSecond;

    public float ActualMana { get; private set; }
    private CharacterHealth _characterHealth;

    private void Awake()
    {
        _characterHealth= GetComponent<CharacterHealth>();  
    }

    // Start is called before the first frame update
    void Start()
    {
        ActualMana = initialMana;
        UpdateManaBar();
        InvokeRepeating(nameof(RegenerateMana),1,1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UseMana(10f);
        }
    }

    public void UseMana(float quantity)
    {
        if (ActualMana >= quantity)
        {
            ActualMana -= quantity;
            UpdateManaBar();
        }
    }

    private void RegenerateMana()
    {
        if (_characterHealth.Health > 0f && ActualMana < maxMana)
        {
            ActualMana += regenerationForSecond;
            UpdateManaBar();
        }
    }

    public void RestartMana()
    {
        ActualMana = initialMana;
        UpdateManaBar();
    }

    private void UpdateManaBar()
    {
        UIManager.Instance.UpdateManaForCharacter(ActualMana,initialMana);
    }
}
