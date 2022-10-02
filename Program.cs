using System;

namespace Rookies.core // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public class Members
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string PhoneNumber { get; set; }
            public string BirthPlace { get; set; }

            public int Age { get; set; }
            public bool IsGraduated { get; set; }

            public Members(string firstname, string lastname, string gender, DateTime dob, string phonenumer
            , string birthplace, int age, bool isgraduated)
            {
                FirstName = firstname;
                LastName = lastname;
                Gender = gender;
                DateOfBirth = dob;
                PhoneNumber = phonenumer;
                BirthPlace = birthplace;
                Age = age;
                IsGraduated = isgraduated;
            }
            public Members()
            {

            }


            public override string ToString()
            {
                return $"Member's Information: FirstName: {FirstName} – LastName: {LastName} – Gender:{Gender} -Age: {Age} - Phone : {PhoneNumber} - Date of birth: {DateOfBirth} - Birth Place: {BirthPlace} - IsGraduated:{IsGraduated} ";
            }
        }

        static void Main(string[] args)
        {
            int n;
            System.Console.WriteLine("Case 0:Show all");
            System.Console.WriteLine("Case 1:A list of members who is Male");
            System.Console.WriteLine("Case 2:The oldest one based on “Age”");
            System.Console.WriteLine("Case 3:A new list that contains Full Name only");
            System.Console.WriteLine("Case 4 :List of members who has birth year is 2000");
            System.Console.WriteLine("Case 5 :List of members who has birth year greater than 2000");
            System.Console.WriteLine("Case 6 :List of members who has birth year less than 2000");
            System.Console.WriteLine("Case 7 :Return the first person who was born in Ha Noi.");
            System.Console.WriteLine("Enter option: ");
            

            List<Members> mb = new List<Members>();
            mb.Add(new Members { FirstName = "Phan", LastName = "Nam", Gender = "Male", DateOfBirth = new DateTime(1999, 10, 18), PhoneNumber = "0396373132", BirthPlace = "Ha Noi", Age = 21, IsGraduated = true });
            mb.Add(new Members { FirstName = "Tran", LastName = "Linh", Gender = "FeMale", DateOfBirth = new DateTime(2003, 10, 15), PhoneNumber = "0396373132", BirthPlace = "Bac Ninh", Age = 29, IsGraduated = false });
            mb.Add(new Members { FirstName = "Dao", LastName = "Trang", Gender = "FeMale", DateOfBirth = new DateTime(2003, 07, 13), PhoneNumber = "0396373132", BirthPlace = "SG", Age = 29, IsGraduated = true });
            mb.Add(new Members { FirstName = "Vu", LastName = "Kim", Gender = "Male", DateOfBirth = new DateTime(2003, 11, 30), PhoneNumber = "0396373132", BirthPlace = "Ha Noi", Age = 29, IsGraduated = true });
            mb.Add(new Members { FirstName = "Duy", LastName = "Anh", Gender = "Male", DateOfBirth = new DateTime(2000, 11, 30), PhoneNumber = "0396373132", BirthPlace = "Ha Noi", Age = 21, IsGraduated = true });
            try{
            n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 0:
                    foreach (var item in mb)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 1:
                    var result1 = (from m in mb
                                   where m.Gender.Equals("Male", StringComparison.InvariantCultureIgnoreCase)
                                   select m).ToList();

                    foreach (var item in result1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 2:
                    var result2 = mb.OrderByDescending(s => s.Age).ThenBy(s => s.DateOfBirth.Month).Distinct().FirstOrDefault().ToString();

                    foreach (var item in result2)
                    {
                        Console.Write(item);
                    }
                    break;
                case 3:
                    var result3 = mb.Select(s => s.FirstName + " " + s.LastName).Aggregate((a, b) => a + ", " + b);
                    foreach (var item in result3)
                    {
                        Console.Write(item);
                    }
                    break;
                case 4:
                    var result4 = (from m in mb
                                   where m.DateOfBirth.Year.Equals(2000)
                                   select m).ToList();
                    foreach (var item in result4)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 5:
                    var result5 = (from m in mb
                                   where ((uint)m.DateOfBirth.Year > 2000)
                                   select m).ToList();
                    foreach (var item in result5)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 6:
                    var result6 = (from m in mb
                                   where ((uint)m.DateOfBirth.Year < 2000)
                                   select m).ToList();
                    foreach (var item in result6)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 7:
                    var result7 = (from m in mb
                                   where m.BirthPlace.Contains("Ha Noi")
                                   select m).Distinct().FirstOrDefault().ToString();
                    foreach (var item in result7)
                    {
                        Console.Write(item);
                    }
                    break;
                default:
                    System.Console.WriteLine("Enter integer number from 0 - 7 pls");
                    return;
            }
            } catch(Exception){
                System.Console.WriteLine("Enter integer number pls");
                return;
            }
        }
    }
}