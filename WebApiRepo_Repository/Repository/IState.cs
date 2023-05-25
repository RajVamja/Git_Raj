using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Models.Context;

namespace WebApiRepo_Repository.Repository
{
    public interface IState
    {
        IEnumerable<State> GetStateList();
    }
}
