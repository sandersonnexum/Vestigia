using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestigia.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Guid userId, string userEmail);
    }
}