using Microsoft.AspNetCore.Identity;
using OfferMakerForCggCQRS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMakerForCggCQRS.Application.Common.Interfaces
{
    public interface IRoleManager
    {
        Task<IdentityResult> CreateRoleAsync(string name, string id);
    }
}
