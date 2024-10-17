namespace Store.Domain.Entities;

public class Measurable
{
    public uint Width { get; set; }
    public uint Height { get; set; }
    public uint Length { get; set; }

    public uint Volume => Height * Width * Length;
}