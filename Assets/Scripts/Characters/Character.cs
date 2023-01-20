using Mono.Cecil;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

namespace Assets.Scripts.Characters
{
    public class Character: MonoBehaviour
    {
        [SerializeField] private CharacterStats stats;
        
        public CharacterExp characterExp { get; private set; }  
        public CharacterHealth _characterHealth { get; private set; }
        public CharacterAnimation _animation { get; private set; }
        public ManaCharacter _characterMana { get; private set; }

        private void Awake()
        {
            _characterHealth= GetComponent<CharacterHealth>();  
            _animation= GetComponent<CharacterAnimation>();
            _characterMana = GetComponent<ManaCharacter>();
            characterExp = GetComponent<CharacterExp>();
        }

        public void ResetCharacter()
        {
            _characterHealth.RestartCharacter();
            _animation.RestartCharacter();
            _characterMana.RestartMana();
        }

        private void AtributteAnswer(TypeAtributte type)
        {
            if (stats.pointAvailable > 0)
            {
                stats.pointAvailable--;
                switch (type)
                {
                    case TypeAtributte.Strenght:
                        stats.Strenght++;
                        stats.AddBonusAtributtesStrenght();
                        break;
                    case TypeAtributte.Intelligence:
                        stats.Intelligence++;
                        stats.AddBonusAtributtesIntelligence();
                        break;
                    case TypeAtributte.Destreza:
                        stats.Destreza++;
                        stats.AddBonusAtributtesDestreza();
                        break;
                }
            }
          
        }

        private void OnEnable()
        {
            AtributteButton.addEventAtributte += AtributteAnswer;
        }

        private void OnDisable()
        {
            AtributteButton.addEventAtributte -= AtributteAnswer;
        }

    }
}
