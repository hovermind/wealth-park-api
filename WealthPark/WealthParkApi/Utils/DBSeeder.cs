using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WealthParkApi.Domain;
using WealthParkApi.Domain.Entities;

namespace WealthParkApi.Utils
{
    /// <summary>
    /// Database initializer
    /// </summary>
    public class DBSeeder
    {
        /// <summary>
        /// DBSeeder ctor
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(EmployeeDbContext context)
        {
            // context.Database.EnsureCreated() does not use migrations to create the database and therefore the database that is created cannot be later updated using migrations 
            // use context.Database.Migrate() instead
            context.Database.Migrate();

            if (context.Employees.Any())
            {
                return;
            }

            // insert dummy data
            context.AddRange(GetDummyEmployeeList());
            context.SaveChanges();
        }

        /// <summary>
        /// Provides dummy data
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetDummyEmployeeList()
        {
            var employees = new List<Employee> {
                new Employee{ FirstName = "Foo", LastName = "Bar", Boss = "boss 1", Address = "address 1", DateOfBirth =  DateTime.Today.AddYears(-1), Salary = 1_000_000.0 },
                new Employee{ FirstName = "first_name 2", LastName = "last_name 2", Boss = "boss 2", Address = "address 2", DateOfBirth =  DateTime.Today.AddYears(-2), Salary = 2_000_000.0 },
                new Employee{ FirstName = "first_name 3", LastName = "last_name 3", Boss = "boss 3", Address = "address 3", DateOfBirth =  DateTime.Today.AddYears(-3), Salary = 3_000_000.0 },
                new Employee{ FirstName = "first_name 4", LastName = "last_name 4", Boss = "boss 4", Address = "address 4", DateOfBirth =  DateTime.Today.AddYears(-4), Salary = 4_000_000.0 },
                new Employee{ FirstName = "first_name 5", LastName = "last_name 5", Boss = "boss 5", Address = "address 5", DateOfBirth =  DateTime.Today.AddYears(-5), Salary = 5_000_000.0 },
                new Employee{ FirstName = "first_name 6", LastName = "last_name 6", Boss = "boss 6", Address = "address 6", DateOfBirth =  DateTime.Today.AddYears(-6), Salary = 6_000_000.0 },
                new Employee{ FirstName = "first_name 7", LastName = "last_name 7", Boss = "boss 7", Address = "address 7", DateOfBirth =  DateTime.Today.AddYears(-7), Salary = 7_000_000.0 },
                new Employee{ FirstName = "first_name 8", LastName = "last_name 8", Boss = "boss 8", Address = "address 8", DateOfBirth =  DateTime.Today.AddYears(-8), Salary = 8_000_000.0 },
                new Employee{ FirstName = "first_name 9", LastName = "last_name 9", Boss = "boss 9", Address = "address 9", DateOfBirth =  DateTime.Today.AddYears(-9), Salary = 9_000_000.0 },
                new Employee{ FirstName = "first_name 10", LastName = "last_name 10", Boss = "boss 10", Address = "address 10", DateOfBirth =  DateTime.Today.AddYears(-10), Salary = 10_000_000.0 },
                new Employee{ FirstName = "first_name 11", LastName = "last_name 11", Boss = "boss 11", Address = "address 11", DateOfBirth =  DateTime.Today.AddYears(-11), Salary = 11_000_000.0 },
                new Employee{ FirstName = "first_name 12", LastName = "last_name 12", Boss = "boss 12", Address = "address 12", DateOfBirth =  DateTime.Today.AddYears(-12), Salary = 12_000_000.0 },
                new Employee{ FirstName = "first_name 13", LastName = "last_name 13", Boss = "boss 13", Address = "address 13", DateOfBirth =  DateTime.Today.AddYears(-13), Salary = 13_000_000.0 },
                new Employee{ FirstName = "first_name 14", LastName = "last_name 14", Boss = "boss 14", Address = "address 14", DateOfBirth =  DateTime.Today.AddYears(-14), Salary = 14_000_000.0 },
                new Employee{ FirstName = "first_name 15", LastName = "last_name 15", Boss = "boss 15", Address = "address 15", DateOfBirth =  DateTime.Today.AddYears(-15), Salary = 15_000_000.0 },
                new Employee{ FirstName = "first_name 16", LastName = "last_name 16", Boss = "boss 16", Address = "address 16", DateOfBirth =  DateTime.Today.AddYears(-16), Salary = 16_000_000.0 },
                new Employee{ FirstName = "first_name 17", LastName = "last_name 17", Boss = "boss 17", Address = "address 17", DateOfBirth =  DateTime.Today.AddYears(-17), Salary = 17_000_000.0 },
                new Employee{ FirstName = "first_name 18", LastName = "last_name 18", Boss = "boss 18", Address = "address 18", DateOfBirth =  DateTime.Today.AddYears(-18), Salary = 18_000_000.0 },
                new Employee{ FirstName = "first_name 19", LastName = "last_name 19", Boss = "boss 19", Address = "address 19", DateOfBirth =  DateTime.Today.AddYears(-19), Salary = 19_000_000.0 },
                new Employee{ FirstName = "first_name 20", LastName = "last_name 20", Boss = "boss 20", Address = "address 20", DateOfBirth =  DateTime.Today.AddYears(-20), Salary = 20_000_000.0 },
                new Employee{ FirstName = "first_name 21", LastName = "last_name 21", Boss = "boss 21", Address = "address 21", DateOfBirth =  DateTime.Today.AddYears(-21), Salary = 21_000_000.0 },
                new Employee{ FirstName = "first_name 22", LastName = "last_name 22", Boss = "boss 22", Address = "address 22", DateOfBirth =  DateTime.Today.AddYears(-22), Salary = 22_000_000.0 },
                new Employee{ FirstName = "first_name 23", LastName = "last_name 23", Boss = "boss 23", Address = "address 23", DateOfBirth =  DateTime.Today.AddYears(-23), Salary = 23_000_000.0 },
                new Employee{ FirstName = "first_name 24", LastName = "last_name 24", Boss = "boss 24", Address = "address 24", DateOfBirth =  DateTime.Today.AddYears(-24), Salary = 24_000_000.0 },
                new Employee{ FirstName = "first_name 25", LastName = "last_name 25", Boss = "boss 25", Address = "address 25", DateOfBirth =  DateTime.Today.AddYears(-25), Salary = 25_000_000.0 },
                new Employee{ FirstName = "first_name 26", LastName = "last_name 26", Boss = "boss 26", Address = "address 26", DateOfBirth =  DateTime.Today.AddYears(-26), Salary = 26_000_000.0 },
                new Employee{ FirstName = "first_name 27", LastName = "last_name 27", Boss = "boss 27", Address = "address 27", DateOfBirth =  DateTime.Today.AddYears(-27), Salary = 27_000_000.0 },
                new Employee{ FirstName = "first_name 28", LastName = "last_name 28", Boss = "boss 28", Address = "address 28", DateOfBirth =  DateTime.Today.AddYears(-28), Salary = 28_000_000.0 },
                new Employee{ FirstName = "first_name 29", LastName = "last_name 29", Boss = "boss 29", Address = "address 29", DateOfBirth =  DateTime.Today.AddYears(-29), Salary = 29_000_000.0 },
                new Employee{ FirstName = "first_name 30", LastName = "last_name 30", Boss = "boss 30", Address = "address 30", DateOfBirth =  DateTime.Today.AddYears(-30), Salary = 30_000_000.0 },
                new Employee{ FirstName = "first_name 31", LastName = "last_name 31", Boss = "boss 31", Address = "address 31", DateOfBirth =  DateTime.Today.AddYears(-31), Salary = 31_000_000.0 },
                new Employee{ FirstName = "first_name 32", LastName = "last_name 32", Boss = "boss 32", Address = "address 32", DateOfBirth =  DateTime.Today.AddYears(-32), Salary = 32_000_000.0 },
                new Employee{ FirstName = "first_name 33", LastName = "last_name 33", Boss = "boss 33", Address = "address 33", DateOfBirth =  DateTime.Today.AddYears(-33), Salary = 33_000_000.0 },
                new Employee{ FirstName = "first_name 34", LastName = "last_name 34", Boss = "boss 34", Address = "address 34", DateOfBirth =  DateTime.Today.AddYears(-34), Salary = 34_000_000.0 },
                new Employee{ FirstName = "first_name 35", LastName = "last_name 35", Boss = "boss 35", Address = "address 35", DateOfBirth =  DateTime.Today.AddYears(-35), Salary = 35_000_000.0 },
                new Employee{ FirstName = "first_name 36", LastName = "last_name 36", Boss = "boss 36", Address = "address 36", DateOfBirth =  DateTime.Today.AddYears(-36), Salary = 36_000_000.0 },
                new Employee{ FirstName = "first_name 37", LastName = "last_name 37", Boss = "boss 37", Address = "address 37", DateOfBirth =  DateTime.Today.AddYears(-37), Salary = 37_000_000.0 },
                new Employee{ FirstName = "first_name 38", LastName = "last_name 38", Boss = "boss 38", Address = "address 38", DateOfBirth =  DateTime.Today.AddYears(-38), Salary = 38_000_000.0 },
                new Employee{ FirstName = "first_name 39", LastName = "last_name 39", Boss = "boss 39", Address = "address 39", DateOfBirth =  DateTime.Today.AddYears(-39), Salary = 39_000_000.0 },
                new Employee{ FirstName = "first_name 40", LastName = "last_name 40", Boss = "boss 40", Address = "address 40", DateOfBirth =  DateTime.Today.AddYears(-40), Salary = 40_000_000.0 },
                new Employee{ FirstName = "first_name 41", LastName = "last_name 41", Boss = "boss 41", Address = "address 41", DateOfBirth =  DateTime.Today.AddYears(-41), Salary = 41_000_000.0 },
                new Employee{ FirstName = "first_name 42", LastName = "last_name 42", Boss = "boss 42", Address = "address 42", DateOfBirth =  DateTime.Today.AddYears(-42), Salary = 42_000_000.0 },
                new Employee{ FirstName = "first_name 43", LastName = "last_name 43", Boss = "boss 43", Address = "address 43", DateOfBirth =  DateTime.Today.AddYears(-43), Salary = 43_000_000.0 },
                new Employee{ FirstName = "first_name 44", LastName = "last_name 44", Boss = "boss 44", Address = "address 44", DateOfBirth =  DateTime.Today.AddYears(-44), Salary = 44_000_000.0 },
                new Employee{ FirstName = "first_name 45", LastName = "last_name 45", Boss = "boss 45", Address = "address 45", DateOfBirth =  DateTime.Today.AddYears(-45), Salary = 45_000_000.0 },
                new Employee{ FirstName = "first_name 46", LastName = "last_name 46", Boss = "boss 46", Address = "address 46", DateOfBirth =  DateTime.Today.AddYears(-46), Salary = 46_000_000.0 },
                new Employee{ FirstName = "first_name 47", LastName = "last_name 47", Boss = "boss 47", Address = "address 47", DateOfBirth =  DateTime.Today.AddYears(-47), Salary = 47_000_000.0 },
                new Employee{ FirstName = "first_name 48", LastName = "last_name 48", Boss = "boss 48", Address = "address 48", DateOfBirth =  DateTime.Today.AddYears(-48), Salary = 48_000_000.0 },
                new Employee{ FirstName = "first_name 49", LastName = "last_name 49", Boss = "boss 49", Address = "address 49", DateOfBirth =  DateTime.Today.AddYears(-49), Salary = 49_000_000.0 },
                new Employee{ FirstName = "first_name 50", LastName = "last_name 50", Boss = "boss 50", Address = "address 50", DateOfBirth =  DateTime.Today.AddYears(-50), Salary = 50_000_000.0 },
                new Employee{ FirstName = "first_name 51", LastName = "last_name 51", Boss = "boss 51", Address = "address 51", DateOfBirth =  DateTime.Today.AddYears(-51), Salary = 51_000_000.0 },
                new Employee{ FirstName = "first_name 52", LastName = "last_name 52", Boss = "boss 52", Address = "address 52", DateOfBirth =  DateTime.Today.AddYears(-52), Salary = 52_000_000.0 },
                new Employee{ FirstName = "first_name 53", LastName = "last_name 53", Boss = "boss 53", Address = "address 53", DateOfBirth =  DateTime.Today.AddYears(-53), Salary = 53_000_000.0 },
                new Employee{ FirstName = "first_name 54", LastName = "last_name 54", Boss = "boss 54", Address = "address 54", DateOfBirth =  DateTime.Today.AddYears(-54), Salary = 54_000_000.0 },
                new Employee{ FirstName = "first_name 55", LastName = "last_name 55", Boss = "boss 55", Address = "address 55", DateOfBirth =  DateTime.Today.AddYears(-55), Salary = 55_000_000.0 },
                new Employee{ FirstName = "first_name 56", LastName = "last_name 56", Boss = "boss 56", Address = "address 56", DateOfBirth =  DateTime.Today.AddYears(-56), Salary = 56_000_000.0 },
                new Employee{ FirstName = "first_name 57", LastName = "last_name 57", Boss = "boss 57", Address = "address 57", DateOfBirth =  DateTime.Today.AddYears(-57), Salary = 57_000_000.0 },
                new Employee{ FirstName = "first_name 58", LastName = "last_name 58", Boss = "boss 58", Address = "address 58", DateOfBirth =  DateTime.Today.AddYears(-58), Salary = 58_000_000.0 },
                new Employee{ FirstName = "first_name 59", LastName = "last_name 59", Boss = "boss 59", Address = "address 59", DateOfBirth =  DateTime.Today.AddYears(-59), Salary = 59_000_000.0 },
                new Employee{ FirstName = "first_name 60", LastName = "last_name 60", Boss = "boss 60", Address = "address 60", DateOfBirth =  DateTime.Today.AddYears(-60), Salary = 60_000_000.0 },
                new Employee{ FirstName = "first_name 61", LastName = "last_name 61", Boss = "boss 61", Address = "address 61", DateOfBirth =  DateTime.Today.AddYears(-61), Salary = 61_000_000.0 },
                new Employee{ FirstName = "first_name 62", LastName = "last_name 62", Boss = "boss 62", Address = "address 62", DateOfBirth =  DateTime.Today.AddYears(-62), Salary = 62_000_000.0 },
                new Employee{ FirstName = "first_name 63", LastName = "last_name 63", Boss = "boss 63", Address = "address 63", DateOfBirth =  DateTime.Today.AddYears(-63), Salary = 63_000_000.0 },
                new Employee{ FirstName = "first_name 64", LastName = "last_name 64", Boss = "boss 64", Address = "address 64", DateOfBirth =  DateTime.Today.AddYears(-64), Salary = 64_000_000.0 },
                new Employee{ FirstName = "first_name 65", LastName = "last_name 65", Boss = "boss 65", Address = "address 65", DateOfBirth =  DateTime.Today.AddYears(-65), Salary = 65_000_000.0 },
                new Employee{ FirstName = "first_name 66", LastName = "last_name 66", Boss = "boss 66", Address = "address 66", DateOfBirth =  DateTime.Today.AddYears(-66), Salary = 66_000_000.0 },
                new Employee{ FirstName = "first_name 67", LastName = "last_name 67", Boss = "boss 67", Address = "address 67", DateOfBirth =  DateTime.Today.AddYears(-67), Salary = 67_000_000.0 },
                new Employee{ FirstName = "first_name 68", LastName = "last_name 68", Boss = "boss 68", Address = "address 68", DateOfBirth =  DateTime.Today.AddYears(-68), Salary = 68_000_000.0 },
                new Employee{ FirstName = "first_name 69", LastName = "last_name 69", Boss = "boss 69", Address = "address 69", DateOfBirth =  DateTime.Today.AddYears(-69), Salary = 69_000_000.0 },
                new Employee{ FirstName = "first_name 70", LastName = "last_name 70", Boss = "boss 70", Address = "address 70", DateOfBirth =  DateTime.Today.AddYears(-70), Salary = 70_000_000.0 },
                new Employee{ FirstName = "first_name 71", LastName = "last_name 71", Boss = "boss 71", Address = "address 71", DateOfBirth =  DateTime.Today.AddYears(-71), Salary = 71_000_000.0 },
                new Employee{ FirstName = "first_name 72", LastName = "last_name 72", Boss = "boss 72", Address = "address 72", DateOfBirth =  DateTime.Today.AddYears(-72), Salary = 72_000_000.0 },
                new Employee{ FirstName = "first_name 73", LastName = "last_name 73", Boss = "boss 73", Address = "address 73", DateOfBirth =  DateTime.Today.AddYears(-73), Salary = 73_000_000.0 },
                new Employee{ FirstName = "first_name 74", LastName = "last_name 74", Boss = "boss 74", Address = "address 74", DateOfBirth =  DateTime.Today.AddYears(-74), Salary = 74_000_000.0 },
                new Employee{ FirstName = "first_name 75", LastName = "last_name 75", Boss = "boss 75", Address = "address 75", DateOfBirth =  DateTime.Today.AddYears(-75), Salary = 75_000_000.0 },
                new Employee{ FirstName = "first_name 76", LastName = "last_name 76", Boss = "boss 76", Address = "address 76", DateOfBirth =  DateTime.Today.AddYears(-76), Salary = 76_000_000.0 },
                new Employee{ FirstName = "first_name 77", LastName = "last_name 77", Boss = "boss 77", Address = "address 77", DateOfBirth =  DateTime.Today.AddYears(-77), Salary = 77_000_000.0 },
                new Employee{ FirstName = "first_name 78", LastName = "last_name 78", Boss = "boss 78", Address = "address 78", DateOfBirth =  DateTime.Today.AddYears(-78), Salary = 78_000_000.0 },
                new Employee{ FirstName = "first_name 79", LastName = "last_name 79", Boss = "boss 79", Address = "address 79", DateOfBirth =  DateTime.Today.AddYears(-79), Salary = 79_000_000.0 },
                new Employee{ FirstName = "first_name 80", LastName = "last_name 80", Boss = "boss 80", Address = "address 80", DateOfBirth =  DateTime.Today.AddYears(-80), Salary = 80_000_000.0 },
                new Employee{ FirstName = "first_name 81", LastName = "last_name 81", Boss = "boss 81", Address = "address 81", DateOfBirth =  DateTime.Today.AddYears(-81), Salary = 81_000_000.0 },
                new Employee{ FirstName = "first_name 82", LastName = "last_name 82", Boss = "boss 82", Address = "address 82", DateOfBirth =  DateTime.Today.AddYears(-82), Salary = 82_000_000.0 },
                new Employee{ FirstName = "first_name 83", LastName = "last_name 83", Boss = "boss 83", Address = "address 83", DateOfBirth =  DateTime.Today.AddYears(-83), Salary = 83_000_000.0 },
                new Employee{ FirstName = "first_name 84", LastName = "last_name 84", Boss = "boss 84", Address = "address 84", DateOfBirth =  DateTime.Today.AddYears(-84), Salary = 84_000_000.0 },
                new Employee{ FirstName = "first_name 85", LastName = "last_name 85", Boss = "boss 85", Address = "address 85", DateOfBirth =  DateTime.Today.AddYears(-85), Salary = 85_000_000.0 },
                new Employee{ FirstName = "first_name 86", LastName = "last_name 86", Boss = "boss 86", Address = "address 86", DateOfBirth =  DateTime.Today.AddYears(-86), Salary = 86_000_000.0 },
                new Employee{ FirstName = "first_name 87", LastName = "last_name 87", Boss = "boss 87", Address = "address 87", DateOfBirth =  DateTime.Today.AddYears(-87), Salary = 87_000_000.0 },
                new Employee{ FirstName = "first_name 88", LastName = "last_name 88", Boss = "boss 88", Address = "address 88", DateOfBirth =  DateTime.Today.AddYears(-88), Salary = 88_000_000.0 },
                new Employee{ FirstName = "first_name 89", LastName = "last_name 89", Boss = "boss 89", Address = "address 89", DateOfBirth =  DateTime.Today.AddYears(-89), Salary = 89_000_000.0 },
                new Employee{ FirstName = "first_name 90", LastName = "last_name 90", Boss = "boss 90", Address = "address 90", DateOfBirth =  DateTime.Today.AddYears(-90), Salary = 90_000_000.0 },
                new Employee{ FirstName = "first_name 91", LastName = "last_name 91", Boss = "boss 91", Address = "address 91", DateOfBirth =  DateTime.Today.AddYears(-91), Salary = 91_000_000.0 },
                new Employee{ FirstName = "first_name 92", LastName = "last_name 92", Boss = "boss 92", Address = "address 92", DateOfBirth =  DateTime.Today.AddYears(-92), Salary = 92_000_000.0 },
                new Employee{ FirstName = "first_name 93", LastName = "last_name 93", Boss = "boss 93", Address = "address 93", DateOfBirth =  DateTime.Today.AddYears(-93), Salary = 93_000_000.0 },
                new Employee{ FirstName = "first_name 94", LastName = "last_name 94", Boss = "boss 94", Address = "address 94", DateOfBirth =  DateTime.Today.AddYears(-94), Salary = 94_000_000.0 },
                new Employee{ FirstName = "first_name 95", LastName = "last_name 95", Boss = "boss 95", Address = "address 95", DateOfBirth =  DateTime.Today.AddYears(-95), Salary = 95_000_000.0 },
                new Employee{ FirstName = "first_name 96", LastName = "last_name 96", Boss = "boss 96", Address = "address 96", DateOfBirth =  DateTime.Today.AddYears(-96), Salary = 96_000_000.0 },
                new Employee{ FirstName = "first_name 97", LastName = "last_name 97", Boss = "boss 97", Address = "address 97", DateOfBirth =  DateTime.Today.AddYears(-97), Salary = 97_000_000.0 },
                new Employee{ FirstName = "first_name 98", LastName = "last_name 98", Boss = "boss 98", Address = "address 98", DateOfBirth =  DateTime.Today.AddYears(-98), Salary = 98_000_000.0 },
                new Employee{ FirstName = "first_name 99", LastName = "last_name 99", Boss = "boss 99", Address = "address 99", DateOfBirth =  DateTime.Today.AddYears(-99), Salary = 99_000_000.0 },
                new Employee{ FirstName = "first_name 100", LastName = "last_name 100", Boss = "boss 100", Address = "address 100", DateOfBirth =  DateTime.Today.AddYears(-100), Salary = 100_000_000.0 },
                new Employee{ FirstName = "first_name 101", LastName = "last_name 101", Boss = "boss 101", Address = "address 101", DateOfBirth =  DateTime.Today.AddYears(-101), Salary = 101_000_000.0 },
                new Employee{ FirstName = "first_name 102", LastName = "last_name 102", Boss = "boss 102", Address = "address 102", DateOfBirth =  DateTime.Today.AddYears(-102), Salary = 102_000_000.0 },
                new Employee{ FirstName = "first_name 103", LastName = "last_name 103", Boss = "boss 103", Address = "address 103", DateOfBirth =  DateTime.Today.AddYears(-103), Salary = 103_000_000.0 },
                new Employee{ FirstName = "first_name 104", LastName = "last_name 104", Boss = "boss 104", Address = "address 104", DateOfBirth =  DateTime.Today.AddYears(-104), Salary = 104_000_000.0 },
                new Employee{ FirstName = "first_name 105", LastName = "last_name 105", Boss = "boss 105", Address = "address 105", DateOfBirth =  DateTime.Today.AddYears(-105), Salary = 105_000_000.0 },
                new Employee{ FirstName = "first_name 106", LastName = "last_name 106", Boss = "boss 106", Address = "address 106", DateOfBirth =  DateTime.Today.AddYears(-106), Salary = 106_000_000.0 },
                new Employee{ FirstName = "first_name 107", LastName = "last_name 107", Boss = "boss 107", Address = "address 107", DateOfBirth =  DateTime.Today.AddYears(-107), Salary = 107_000_000.0 },
                new Employee{ FirstName = "first_name 108", LastName = "last_name 108", Boss = "boss 108", Address = "address 108", DateOfBirth =  DateTime.Today.AddYears(-108), Salary = 108_000_000.0 },
                new Employee{ FirstName = "first_name 109", LastName = "last_name 109", Boss = "boss 109", Address = "address 109", DateOfBirth =  DateTime.Today.AddYears(-109), Salary = 109_000_000.0 },
                new Employee{ FirstName = "first_name 110", LastName = "last_name 110", Boss = "boss 110", Address = "address 110", DateOfBirth =  DateTime.Today.AddYears(-110), Salary = 110_000_000.0 }
            };

            return employees;
        }
    }
}
