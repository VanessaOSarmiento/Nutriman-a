using UnityEngine;

namespace Interactions
{
    /// <summary>
    /// Componente encargado de detectar y activar la acción de corte en objetos compatibles.
    /// Se debe colocar en el objeto que actúa como herramienta de corte (ej. Cuchillo).
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class KnifeCutter : MonoBehaviour
    {
        [Header("Configuración de Detección")]
        [SerializeField, Tooltip("Velocidad mínima de impacto para activar el corte (opcional)")]
        private float minimumVelocity = 0.1f;

        [SerializeField, Tooltip("Capa (Layer) de los objetos cortables para optimizar")]
        private LayerMask cuttableLayer;

        /// <summary>
        /// Detecta la colisión física con otros objetos.
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            // Verificamos si el objeto colisionado está en la capa correcta (si se definió una)
            if (((1 << collision.gameObject.layer) & cuttableLayer) == 0 && cuttableLayer != 0) return;

            // Validamos la fuerza del impacto si es necesario
            if (collision.relativeVelocity.magnitude < minimumVelocity) return;

            // Buscamos la interfaz ICuttable en el objeto impactado
            // Se busca en el objeto mismo o en sus padres (por si el collider es un hijo)
            ICuttable cuttable = collision.gameObject.GetComponentInParent<ICuttable>();

            if (cuttable != null)
            {
                ExecuteCut(cuttable);
            }
        }

        /// <summary>
        /// Centraliza la ejecución del corte para facilitar expansiones futuras (ej. eventos, estadísticas).
        /// </summary>
        private void ExecuteCut(ICuttable cuttable)
        {
            cuttable.Cut();
            Debug.Log($"[KnifeCutter] Corte ejecutado en: {((MonoBehaviour)cuttable).name}");
        }

        // También podemos usar OnTriggerEnter si preferimos que el cuchillo "atraviese" el objeto
        private void OnTriggerEnter(Collider other)
        {
            ICuttable cuttable = other.GetComponentInParent<ICuttable>();
            if (cuttable != null)
            {
                ExecuteCut(cuttable);
            }
        }
    }
}
