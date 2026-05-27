using UnityEngine;

namespace Inventory
{
    /// <summary>
    /// Identifica un objeto físico en la escena que corresponde a un producto comprable.
    /// </summary>
    public class PurchasableItem : MonoBehaviour
    {
        [Header("Configuración de Producto")]
        [SerializeField, Tooltip("Debe coincidir exactamente con el ID definido en el scriptable object Producto")]
        private string productId;

        public string ProductId => productId;

        /// <summary>
        /// Método para configurar la visibilidad basado en el estado de compra.
        /// </summary>
        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }
    }
}
