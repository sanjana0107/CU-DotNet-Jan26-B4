namespace Day34Exercise
{
    public class Person
    {
        public List<Person> Friends = new List<Person>();
        public string Name { get; set; }

        public Person(string name) => Name = name;
      
        public void AddFriend(Person friend)
        {
            if (!Friends.Contains(friend))
            {
                Friends.Add(friend);
                friend.Friends.Add(this);
            }           
        }
    }

    class SocialNetwork
    {
        private List<Person> _members = new List<Person>();

        public void AddMember(Person member)
        {
            _members.Add(member);
        }
        public void ShowNetwork()
        {
            foreach(var member in _members)
            {
                Console.Write(member.Name+ " -> ");
                List<String> friendsList = new List<string>();
                foreach (var friend in member.Friends)
                {
                    friendsList.Add(friend.Name);
                }
                Console.WriteLine($"{string.Join(',', friendsList)}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();
            Person aman = new Person("Aman");
            Person Basant = new Person("Basant");
            Person Chutki = new Person("Chutki");
            Person David = new Person("David");

            network.AddMember(aman);
            network.AddMember(Basant);
            network.AddMember(Chutki);
            network.AddMember(David);

            aman.AddFriend(Basant);
            Basant.AddFriend(Chutki);
            Basant.AddFriend(David);
            David.AddFriend(aman);

            network.ShowNetwork();            
        }
    }
}
