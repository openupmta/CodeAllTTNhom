﻿using QLKSCommonModels.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKSCommonModels.Dom
{
    public class UserDom
    {
        QLKSdbContext db = null;
        public UserDom()
        {
            db = new QLKSdbContext();

        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;

            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;

                }

            }
        }
    }
}
