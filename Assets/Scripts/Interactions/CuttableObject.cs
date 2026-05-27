using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    /// <summary>
    /// Implementación base para objetos cortables. 
    /// Maneja el intercambio del objeto original por su versión procesada (cortada).
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class CuttableObject : MonoBehaviour, ICuttable
    {
        [Header("Configuración de Corte")]
        [SerializeField, Tooltip("Prefab que representa el objeto ya cortado")]
        private GameObject choppedPrefab;

        [SerializeField, Tooltip("Efecto visual o de partículas opcional al cortar")]
        private GameObject cutEffectPrefab;

        [Header("Ajustes de Sonido")]
        [SerializeField] private AudioClip cutSound;
        [SerializeField, Range(0, 1)] private float volume = 1f;

        [Header("Eventos")]
        public UnityEvent OnObjectCut;

        private bool _isChopped = false;

        /// <summary>
        /// Ejecuta la lógica de transformación del objeto.
        /// </summary>
        public void Cut()
        {
            if (_isChopped) return;
            
            _isChopped = true;
            ProcessCut();
            
            // Disparar evento para sistemas externos (Logros, Misiones, etc.)
            OnObjectCut?.Invoke();
        }

        private void ProcessCut()
        {
            // Reproducir sonido si existe
            if (cutSound != null)
            {
                AudioSource.PlayClipAtPoint(cutSound, transform.position, volume);
            }

            // Instanciar efecto visual
            if (cutEffectPrefab != null)
            {
                Instantiate(cutEffectPrefab, transform.position, Quaternion.identity);
            }

            // Instanciar la versión cortada
            if (choppedPrefab != null)
            {
                GameObject choppedInstance = Instantiate(choppedPrefab, transform.position, transform.rotation);
                choppedInstance.transform.localScale = transform.localScale;
                
                Rigidbody rb = GetComponent<Rigidbody>();
                Rigidbody choppedRb = choppedInstance.GetComponent<Rigidbody>();
                if (rb != null && choppedRb != null)
                {
                    choppedRb.linearVelocity = rb.linearVelocity;
                    choppedRb.angularVelocity = rb.angularVelocity;
                }
            }
            else
            {
                Debug.LogWarning($"[CuttableObject] No se ha asignado un 'choppedPrefab' en {gameObject.name}");
            }

            Destroy(gameObject);
        }
    }
}
