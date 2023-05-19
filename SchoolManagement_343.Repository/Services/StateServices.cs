using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolManagement_343.Repository.Services
{
    public class StateServices : Istate
    {
        RajVamja_schoolmanagement_343Entities cs = new RajVamja_schoolmanagement_343Entities();
        public IEnumerable<State> GetStateList()
        {
            try
            {
                List<State> states = cs.States.ToList();
                return states;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddState(State state)
        {
            try
            {
                var existingState = cs.States.FirstOrDefault(c => c.sName == state.sName);
                if (existingState == null)
                {
                    cs.States.Add(state);
                    cs.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<SP_stateList_Result2> StateList()
        {
            try
            {
                var statedata = cs.SP_stateList().ToList();
                return statedata;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public State editState(int? sId)
        {
            try
            {
                State s;
                s = cs.States.Find(sId);
                return s;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int editState(State state)
        {
            try
            {
                cs.Entry(state).State = System.Data.Entity.EntityState.Modified;
                cs.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteState(int? sId)
        {
            try
            {
                var del = cs.sp_DeleteState(sId);
                cs.SaveChanges();
                return del;
            }
            catch (Exception ex)
            {

                throw ex;
            }          
        }
    }
}