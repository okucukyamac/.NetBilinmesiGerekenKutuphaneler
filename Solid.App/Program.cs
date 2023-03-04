// See https://aka.ms/new-console-template for more information
using Solid.App.OCPBad;

Console.WriteLine("Hello, World!");

SalaryCalculator salaryCalculator = new();

Console.WriteLine(salaryCalculator.Calculate(1000,SalaryType.Low));
Console.WriteLine(salaryCalculator.Calculate(1000,SalaryType.Middle));
Console.WriteLine(salaryCalculator.Calculate(1000,SalaryType.High));