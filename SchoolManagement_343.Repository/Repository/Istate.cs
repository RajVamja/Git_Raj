using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement_343.Models.Context;


namespace SchoolManagement_343.Repository.Repository
{
    public interface Istate
    {
        //IEnumerable<Country> GetCountryList();
        IEnumerable<State> GetStateList();
        void AddState(State addstat);
        IEnumerable<SP_stateList_Result2> StateList();
        //IEnumerable<State> GetStateList1(int cId);

        State editState(int? sId);
        int editState(State editS);

        int DeleteState(int? sId);
    }
}
