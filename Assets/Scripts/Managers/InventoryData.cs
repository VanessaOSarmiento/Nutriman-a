using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    /// <summary>
    /// Objeto de datos persistente que almacena los productos adquiridos por el usuario.
    /// Al ser ScriptableObject, los datos pueden persistir entre escenas y ser configurados en el editor.
    /// </summary>
    [CreateAssetMenu(fileName = "NewInventoryData", menuName = "Inventory/Inventory Data")]
    public class InventoryData : ScriptableObject
    {
        [SerializeField, Tooltip("Lista de IDs de productos comprados")]
        private List<string> purchasedProductIds = new List<string>();

        /// <summary>
        /// Agrega un producto a la lista de comprados si no existe.
        /// </summary>
        public void AddProduct(string productId)
        {
            if (!purchasedProductIds.Contains(productId))
            {
                purchasedProductIds.Add(productId);
            }
        }

        /// <summary>
        /// Verifica si un producto ha sido comprado.
        /// </summary>
        public bool HasProduct(string productId)
        {
            return purchasedProductIds.Contains(productId);
        }

        /// <summary>
        /// Limpia el inventario (útil al reiniciar el juego).
        /// </summary>
        public void ClearInventory()
        {
            purchasedProductIds.Clear();
        }

        /// <summary>
        /// Retorna una copia de la lista de IDs comprados.
        /// </summary>
        public List<string> GetPurchasedIds() => new List<string>(purchasedProductIds);
    }
}
