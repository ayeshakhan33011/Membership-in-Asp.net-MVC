using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mem_mvc.Models.general;
using mem_mvc.Models.Account;

namespace mem_mvc.ViewModel.Account
{
    public class AccountViewModel
    {
        public static List<SelectListItem> GetAllRoles(int roleId)
        {

            List<SelectListItem> roles = new List<SelectListItem>();
           SqlConnection con = new SqlConnection(AppSetting.ConnectionString()) ;
            { 
                SqlCommand cmd = new SqlCommand("usp_RolesGetRoleByRoleId", con) ;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = reader["RoleName"].ToString();
                    item.Text= reader["RoleName"].ToString();

                    roles.Add(item);




                }
                
            }
            return roles;
        }
        public static List<UserModel> GetAllUsers()
        {

            List<UserModel> users = new List<UserModel>();
            SqlConnection con = new SqlConnection(AppSetting.ConnectionString());
            SqlCommand cmd = new SqlCommand("usp_UsersGetAllUsers", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserModel user = new UserModel();
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.UserName = reader["UserName"].ToString();
                user.FullName = reader["FullName"].ToString();
                user.Email = reader["Email"].ToString();

                users.Add(user);
            }
            return users;
        }




    }
}