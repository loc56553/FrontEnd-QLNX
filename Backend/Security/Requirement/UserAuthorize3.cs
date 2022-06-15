using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Security.Requirement
{
    public class UserAuthorize3: IAuthorizationRequirement
    {
        public UserAuthorize3()
        {
            MucDoTruyCap = 3;
        }
        public int MucDoTruyCap { get; set; }
    }
}
