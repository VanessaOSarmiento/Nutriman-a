using UnityEngine;

/// <summary>
/// Clase que representa un producto en el mercado.
/// </summary>
[System.Serializable]
public class Producto
{
    [Tooltip("Identificador único del producto")]
    public string id;
    
    [Tooltip("Nombre comercial del producto")]
    public string nombre;
    
    [Tooltip("Breve descripción del producto")]
    public string descripcion;
    
    [Tooltip("Precio de venta en la tienda")]
    public int precio;
    
    [Tooltip("Icono que se mostrará en la interfaz")]
    public Sprite icono;
}
