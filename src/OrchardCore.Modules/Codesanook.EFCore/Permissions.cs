using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace Codesanook.EFCore
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageEFCore = new Permission("ManageEFCore", "Manage EFCore");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageEFCore }.AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageEFCore }
                }
            };
        }
    }
}
