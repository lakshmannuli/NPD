using NPD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPD_UI.Custom
{
    public class SessionStore
    {
        private HttpSessionStateBase _httpSessionStateBase { set; get; }
        public SessionStore(HttpSessionStateBase httpSessionStateBase)
        {
            _httpSessionStateBase = httpSessionStateBase;
        }

        public LoggedUser LoggedUser
        {
            set
            {
                this._httpSessionStateBase["LoggedUser"] = value;
            }
            get
            {
                LoggedUser obj = null;
                if (_httpSessionStateBase["LoggedUser"] != null)
                {
                    obj = _httpSessionStateBase["LoggedUser"] as LoggedUser;
                }
                  obj = new LoggedUser() { Id = 1, RoleId = 1 };
                return obj;
            }
        }
    }
}