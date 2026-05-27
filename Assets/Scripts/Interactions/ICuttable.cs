using UnityEngine;

namespace Interactions
{
    /// <summary>
    /// Interfaz que define el comportamiento de un objeto que puede ser cortado.
    /// Permite desacoplar la lógica del cortador (cuchillo) de la implementación específica del objeto.
    /// </summary>
    public interface ICuttable
    {
        /// <summary>
        /// Método principal para ejecutar la acción de corte.
        /// </summary>
        void Cut();
    }
}
