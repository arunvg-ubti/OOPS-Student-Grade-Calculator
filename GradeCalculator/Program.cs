// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/*
 - Develop a console application that calculates the average grade of a Multiple students.
 - Use arrays to store grades and loops to iterate through them.
 - Implement methods to calculate the average and determine the grade (A, B, C, etc.).
*/

using System;
public abstract class Person
{
    public string Name {get;set;}
    public int Age {get;set;}
    public abstract float Calculate_Average(int[] marks);
    public abstract string Compute_Grades(float average);
}

public class Student : Person
{   
    public override float Calculate_Average(int[] marks)
    {
        int sum=0;
        for(int i=0;i<marks.Length;i++)
        {
            sum+=marks[i];
        }
        return (float)sum/marks.Length;
    }
    public override string Compute_Grades(float average)
    {
        if(average>=90 && average<=100)
        {
            return "The grade is 'O'";
        }
        else if(average>=80 && average<90)
        {
            return "The grade is 'A'";
        }
        else if(average>=70 && average<80)
        {
            return "The grade is 'B'";
        }
        else if(average>=60 && average<70)
        {
            return "The grade is 'C'";
        }
        else if(average>=50 && average<60)
        {
            return "The grade is 'D'";
        }
        else if(average>=40 && average<50)
        {
            return "The grade is 'E'";
        }
        else
        {
            return "Fail";
        }
    }
    public void Student_Details()
    {
        Console.WriteLine("Enter the number of students whose grades you want to calculate: ");
        string student_number=Console.ReadLine()!;
        int students=int.Parse(student_number);
        for(int i=0;i<students;i++)
        {
            Console.WriteLine($"Enter the name of student {i+1}: ");
            Name=Console.ReadLine()!;

            Console.WriteLine($"Enter the age of student {i+1}: ");
            Age=int.Parse(Console.ReadLine()!);

            Console.WriteLine($"How many marks do you want to enter for Student {i+1}? ");
            string number=Console.ReadLine()!;
            int x=int.Parse(number);

            int[] marks=new int[x];

            for(int j=0;j<x;j++)
            {
                Console.WriteLine($"\nFor Student {i+1}, enter the marks as follows\n");
                Console.WriteLine($"Enter Mark {j+1}: ");
                marks[j]=int.Parse(Console.ReadLine()!);
            }
            float average=Calculate_Average(marks);
            string grade=Compute_Grades(average);

            Console.WriteLine($"Name of the Student: {Name}\nAge: {Age}\nAverage Mark: {average:F2}\nGrade: {grade}\n");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Student s=new Student();
        s.Student_Details();
    }
}