# Time Complexity Calculation for OOPS Students' Grades Calculator Program
## Below is the code

```csharp
using System; //O(1)

//Person and Student class shows Inheritance
public abstract class Person //base class //O(1)
{
    public string Name { get; set; } //encapsulation //O(1)
    public int Age { get; set; } //encapsulation //O(1)
    public abstract float Calculate_Average(int[] marks); //abstraction //O(1)
    public abstract string Compute_Grades(float average); //abstraction //O(1)
}

public class Student : Person //derived class //O(n)
{
    public override float Calculate_Average(int[] marks) //method overriding - Polymorphism //O(n)
    {
        int sum = 0; //O(1)
        for (int i = 0; i < marks.Length; i++) //O(n)
        {
            sum += marks[i]; //O(1)
        }
        return (float)sum / marks.Length; //O(1)
    }

    public override string Compute_Grades(float average) //method overriding - Polymorphism //O(1)
    {
        if (average >= 90 && average <= 100) //O(1)
        {
            return "The grade is 'O'"; //O(1)
        }
        else if (average >= 80 && average < 90) //O(1)
        {
            return "The grade is 'A'"; //O(1)
        }
        else if (average >= 70 && average < 80) //O(1)
        {
            return "The grade is 'B'"; //O(1)
        }
        else if (average >= 60 && average < 70) //O(1)
        {
            return "The grade is 'C'"; //O(1)
        }
        else if (average >= 50 && average < 60) //O(1)
        {
            return "The grade is 'D'"; //O(1)
        }
        else if (average >= 40 && average < 50) //O(1)
        {
            return "The grade is 'E'"; //O(1)
        }
        else
        {
            return "Fail"; //O(1)
        }
    }

    public void Student_Details() //get and post student details //O(n)
    {
        try //O(n)
        {
            Console.WriteLine("Enter the number of students whose grades you want to calculate: "); //O(1)
            string student_number = Console.ReadLine()!; //O(n)
            int students = int.Parse(student_number); //Converting datatype //O(1)
            if (students > 0) //O(n)
            {
                for (int i = 0; i < students; i++) //O(n)
                {
                    try //try block //O(n)
                    {
                        Console.WriteLine($"Enter the name of student {i + 1}: "); //O(1)
                        Name = Console.ReadLine()!; //O(n)

                        Console.WriteLine($"Enter the age of student {i + 1}: "); //O(1)
                        Age = int.Parse(Console.ReadLine()!); //O(n)

                        if (Age < 0) //O(1)
                        {
                            throw new Exception("Age can't be negative"); //throw statement //O(1)
                        }

                        Console.WriteLine($"How many marks do you want to enter for Student {i + 1}? "); //O(1)
                        string number = Console.ReadLine()!; //O(n)
                        int x = int.Parse(number); //O(1)

                        if (x <= 0) //O(1)
                        {
                            throw new Exception("The number of marks to be entered should be greater than zero..."); //throw statement //O(1)
                        }

                        int[] marks = new int[x]; //O(1)

                        for (int j = 0; j < x; j++) //O(n)
                        {
                            try //try block //O(n)
                            {
                                Console.WriteLine($"\nFor Student {i + 1}, enter the marks as follows\n"); //O(1)
                                Console.WriteLine($"Enter Mark {j + 1}: "); //O(1)
                                marks[j] = int.Parse(Console.ReadLine()!); //O(n)

                                if (marks[j] < 0) //O(1)
                                {
                                    throw new Exception("Marks can't be negative"); //throw statement //O(1)
                                }
                            }
                            catch (Exception e) //catch block //O(1)
                            {
                                Console.WriteLine(e.Message); //O(1)
                            }
                        }

                        float average = Calculate_Average(marks); //O(1)
                        string grade = Compute_Grades(average); //O(1)

                        Console.WriteLine($"Name of the Student: {Name}\nAge: {Age}\nAverage Mark: {average:F2}\nGrade: {grade}\n"); //O(1)
                    }
                    catch (Exception e) //catch block //O(1)
                    {
                        Console.WriteLine(e.Message); //O(1)
                    }
                }
            }
            else //O(1)
            {
                throw new Exception("The number of students should be greater than zero..."); //throw statement //O(1)
            }
        }
        catch (FormatException) //catch block - system in-built exception //O(1)
        {
            Console.WriteLine("Invalid Input"); //O(1)
        }
        catch (Exception e) //catch block - custom exception //O(1)
        {
            Console.WriteLine(e.Message); //O(1)
        }
        finally //finally block //O(1)
        {
            Console.WriteLine("Exception Handling is done and the code is successfully executed...."); //O(1)
        }
    }
}

public class Program //O(1)
{
    public static void Main() //main function //O(1)
    {
        Student s = new Student(); //object creation //O(1)
        s.Student_Details(); //method accessing via object //O(1)
    }
}
```
## Total Time Complexity = O(1) + O(1) + O(n) + O(1) = O(n)