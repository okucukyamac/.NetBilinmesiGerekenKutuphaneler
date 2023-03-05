// See https://aka.ms/new-console-template for more information
using Solid.App.OCPGood;
using static Solid.App.OCPGood2.OCPGood2;

Console.WriteLine("Hello, World!");

SalaryCalculator salaryCalculator = new();

//Bad way
//Console.WriteLine(salaryCalculator.Calculate(1000,SalaryType.Low));
//Console.WriteLine(salaryCalculator.Calculate(1000,SalaryType.Middle));
//Console.WriteLine(salaryCalculator.Calculate(1000,SalaryType.High));

//Good way
//Console.WriteLine(salaryCalculator.Calculate(1000, new LowSalaryCalculate()));
//Console.WriteLine(salaryCalculator.Calculate(1000, new MiddleSalaryCalculate()));
//Console.WriteLine(salaryCalculator.Calculate(1000, new HighSalaryCalculate()));
//Console.WriteLine(salaryCalculator.Calculate(1000, new ManagerSalaryCalculate()));

//Good2 way
Console.WriteLine(salaryCalculator.Calculate(1000, new LowSalaryCalculate().Calculate));
Console.WriteLine(salaryCalculator.Calculate(1000, new MiddleSalaryCalculate().Calculate));
Console.WriteLine(salaryCalculator.Calculate(1000, new HighSalaryCalculate().Calculate));
Console.WriteLine(salaryCalculator.Calculate(1000, new ManagerSalaryCalculate().Calculate));

Console.WriteLine(salaryCalculator.Calculate(1000, a =>
{
    return a * 10;
}));


