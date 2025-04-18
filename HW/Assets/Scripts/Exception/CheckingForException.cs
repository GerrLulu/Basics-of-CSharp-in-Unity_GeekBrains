using UnityEngine;

namespace ExceptionNS
{
    public class CheckingForException : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            try
            {
                if (!other.CompareTag("Level"))
                    return;
                throw new GameDesignerException("Перешел через", tag, other.tag);
            }
            catch(GameDesignerException e)
            {
                Debug.LogWarning($"Объект {e.TagPlayer} {e.Message} {e.TagLevelObject}");
            }
        }
    }
}