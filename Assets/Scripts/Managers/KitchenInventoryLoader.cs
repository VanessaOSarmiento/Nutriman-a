using UnityEngine;
using System.Linq;

namespace Inventory
{
    /// <summary>
    /// Se encarga de filtrar los objetos de la cocina al cargar la escena,
    /// permitiendo solo la visibilidad de aquellos que el usuario compró.
    /// </summary>
    public class KitchenInventoryLoader : MonoBehaviour
    {
        [Header("Referencias")]
        [SerializeField, Tooltip("El contenedor de datos del inventario")]
        private InventoryData inventoryData;

        [Header("Configuración de Carga")]
        [SerializeField, Tooltip("Si es true, buscará automáticamente todos los PurchasableItem en la escena")]
        private bool autoFindItems = true;

        [SerializeField, Tooltip("Lista manual de items (opcional si autoFindItems es false)")]
        private PurchasableItem[] manualItems;

        private void Start()
        {
            ApplyInventoryFilter();
        }

        /// <summary>
        /// Filtra los objetos de la escena basándose en los datos del inventario.
        /// </summary>
        public void ApplyInventoryFilter()
        {
            if (inventoryData == null)
            {
                Debug.LogError("[KitchenInventoryLoader] No se ha asignado el InventoryData.");
                return;
            }

            PurchasableItem[] itemsToFilter = autoFindItems 
                ? Object.FindObjectsByType<PurchasableItem>(FindObjectsInactive.Include, FindObjectsSortMode.None) 
                : manualItems;

            int itemsActivated = 0;

            foreach (var item in itemsToFilter)
            {
                bool hasProduct = inventoryData.HasProduct(item.ProductId);
                item.SetVisible(hasProduct);
                
                if (hasProduct) itemsActivated++;
            }

            Debug.Log($"[KitchenInventoryLoader] Filtro aplicado. Items activados: {itemsActivated}/{itemsToFilter.Length}");
        }
    }
}
