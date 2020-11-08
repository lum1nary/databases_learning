namespace Databases
{
    public class UserAgeItem
    {
        public int user_id { get; set; }
        public int age { get; set; }

        public UserAgeItem(int user_id, int age)
        {
            this.user_id = user_id;
            this.age = age;
        }
    }
}
