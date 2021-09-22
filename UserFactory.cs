using System.Collections.Generic;
using System.Linq;

namespace DetailResearchOfLinq
{
    public static class UserFactory
    {
        public static User[] CreateUserArray(int count) => Enumerable.Range(0, count)
            .Select(i => new User((ulong) i, $"User_{i}", i % 80))
            .ToArray();
        
        public static List<User> CreateUserList(int count) => Enumerable.Range(0, count)
            .Select(i => new User((ulong)i, $"User_{i}", i % 80))
            .ToList();

        public static Dictionary<ulong, User> CreateUserDictionary(int count)
        {
            var ret = new Dictionary<ulong, User>(count);
            for (var i = 0; i < count; i++)
            {
                ret[(ulong)i] = new User((ulong) i, $"User_{i}", i % 80); 
            }

            return ret;
        }
    }
}
