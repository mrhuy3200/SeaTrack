using DotNetNuke.UI.UserControls;
using Microsoft.ApplicationBlocks.Data;
using SeaTrack.Lib.Database;
using SeaTrack.Lib.DTO;
using SeaTrack.Lib.DTO.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaTrack.Lib.Service
{
    public class UsersService
    {
        public static Users CheckUsers(String name, String pass)
        {
            if (name == null || pass == null) return null;
            var reader = SqlHelper.ExecuteReader(ConnectData.ConnectionString, "sp_GetDataUser", name, pass);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var data = new Users()
                    {
                        UserID = Convert.ToInt16(reader["UserID"]),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        Status = Convert.ToInt16(reader["Status"]),
                        CreateBy = reader["CreateBy"].ToString(),
                        CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                        UpdateBy = Convert.ToDateTime(reader["UpdateBy"]),
                        LastUpdateDate = Convert.ToDateTime(reader["LastUpdateDate"]),
                        RoleID = Convert.ToInt16(reader["RoleID"]),

                    };
                    return data;
                }
            }
            return null;
        }

        public static UserInfoDTO GetUserByID(int UserID)
        {
            var reader = SqlHelper.ExecuteReader(ConnectData.ConnectionString, "sp_GetUserByID", UserID);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var data = new UserInfoDTO()
                    {
                        UserID = Convert.ToInt16(reader["UserID"]),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Fullname = reader["FullName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        Status = Convert.ToInt16(reader["Status"]),
                        CreateBy = reader["CreateBy"].ToString(),
                        CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                        UpdateBy = reader["UpdateBy"].ToString(),
                        LastUpdateDate = Convert.ToDateTime(reader["LastUpdateDate"]),
                        RoleID = Convert.ToInt16(reader["RoleID"]),
                    };
                    return data;
                }
            }
            return null;
        }

        public static bool EditUser(UserInfoDTO user)
        {
            try
            {
                int res = SqlHelper.ExecuteNonQuery(ConnectData.ConnectionString, "sp_EditUser", user.UserID, user.Username, user.Password, user.Fullname, user.Phone, user.Address, user.Status, user.UpdateBy, user.LastUpdateDate, user.RoleID);
                if (res==0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteUser(int UserID)
        {
            try
            {
                int res = SqlHelper.ExecuteNonQuery(ConnectData.ConnectionString, "sp_DeleteUser", UserID);
                if (res==0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
