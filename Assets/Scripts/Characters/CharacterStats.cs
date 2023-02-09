using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class CharacterStats : ScriptableObject
{
    [Header("Stats")]
    public float damage;
    public float defense;
    public float Velocity;
    public float Level;
    public float ExpActual;
    public float ExpForNextLevel;
    [Range(0f,100f)] public float percentajeForCritic;
    [Range(0f, 100f)] public float percentajeBlock;

    [Header("Atributtes")]
    public int Strenght;
    public int Intelligence;
    public int Destreza;

    public int pointAvailable;

    public void AddBonusAtributtesStrenght()
    {
        damage += 2f;
        defense += 1f;
        percentajeBlock += 0.03f;
    }

    public void AddBonusAtributtesIntelligence()
    {
        damage += 1f;
        percentajeForCritic += 0.30f;
    }

    public void AddBonusForWeapon(Weapon weapon)
    {
        damage += weapon.damage;
        percentajeForCritic +=  weapon.criticDamage;
        percentajeBlock += weapon.blockPosibility;
    }

    public void RemoveBonusForWeapon(Weapon weapon)
    {
        damage -= weapon.damage;
        percentajeForCritic -= weapon.criticDamage;
        percentajeBlock -= weapon.blockPosibility;
    }

    public void AddBonusAtributtesDestreza()
    {
        Velocity += 0.5f;
        percentajeBlock += 0.1f;
    }

    public void ResetValues()
    {
        damage = 5f;
        defense = 2f;
        Velocity = 10f;
        Level= 1f;
        ExpActual = 1f;
        ExpForNextLevel = 10f;
        percentajeBlock= 1f;
        percentajeForCritic= 1f;
        Strenght = 0;
        Intelligence = 0;
        Destreza = 0;

        pointAvailable= 0;
    }
}
