using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestor principal del mercado. Se encarga de mostrar los productos,
/// manejar el saldo del usuario y procesar las compras.
/// </summary>
public class MarketManager : MonoBehaviour
{
    [Header("Configuración de mercado")]
    [Tooltip("Lista de productos disponibles para la venta")]
    public List<Producto> productos = new List<Producto>();

    [Tooltip("Prefab que se usará para representar cada producto en la UI")]
    public GameObject itemPrefab;
    
    [Tooltip("Contenedor (Layout) donde se instanciarán los productos")]
    public Transform contenedorProductos;

    [Header("Saldo")]
    [Tooltip("Texto UI que muestra el saldo actual")]
    public Text saldoText;
    
    [Tooltip("Saldo con el que inicia el usuario")]
    public int saldoInicial = 1000;

    private int saldo;

    void Start()
    {
        // Inicializamos el saldo y preparamos la interfaz
        saldo = saldoInicial;
        ActualizarSaldo();
        RenderizarProductos();
    }

    /// <summary>
    /// Actualiza el componente de texto de la UI con el saldo actual.
    /// </summary>
    void ActualizarSaldo()
    {
        if (saldoText != null)
        {
            saldoText.text = $"Saldo: ${saldo}";
        }
    }

    /// <summary>
    /// Limpia el contenedor y genera los elementos de UI para cada producto.
    /// </summary>
    void RenderizarProductos()
    {
        if (itemPrefab == null || contenedorProductos == null)
        {
            Debug.LogWarning("MarketManager: itemPrefab o contenedorProductos no asignado.");
            return;
        }

        // Eliminamos elementos previos antes de renderizar
        foreach (Transform child in contenedorProductos)
        {
            Destroy(child.gameObject);
        }

        // Generamos un item de UI por cada producto definido
        foreach (Producto producto in productos)
        {
            GameObject item = Instantiate(itemPrefab, contenedorProductos);

            // Configuramos los textos de Nombre y Precio
            Text[] textos = item.GetComponentsInChildren<Text>(true);
            if (textos.Length > 0)
            {
                textos[0].text = producto.nombre;
            }

            if (textos.Length > 1)
            {
                textos[1].text = $"${producto.precio}";
            }

            // Configuramos el icono si existe
            Image icono = item.GetComponentInChildren<Image>(true);
            if (icono != null && producto.icono != null)
            {
                icono.sprite = producto.icono;
            }

            // Configuramos el botón de compra
            Button botonCompra = item.GetComponentInChildren<Button>(true);
            if (botonCompra != null)
            {
                botonCompra.onClick.RemoveAllListeners();
                botonCompra.onClick.AddListener(() => ComprarProducto(producto, botonCompra));
            }
        }
    }

    /// <summary>
    /// Procesa la compra de un producto restando el saldo y desactivando el botón si la compra es exitosa.
    /// </summary>
    public void ComprarProducto(Producto producto, Button boton)
    {
        if (producto == null)
        {
            Debug.LogWarning("MarketManager: producto null.");
            return;
        }

        // Verificamos si hay saldo suficiente
        if (saldo >= producto.precio)
        {
            saldo -= producto.precio;
            ActualizarSaldo();
            Debug.Log($"Comprado: {producto.nombre} por ${producto.precio}. Saldo ${saldo}.");

            // Desactivamos el botón para evitar compras duplicadas si se desea
            if (boton != null)
            {
                boton.interactable = false;
            }
        }
        else
        {
            Debug.LogWarning("Saldo insuficiente para comprar " + producto.nombre);
        }
    }
}
