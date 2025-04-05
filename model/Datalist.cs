using SQLite;
public class Datalist
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; set; }


    // Store the image as a byte array (BLOB)
    public byte[] ImageData { get; set; }

    // Store the image file name
    public string ImageName { get; set; }

    // Store the age
    public int? Age { get; set; }

    // Store the variety (e.g., category or type)
    public string? Variety { get; set; }
}