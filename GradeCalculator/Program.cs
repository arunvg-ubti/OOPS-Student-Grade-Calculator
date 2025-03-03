using System;

//Person and Student class shows Inheritance
public abstract class Person //base class
{
    public string Name { get; set; } //encapsulation
    public int Age { get; set; } //encapsulation
    public abstract float Calculate_Average(int[] marks); //abstraction
    public abstract Grades Compute_Grades(float average); //abstraction

    //Enum usage for storing grades
    //Defining Enum 'Grades' in base class 'Person' and using it in derived class 'Student' - exhibits Inheritance
    public enum Grades{ 
        O,
        A,
        B,
        C,
        D,
        E,
        Fail
    }
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

    public override Grades Compute_Grades(float average) //method overriding - Polymorphism
    {
        //usage of Enum 'Grades'
        if (average >= 90 && average <= 100)
        {
            return Grades.O;
        }
        else if (average >= 80 && average < 90)
        {
            return Grades.A;
        }
        else if (average >= 70 && average < 80)
        {
            return Grades.B;
        }
        else if (average >= 60 && average < 70)
        {
            return Grades.C;
        }
        else if (average >= 50 && average < 60)
        {
            return Grades.D;
        }
        else if (average >= 40 && average < 50)
        {
            return Grades.E;
        }
        else
        {
            return Grades.Fail;
        }
    }

    public void Student_Details() //get student details, do computation and display the results
    {
        while(true) //while loop
        {
            try //try block
            {
                Console.WriteLine("\nEnter the number of students whose grades you want to calculate: ");
                string student_number = Console.ReadLine()!;

                if(string.IsNullOrEmpty(student_number)) //input validation
                {
                    throw new Exception("\nNumber of students can't be null! Please provide a valid input!");
                    continue;
                }

                int students = int.Parse(student_number); //Converting datatype

                if(students<0) //input validation
                {
                    throw new Exception("\nNumber of students can't be negative! Please provide a valid input!");
                    continue;
                }

                if (students > 0)
                {
                    for (int i = 0; i < students; i++) //for loop
                    {
                        try //try block
                        {
                            Student student= new Student(); //Creating a student instance (object) for each student

                            Console.WriteLine($"\n\nEnter the name of student {i + 1}: ");
                            student.Name = Console.ReadLine()!; //Name of student assigned

                            if(student.Name==null) //input validation
                            {
                                throw new Exception("\nStudent Name can't be null! Kindly provide a valid input!"); //throw
                                continue;
                            }

                            Console.WriteLine($"\n\nEnter the age of student {i + 1}: ");
                            student.Age = int.Parse(Console.ReadLine()!); //Age of student assigned

                            if (student.Age <= 3 || student.Age >100) //input validation
                            {
                                throw new Exception("\nStudent Age should be between 4 and 100! Kindly give a valid input!"); //throw statement
                                continue;
                            }

                            if(student.Age==null) //input validation
                            {
                                throw new Exception("\nStudent Age can't be null! Kindly provide a valid input!"); //throw
                                continue;
                            }

                            Console.WriteLine($"\n\nHow many marks do you want to enter for Student {i + 1}? ");
                            string number = Console.ReadLine()!;

                            if(string.IsNullOrEmpty(number)) //input validation
                            {
                                throw new Exception("\nNumber of marks can't be null! Kindly provide a valid input!"); //throw
                                continue;
                            }

                            int x = int.Parse(number); //Parsing - datatype conversion from string to int

                            if(x<1)
                            {
                                throw new Exception("\nNumber of marks can't be less than 1! Kindly provide a valid input!");
                                continue;
                            }

                            int[] marks = new int[x];

                            for (int j = 0; j < x; j++) //nested for loop
                            {
                                try //try block
                                {
                                    Console.WriteLine($"\n\nFor Student {i + 1}, enter the marks as follows\n");
                                    Console.WriteLine($"\nEnter Mark {j + 1}: ");
                                    marks[j] = int.Parse(Console.ReadLine()!);

                                    if (marks[j] < 0 || marks[j]==null) //input validation
                                    {
                                        throw new Exception("\nMarks can't be negative or null! Kindly provide a proper input!"); //throw statement
                                        continue;
                                    }

                                    if(marks[j]>100) //input validation
                                    {
                                        throw new Exception("\nMaximum Marks is 100! Kindly enter a valid input!"); //throw
                                        continue;
                                    }
                                }
                                catch (Exception e) //catch block
                                {
                                    Console.WriteLine(e.Message);
                                    continue; //continue
                                }
                            }

                            float average = student.Calculate_Average(marks); //Average mark of student assigned via student method
                            Grades grade = student.Compute_Grades(average); //Grade of student assigned via student method

                            Console.WriteLine($"\n\nStudent Name: {student.Name}\nAge: {student.Age}\nAverage Mark: {average:F2}\nGrade: {grade}\n");
                        }
                        catch (Exception e) //catch block
                        {
                            Console.WriteLine(e.Message);
                            continue; //continue
                        }
                    }
                }
            }
            catch (Exception e) //catch block - custom exception
            {
                Console.WriteLine(e.Message);
                continue; //continue
            }
            finally //finally block
            {
                Console.WriteLine("\n\n\nThe program is over! Thank you!");
            }
            break; //break statement - breaks the loop
        }
    }
}
public class Program
{
    public static void Main() //main function
    {
        Student s = new Student(); //object creation
        s.Student_Details(); //Calling method of student class via student class instance/object
    }
}