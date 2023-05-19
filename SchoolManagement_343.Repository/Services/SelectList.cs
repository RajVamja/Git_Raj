using SchoolManagement_343.Models.Context;
using System.Collections.Generic;

namespace SchoolManagement_343.Repository.Services
{
    internal class SelectList
    {
        private List<State> selectList;
        private string v1;
        private string v2;

        public SelectList(List<State> selectList, string v1, string v2)
        {
            this.selectList = selectList;
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}