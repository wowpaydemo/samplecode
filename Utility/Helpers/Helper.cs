﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Helpers
{
    public static class Helper
    {

        public static string GenerateMerchantTxnId()
        {
            return $"DEMO_{DateTime.Now:ddMMyyHHmmssf}";
        }

    }
}
