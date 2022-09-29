namespace EmployeeManagementSystem.Services
{
    public class FormatClass : IFormatNumber
    {
        public string FormatNumber(int number)
        {
            return String.Format("{0:n0}",number);
            //"{0:n0} represents numbers with commas format where every fourth digit from the end 
            //has a comma
        }
    }
}
