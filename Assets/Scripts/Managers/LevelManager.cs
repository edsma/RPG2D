using Assets.Scripts.Characters;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class LevelManager:MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private Transform pointRestart;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y) && character._characterHealth.IsCharacterDefeated)
            {
                character.transform.localPosition = pointRestart.position;
                character.ResetCharacter();
            }
        }
    }
}
