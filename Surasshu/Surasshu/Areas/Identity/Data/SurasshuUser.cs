using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Surasshu.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SurasshuUser class
public class SurasshuUser : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? WarriorOneId { get; set; } = null;

    public int? WarriorTwoId { get; set; } = null;

    public int? WarriorThreeId { get; set; } = null;

    public int? WarriorFourId { get; set; } = null;

    public int? WarriorFiveId { get; set; } = null;



    public SurasshuUser() { }

    public SurasshuUser(string? firstName, string? lastName, string? username, int? warriorOneId, int? warriorTwoId, int? warriorThreeId, int? warriorFourId, int? warriorFiveId)
    {
        FirstName = firstName;
        LastName = lastName;
        WarriorOneId = warriorOneId;
        WarriorTwoId = warriorTwoId;
        WarriorThreeId = warriorThreeId;
        WarriorFourId = warriorFourId;
        WarriorFiveId = warriorFiveId;
    }
}

