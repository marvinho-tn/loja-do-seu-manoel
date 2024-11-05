namespace Store.Domain.Entities;

/// <summary>
/// Classe de molde de caixa que não representa a caixa fisica mas os modelos disponíveis existentes.
/// </summary>
public class BoxMold 
{ 
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