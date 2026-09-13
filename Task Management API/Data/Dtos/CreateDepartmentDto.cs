namespace Task_Management_API.Data.Dtos
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
