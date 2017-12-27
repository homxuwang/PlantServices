using System;
using System.Runtime.CompilerServices;

namespace Platform.Core
{

    public class DbQueryResult
    {
         object _Data;
         int _TotalRecords;

        public object Data
        {

            get
            {
                return this._Data;
            }

            set
            {
                this._Data = value;
            }
        }

        public int TotalRecords
        {

            get
            {
                return this._TotalRecords;
            }

            set
            {
                this._TotalRecords = value;
            }
        }

    }


}

