using System;

//Person and Student class shows Inheritance
public abstract class Person //base class
{
    public string Name { get; set; } //encapsulation
    public int Age { get; set; } //encapsulation
    public abstract float Calculate_Average(int[] marks); //abstraction
    public abstract string Compute_Grades(float average); //abstraction
}

public class Student : Person //derived class
{
    public override float Calculate_Average(int[] marks) //method overriding - Polymorphism
    {
        int sum = 0;
        for (int i = 0; i < marks.Length; i++)
        {
            sum += marks[i];
        }
        return (float)sum / marks.Length;
    }

    public override string Compute_Grades(float average) //method overriding - Polymorphism
    {
        if (average >= 90 && average <= 100)
        {
            return "The grade is 'O'";
        }
        else if (average >= 80 && average < 90)
        {
            return "The grade is 'A'";
        }
        else if (average >= 70 && average < 80)
        {
            return "The grade is 'B'";
        }
        else if (average >= 60 && average < 70)
        {
            return "The grade is 'C'";
        }
        else if (average >= 50 && average < 60)
        {
            return "The grade is 'D'";
        }
        else if (average >= 40 && average < 50)
        {
            return "The grade is 'E'";
        }
        else
        {
            return "Fail";
        }
    }

    public void Student_Details() //get and post student details
    {
        try
        {
            Console.WriteLine("Enter the number of students whose grades you want to calculate: ");
            string student_number = Console.ReadLine()!;
            int students = int.Parse(student_number); //Converting datatype
            if (students > 0)
            {
                for (int i = 0; i < students; i++)
                {
                    try //try block
                    {
                        Console.WriteLine($"Enter the name of student {i + 1}: ");
                        Name = Console.ReadLine()!;

                        Console.WriteLine($"Enter the age of student {i + 1}: ");
                        Age = int.Parse(Console.ReadLine()!);

                        if (Age < 0)
                        {
                            throw new Exception("Age can't be negative"); //throw statement
                        }

                        Console.WriteLine($"How many marks do you want to enter for Student {i + 1}? ");
                        string number = Console.ReadLine()!;
                        int x = int.Parse(number);

                        if (x <= 0)
                        {
                            throw new Exception("The number of marks to be entered should be greater than zero..."); //throw statement
                        }

                        int[] marks = new int[x];

                        for (int j = 0; j < x; j++)
                        {
                            try //try block
                            {
                                Console.WriteLine($"\nFor Student {i + 1}, enter the marks as follows\n");
                                Console.WriteLine($"Enter Mark {j + 1}: ");
                                marks[j] = int.Parse(Console.ReadLine()!);

                                if (marks[j] < 0)
                                {
                                    throw new Exception("Marks can't be negative"); //throw statement
                                }
                            }
                            catch (Exception e) //catch block
                            {
                                Console.WriteLine(e.Message); 
                            }
                        }

                        float average = Calculate_Average(marks);
                        string grade = Compute_Grades(average);

                        Console.WriteLine($"Name of the Student: {Name}\nAge: {Age}\nAverage Mark: {average:F2}\nGrade: {grade}\n");
                    }
                    catch (Exception e) //catch block
                    {
                        Console.WriteLine(e.Message); 
                    }
                }
            }
            else
            {
                throw new Exception("The number of students should be greater than zero..."); //throw statement
            }
        }
        catch (FormatException) //catch block - system in-built exception
        {
            Console.WriteLine("Invalid Input");
        }
        catch (Exception e) //catch block - custom exception
        {
            Console.WriteLine(e.Message);
        }
        finally //finally block
        {
            Console.WriteLine("Exception Handling is done and the code is successfully executed....");
        }
    }
}

public class Program
{
    public static void Main() //main function
    {
        Student s = new Student(); //object creation
        s.Student_Details(); //method accessing via object
    }
}