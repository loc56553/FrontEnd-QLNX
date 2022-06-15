using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaXe.Security.Requirement
{
    public class UserAuthorize1: IAuthorizationRequirement
    {
        public UserAuthorize1()
        {
            MucDoTruyCap = 1;
        }
        public int MucDoTruyCap { get; set; }
    }
}
