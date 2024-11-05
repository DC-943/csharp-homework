using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace michael_3038_NETHomework_3.IService
{
    internal interface IRefer
    {
        public void ReferJob(List<(int, string)> stuIdScoreList);
    }
}
