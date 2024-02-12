using System;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class Person
{
    public string name { get; set; } = "";
    public int age { get; set; } = 0;
    public string typeOfEmployment { get; set; } = "";
}