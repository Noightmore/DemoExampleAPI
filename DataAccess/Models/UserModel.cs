namespace DataAccess.Models;

public class UserModel
{
     public int UID { get; set; }
     public string UFirstName { get; set; }
     public string ULastName { get; set; }
     public bool UGender { get; set; }
     public string? UEmail { get; set;}
     public DateTime UBirthDate { get; set; }
}