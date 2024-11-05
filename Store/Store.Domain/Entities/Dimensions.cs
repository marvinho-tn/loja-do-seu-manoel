namespace Store.Domain.Entities;

public class Dimensions
{
    public Dimensions()
    {
        
    }

    public Dimensions(bool newObj)
    {
        Id = newObj ? Guid.NewGuid() : null;
    }
    
    public Guid? Id { get; set; }
    
    /// <summary>
    /// Largura do objeto.
    /// </summary>
    public uint Width { get; set; }
    
    /// <summary>
    /// Altura do objeto.
    /// </summary>
    public uint Height { get; set; }
    
    /// <summary>
    /// Comprimento do objeto.
    /// </summary>
    public uint Length { get; set; }

    /// <summary>
    /// Volume do objeto.
    /// </summary>
    public uint Volume => Height * Width * Length;
}