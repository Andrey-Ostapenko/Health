using System;
using System.Collections.Specialized;
using System.Web;
using Health.API.Entities;
using Health.API.Repository;

namespace Health.Site.Repository
{
    public class SessionDataAccessor : IActualCredentialRepository
    {
        public void Write(string identifier, IUserCredential credential)
        {
            if (!SessionContainsKey(identifier))
            {
                HttpContext.Current.Session.Add(identifier, credential);
            }
            else
            {
                HttpContext.Current.Session[identifier] = credential;
            }
        }

        public IUserCredential Read(string identifier)
        {
            return (IUserCredential) HttpContext.Current.Session[identifier];
        }

        public void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        private bool SessionContainsKey(string key)
        {
            NameObjectCollectionBase.KeysCollection keys_collection = HttpContext.Current.Session.Keys;

            foreach (var keyi in keys_collection)
            {
                if (keyi.ToString() == key)
                {
                    return true;
                }
            }
            return false;
        }
    }
}