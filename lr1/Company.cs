using System;

public class Company
{
    public string name { get; set; } = "";
    public int employees { get; set; } = 0;

    public static string GetCompanyWithMaxEmployees(params Company[] companies)
    {
        if (companies == null || companies.Length == 0)
            throw new ArgumentException("At least one Company object must be passed");

        int maxEmployees = companies[0].employees;
        string companyName = companies[0].name;

        for (int i = 1; i < companies.Length; i++)
        {
            if (companies[i].employees > maxEmployees)
            {
                maxEmployees = companies[i].employees;
                companyName = companies[i].name;
            }
        }

        return companyName;
    }
}
