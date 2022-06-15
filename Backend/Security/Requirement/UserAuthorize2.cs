using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Security.Requirement
{
    public class UserAuthorize2: IAuthorizationRequirement
    {
        public UserAuthorize2()
        {
            MucDoTruyCap = 2;
        }
        public int MucDoTruyCap { get; set; }
    }
}
