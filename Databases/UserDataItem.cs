namespace Databases
{
    public class UserDataItem
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string email2 { get; set; }
        public string profession { get; set; }

        public UserDataItem(int id, string firstname, string lastname, string email, string email2, string profession)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.email2 = email2;
            this.profession = profession;
        }

        public override string ToString()
        {
            return $"Id: {id}; " +
                $"FirstName: {firstname}; " +
                $"LastName: {lastname}; " +
                $"Email: {email}; " +
                $"Email2: {email2}; " +
                $"Profession: {profession}; ";
        }
    }
}
