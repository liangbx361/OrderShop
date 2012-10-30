using System;
using System.Collections.Generic;
using Cudo.Entities;
using Cudo.Services;

namespace Cudo.Business
{
    public class JoinPromotionBLL
    {
        public int GetUserIdByReguid(int reguid)
        {
            return JoinPromotionDAL.GetUserIdByReguid(reguid);
        }
    }
}
