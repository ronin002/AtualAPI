namespace AtualAPI.Dtos
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class CreateCompanyDto
    {

        public string NameCompany { get; set; }

    }


}
