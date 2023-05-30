﻿using System.Text.Json.Serialization;

namespace StudyProgramManagement.Domain.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [JsonIgnore]
    public List<Module> Modules { get; set; }

    public Teacher(string firstName, string lastName, List<Module> modules)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
        Modules = modules;
    }

    public Teacher()
    {
    }
}