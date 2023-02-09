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

    public bool IsPlatinumMember { get; set; } = false;

    public bool IsBotAccount { get; set; } = false;

    public int? WarriorSixId { get; set; } = null;

    public int? WarriorSevenId { get; set; } = null;

    public int? WarriorEightId { get; set; } = null;

    public int? WarriorNineId { get; set; } = null;

    public int? WarriorTenId { get; set; } = null;

    public int? WarriorElevenId { get; set; } = null;

    public int? WarriorTwelveId { get; set; } = null;

    public int? WarriorThirteenId { get; set; } = null;

    public int? WarriorFourteenId { get; set; } = null;

    public int? WarriorFifteenId { get; set; } = null;

    public int? WarriorSixteenId { get; set; } = null;

    public int? WarriorSeventeenId { get; set; } = null;

    public int? WarriorEighteenId { get; set; } = null;

    public int? WarriorNineteenId { get; set; } = null;

    public int? WarriorTwentyId { get; set; } = null;

    public int? WarriorTwentyOneId { get; set; } = null;



    public SurasshuUser() { }

    public SurasshuUser(string? firstName, string? lastName, string? username, int? warriorOneId, int? warriorTwoId, int? warriorThreeId, int? warriorFourId, int? warriorFiveId, bool isPlatinumMember)
    {
        FirstName = firstName;
        LastName = lastName;
        WarriorOneId = warriorOneId;
        WarriorTwoId = warriorTwoId;
        WarriorThreeId = warriorThreeId;
        WarriorFourId = warriorFourId;
        WarriorFiveId = warriorFiveId;
        IsPlatinumMember = isPlatinumMember;
    }
}

