namespace FinalTask14_OrderBy__Skip_
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            var sortedPhoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName);
            int i = 0;
            while (true)
            {
                IEnumerable<Contact> page;
                if(i != 0)
                    Console.WriteLine();
                Console.WriteLine("Enter a page number: ");
                var key = Console.ReadKey().KeyChar;
                Console.Clear();
                
                switch (key)
                {
                    
                    case '1':
                        page = sortedPhoneBook.Take(2);
                        break;
                    case '2':
                        page = sortedPhoneBook.Skip(2).Take(2);
                        break ;
                    case '3':
                        page = sortedPhoneBook.Skip(4).Take(2);
                        break;
                    default:
                        Console.WriteLine("Page does'nt exist.");
                        i++;
                        continue;
                        
                }
                Console.WriteLine($"Contacts(page {key}):");
                foreach(Contact contact in page)
                    Console.WriteLine(contact.Name + ", " + contact.LastName + ", " + contact.Email);
                i++;
            }
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}