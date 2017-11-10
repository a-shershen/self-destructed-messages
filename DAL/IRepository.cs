using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Interface for DAL Library
    public interface IRepositiry<T>
    {
        //returns Maximum ID
        int GetMaxID();

        //Add new T-entity
        void AddNewMessage(T t);        
        
        //return message by hash link
        String GetMessage(String hashLink);

        //delete from DB all time over messages
        void DeleteAllOverTimeMessages();

    }
}
