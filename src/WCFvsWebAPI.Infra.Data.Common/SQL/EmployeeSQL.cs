namespace WCFvsWebAPI.Infra.Data.Common.SQL
{
    public class EmployeeSQL
    {
        public static string CommandTextAdd => "INSERT INTO Employee (Name, Email, Phone, Gender) VALUES (@Name, @Email, @Phone, @Gender); SELECT SCOPE_IDENTITY();";
        public static string CommandTextUpdate => "UPDATE Employee SET Name = @Name, Email = @Email, Phone = @Phone, Gender = @Gender WHERE EmployeeId = @EmployeeId;";
        public static string CommandTextGetById => "SELECT EmployeeId, Name, Email, Phone, Gender FROM Employee WHERE EmployeeId = @EmployeeId;";
        public static string CommandTextGelAll => "SELECT EmployeeId, Name, Email, Phone, Gender FROM Employee";
    }
}
